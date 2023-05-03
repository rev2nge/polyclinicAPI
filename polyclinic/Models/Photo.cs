using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace polyclinic.Models
{
    public class Photo
    {
        public int Id { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
    }
}
