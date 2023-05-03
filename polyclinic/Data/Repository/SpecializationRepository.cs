using Microsoft.EntityFrameworkCore;
using polyclinic.Interface;
using polyclinic.Models;

namespace polyclinic.Data.Repository
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly ApplicationContext _context;
        public SpecializationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Specialization>> GetSpecializationsAsync()
        {
            return await _context.Specialization.ToListAsync();
        }

        public async Task<Specialization> GetSpecializationById(int Id)
        {
            var specializations = await _context.Specialization
            .Include(p => p.Photos)
            .Where(p => p.Id == Id)
            .FirstOrDefaultAsync();

            return specializations;
        }

        public void CreateSpecialization(Specialization specialization)
        {
            _context.Specialization.Add(specialization);
        }

        public void DeleteSpecialization(int Id)
        {
            var specialization = _context.Specialization.Find(Id);
            _context.Specialization.Remove(specialization);
        }
    }
}
