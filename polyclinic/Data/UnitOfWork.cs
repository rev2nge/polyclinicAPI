using polyclinic.Data.Repository;
using polyclinic.Interface;
using polyclinic.Models;

namespace polyclinic.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context) 
        {
            _context = context;
        }
        public ICityRepository CityRepository => 
            new CityRepository(_context);

        public IMedicRepository MedicRepository =>
            new MedicRepository(_context);

        public IPolyclinicRepository PolyclinicRepository =>
            new PolyclinicRepository(_context);

        public ISpecializationRepository SpecializationRepository =>
            new SpecializationRepository(_context);

        public IUserRepository UserRepository =>
            new UserRepository(_context);

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
