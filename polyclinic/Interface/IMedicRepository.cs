using polyclinic.Models;

namespace polyclinic.Interface
{
    public interface IMedicRepository
    {
        Task<IEnumerable<Medic>> GetMedicsAsync(); // получение всех объектов
        Task<Medic> GetMedicById(int Id); // получение id
        void CreateMedic(Medic medic); // создание объекта
        void DeleteMedic(int Id); // удаление объекта по id
    }
}