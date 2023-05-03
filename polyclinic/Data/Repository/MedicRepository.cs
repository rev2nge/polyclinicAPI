using Microsoft.EntityFrameworkCore;
using polyclinic.Interface;
using polyclinic.Models;

namespace polyclinic.Data.Repository
{
    public class MedicRepository : IMedicRepository
    {
        private readonly ApplicationContext _context;
        public MedicRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medic>> GetMedicsAsync()
        {
            return await _context.Medic.ToListAsync();
        }

        public async Task<Medic> GetMedicById(int Id)
        {
            var medics = await _context.Medic
            .Include(p => p.Photos)
            .Where(p => p.Id == Id)
            .FirstOrDefaultAsync();

            return medics;
        }

        public void CreateMedic(Medic medic)
        {
            _context.Medic.Add(medic);
        }

        public void DeleteMedic(int Id)
        {
            var medic = _context.Medic.Find(Id);
            _context.Medic.Remove(medic);
        }
    }
}
