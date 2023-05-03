using Castle.Components.DictionaryAdapter;

namespace polyclinic.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Photo { get; set; }
        public ICollection<Photo>? Photos { get; set; }
        public int? MedicId { get; set; } 
        public Medic? Medic { get; set; }
    }
}
