using polyclinic.Models;

namespace polyclinic.Interface
{
    public interface ISpecializationRepository
    {
        Task<IEnumerable<Specialization>> GetSpecializationsAsync(); // получение всех объектов
        Task<Specialization> GetSpecializationById(int Id); // получение id
        void CreateSpecialization(Specialization specialization); // создание объекта
        void DeleteSpecialization(int Id); // удаление объекта по id
    }
}