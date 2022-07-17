using Microsoft.EntityFrameworkCore;

namespace Placement.Models
{
    public class MSContext : DbContext
    {
        public MSContext() { }
        public MSContext(DbContextOptions options): base(options)
        { }

        public DbSet<Student> student { get; set; }
        public DbSet<Admin> admin { get; set; }
        public DbSet<Company> company { get; set; }
        public DbSet<Application> application { get; set; }



    }
}
