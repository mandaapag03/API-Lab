using LAB_API.Model;
using LAB_API.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace LAB_API.Repository.Context
{
    public class DataBaseContext : DbContext 
    {
        public DbSet<UserDto> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            options.UseNpgsql(config.GetConnectionString("PostgreSQL"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }   
    }
}
