using Microsoft.EntityFrameworkCore;

namespace WebAppAssignment1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Person> People { get; set; }
    }
}
