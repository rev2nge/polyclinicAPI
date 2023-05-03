namespace polyclinic.Models
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Polyclinic> Polyclinics { get; set; } = new();
    }
}
