using polyclinic.Models;

namespace polyclinic.Dto
{
    public class PolyclinicDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CityName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Photo { get; set; }
    }
}
