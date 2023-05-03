namespace polyclinic.Models
{
    public class Polyclinic
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CityId { get; set; }
        public City? City { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Photo { get; set; }
        public ICollection<Photo>? Photos { get; set; }
        public List<Medic> Medics { get; set; } = new();
    }
}
