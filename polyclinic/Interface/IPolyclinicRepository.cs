using polyclinic.Models;

namespace polyclinic.Interface
{
    public interface IPolyclinicRepository
    {
        Task<IEnumerable<Polyclinic>> GetPolyclinicsAsync(); // получение всех объектов
        Task<Polyclinic> GetPolyclinicById(int Id); // получение id
        void CreatePolyclinic(Polyclinic polyclinic); // создание объекта
        void DeletePolyclinic(int Id); // удаление объекта по id
    }
}