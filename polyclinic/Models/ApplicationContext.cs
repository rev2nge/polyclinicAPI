using Microsoft.EntityFrameworkCore;
using polyclinic.Models;

namespace polyclinic.Models
{
    public class ApplicationContext : DbContext 
    {
        public DbSet<City> City { get; set; } = null!;
        public DbSet<Medic> Medic { get; set; } = null!;
        public DbSet<Polyclinic> Polyclinic { get; set; } = null!;
        public DbSet<Specialization> Specialization { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
               : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public ApplicationContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
