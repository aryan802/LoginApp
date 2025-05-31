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

        //  TELL EF CORE ABOUT THE ENTITIES
        public DbSet<User> Users { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
    }
}





