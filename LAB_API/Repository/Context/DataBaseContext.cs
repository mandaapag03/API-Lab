using LAB_API.Model;
using Microsoft.EntityFrameworkCore;

namespace LAB_API.Repository.Context
{
    public class DataBaseContext : DbContext 
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (Users == null) { }
            base.OnModelCreating(builder);
        }
    }
}
