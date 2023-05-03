namespace polyclinic.Models
{
    public class Medic
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public int? Price { get; set; }
        public string? Phone { get; set; }
        public string? Photo { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public string? Experience { get; set;}
        public string? Description { get; set; }
        public string? FullDescription { get; set; }
        public List<Polyclinic> Polyclinics { get; set; } = new();
        public List<Specialization> Specializations { get; set; } = new();
    }
}