using LoginApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Tables in our SQLite database:
        public DbSet<User> Users { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
    }
}



