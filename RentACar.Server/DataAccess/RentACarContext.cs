using System;
using Microsoft.EntityFrameworkCore;
using RentACar.Shared.Models;

namespace RentACar.Server.DataAccess {
    public class RentACarContext : DbContext {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<CarBrand> CarBrands { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql ("server=localhost;database=rent_a_car;user=root;password=root");
        }
    }
}
