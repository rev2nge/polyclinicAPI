using polyclinic.Models;

namespace polyclinic.Dto
{
    public class MedicDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public int? SpecializationId { get; set; }
        public int? Price { get; set; }
        public string? Phone { get; set; }
        public string? Photo { get; set; }
        public string? Experience { get; set; }
        public string? Description { get; set; }
        public string? FullDescription { get; set; }
        public string? NamePolyclinic { get; set; }
        public string? NameSpecializations { get; set; }
    }
}
