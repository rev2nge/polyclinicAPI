using Microsoft.EntityFrameworkCore;
using polyclinic.Interface;
using polyclinic.Models;

namespace polyclinic.Data.Repository
{
    public class PolyclinicRepository : IPolyclinicRepository
    {
        private readonly ApplicationContext _context;
        public PolyclinicRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Polyclinic>> GetPolyclinicsAsync()
        {
            return await _context.Polyclinic.ToListAsync();
        }

        public async Task<Polyclinic> GetPolyclinicById(int Id)
        {
            return await _context.Polyclinic.FindAsync(Id);
        }
        void IPolyclinicRepository.CreatePolyclinic(Polyclinic polyclinic)
        {
            _context.Polyclinic.Add(polyclinic);
        }

        public void DeletePolyclinic(int Id)
        {
            var polyclinic = _context.Polyclinic.Find(Id);
            _context.Polyclinic.Remove(polyclinic);
        }
    }
}
