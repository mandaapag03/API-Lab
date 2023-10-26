using LAB_API.Model;
using LAB_API.Model.Mapping;
using Microsoft.EntityFrameworkCore;

namespace LAB_API.Repository.Context
{
    public class DataBaseContext : DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            options.UseNpgsql(config.GetConnectionString("PostgreSQL"));
            options.LogTo(Console.WriteLine);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new UserTypeMap());
            builder.ApplyConfiguration(new LabMap());
            builder.ApplyConfiguration(new BookingMap());
        }
    }
}
