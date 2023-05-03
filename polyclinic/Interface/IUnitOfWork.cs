namespace polyclinic.Interface
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }
        IMedicRepository MedicRepository { get; }
        IPolyclinicRepository PolyclinicRepository { get; }
        ISpecializationRepository SpecializationRepository { get; }
        IUserRepository UserRepository { get; }
        Task<bool> SaveAsync();
    }
}
