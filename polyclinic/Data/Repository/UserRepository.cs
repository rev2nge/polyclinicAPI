using Microsoft.EntityFrameworkCore;
using polyclinic.Interface;
using polyclinic.Models;
using System.Security.Cryptography;

namespace polyclinic.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;

        }
        public async Task<User> Authenticate(string userName, string passwordText)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Username == userName);

            if (user == null || user.PasswordKey == null)
                return null;

            if (!MatchPasswordHash(passwordText, user.Password, user.PasswordKey))
                return null;

            return user;
        }

        private bool MatchPasswordHash(string passwordText, byte[] password, byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512(passwordKey))
            {
                var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordText));

                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != password[i])
                        return false;
                }

                return true;
            }
        }

        public void Register(string userName, string password)
        {
            byte[] passwordHash, passwordKey;

            using (var hmac = new HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }

            User user = new User();
            user.Username = userName;
            user.Password = passwordHash;
            user.PasswordKey = passwordKey;

            _context.User.Add(user);
        }

        public async Task<bool> UserAlreadyExists(string userName)
        {
            return await _context.User.AnyAsync(x => x.Username == userName);
        }
    }
}
