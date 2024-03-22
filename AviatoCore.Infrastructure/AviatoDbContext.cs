using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AviatoCore.Infrastructure
{
    public class AviatoDbContext : IdentityDbContext<User>
    {
        public AviatoDbContext(DbContextOptions<AviatoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }

        // Add other DbSets for your other entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Don't forget to call base method

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => x.UserId);

            modelBuilder.Entity<Airport>().HasData(
                new Airport { Id = 1, Name = "José Martí", Address = "Avenida Van Troy y Final, Rancho Boyeros, Havana, Cuba", Latitude = 22.9892, Longitude = -82.4092 },
                new Airport { Id = 2, Name = "Juan Gualberto Gómez", Address = "Matanzas, Cuba", Latitude = 23.0344, Longitude = -81.4353 },
                new Airport { Id = 3, Name = "Abel Santamaría", Address = "Carretera a Maleza Km 1 y medio, Santa Clara, Cuba", Latitude = 22.4922, Longitude = -79.9436 },
                new Airport { Id = 4, Name = "Frank País", Address = "Holguín, Cuba", Latitude = 20.7856, Longitude = -76.3151 },
                new Airport { Id = 5, Name = "Playa Baracoa", Address = "Playa Baracoa, Havana, Cuba", Latitude = 23.0328, Longitude = -82.5794 }
            );

            // Add seed data for Role
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Director", NormalizedName = "DIRECTOR" },
                new IdentityRole { Id = "3", Name = "Security", NormalizedName = "SECURITY" },
                new IdentityRole { Id = "4", Name = "Maintenance", NormalizedName = "MAINTENANCE" },
                new IdentityRole { Id = "5", Name = "Client", NormalizedName = "CLIENT" }
            );

            modelBuilder.Entity<ClientType>().HasData(
               new ClientType { Id = 1, Name = "Regular" },
               new ClientType { Id = 2, Name = "VIP"},
               new ClientType { Id = 3, Name = "Company"}
           );

           
        }
    }
}
