using Microsoft.EntityFrameworkCore;

namespace TestGraph.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
        public DbSet<Entities.Person> Persons { get; set; }
        public DbSet<Entities.Doctor> Doctors { get; set; }
        public DbSet<Entities.Appointment> Appointments { get; set; }
    }
}
