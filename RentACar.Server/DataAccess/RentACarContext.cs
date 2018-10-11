using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACar.Shared.Models;

namespace RentACar.Server.DataAccess 
{
    public class RentACarContext : IdentityDbContext 
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<User> UserInfo { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseMySql ("server=localhost;database=rent_a_car;user=root;password=root");
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
    }
}
