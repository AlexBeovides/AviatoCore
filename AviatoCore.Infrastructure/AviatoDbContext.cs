using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AviatoCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AviatoCore.Infrastructure
{
    public class AviatoDbContext : DbContext
    {
        public AviatoDbContext(DbContextOptions<AviatoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Worker> Workers { get; set; }

        // Add other DbSets for your other entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<Client>()
                .ToTable("Clients");

            modelBuilder.Entity<Worker>()
                .ToTable("Workers");

            // Add seed data for Role
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", CanModifyAirports = true },
                new Role { Id = 2, Name = "Director", CanModifyAirports = false },
                new Role { Id = 3, Name = "Security", CanModifyAirports = false },
                new Role { Id = 4, Name = "Maintenance", CanModifyAirports = false },
                new Role { Id = 5, Name = "Client", CanModifyAirports = false }
            );

            // Add seed data for User
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name= "admin" , Surname="admin" , Email = "admin@admin.com", Password = "admin", RoleId = 1 }
            );
        }
    }
}
