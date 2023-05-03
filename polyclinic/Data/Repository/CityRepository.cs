using Microsoft.EntityFrameworkCore;
using polyclinic.Interface;
using polyclinic.Models;

namespace polyclinic.Data.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationContext _context;
        public CityRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.City.ToListAsync();
        }

        public async Task<City> GetCityById(int Id)
        {
            return await _context.City.FindAsync(Id);
        }
        void ICityRepository.CreateCity(City city)
        {
            _context.City.Add(city);
        }

        public void DeleteCity(int Id)
        {
            var city = _context.City.Find(Id);
            _context.City.Remove(city);
        }

        //public City UpdateCity(City city)
        //{
        //    var result = _context.City
        //        .FirstOrDefault(x => x.Id == city.Id);

        //    if (result != null)
        //    {
        //        result.Name = city.Name;

        //        _context.SaveChanges();
        //        return result;
        //    }
        //    return null;
        //}

    }
}
