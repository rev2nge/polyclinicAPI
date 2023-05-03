using polyclinic.Models;

namespace polyclinic.Interface
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync(); // получение всех объектов
        Task<City> GetCityById(int Id); // получение id
        void CreateCity(City city); // создание объекта
        void DeleteCity(int Id); // удаление объекта по id
    }
}