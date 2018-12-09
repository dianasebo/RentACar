using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACar.Shared.Models;

namespace RentACar.Server.DataAccess
{
    public class RentACarContext : IdentityDbContext
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarPicture> CarPictures { get; set; }
        public virtual DbSet<User> UserInfo { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .HasMany(u => u.Cars)
                .WithOne(c => c.User);
            builder.Entity<Car>()
                .HasMany(c => c.Pictures)
                .WithOne(p => p.Car);
            builder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages);
            builder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=rent_a_car;user=root;password=root");
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
    }
}
