using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AviatoCore.Infrastructure
{
    public class AviatoDbContext : IdentityDbContext<User>
    {
        private readonly DatabaseSeeder _seeder;


        public AviatoDbContext(DbContextOptions<AviatoDbContext> options)
        : base(options)
        {
            
            _seeder = new DatabaseSeeder();
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<FacilityType> FacilityTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ClientServices> ClientServices { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<OwnerRole> OwnersRole { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<RepairType> RepairTypes { get; set; }
        public DbSet<FlightRepair> FlightRepairs { get; set; }
        public DbSet<RepairDependency> RepairDependencies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<PlaneCondition> PlaneConditions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Don't forget to call base method

            ConfigureIdentityUserLogin(modelBuilder);
            ConfigureRepairDependency(modelBuilder);
            ConfigureFlightRepair(modelBuilder);
            ConfigureRepairDependency(modelBuilder);

            _seeder.SeedData(modelBuilder).Wait();
        }

        private void ConfigureIdentityUserLogin(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => x.UserId);
        }

        private void ConfigureRepairDependency(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RepairDependency>()
                .HasKey(r => new { r.PlaneConditionId, r.RepairAId, r.RepairBId });

            modelBuilder.Entity<RepairDependency>()
                .HasOne(rd => rd.RepairA)
                .WithMany(r => r.RepairADependencies)
                .HasForeignKey(rd => rd.RepairAId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RepairDependency>()
                .HasOne(rd => rd.RepairB)
                .WithMany(r => r.RepairBDependencies)
                .HasForeignKey(rd => rd.RepairBId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        private void ConfigureFlightRepair(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightRepair>()
                .HasOne(fr => fr.Repair)
                .WithMany(r => r.FlightRepairs)
                .HasForeignKey(fr => fr.RepairId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FlightRepair>()
                .HasOne(fr => fr.Flight)
                .WithMany(f => f.FlightRepairs)
                .HasForeignKey(fr => fr.FlightId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
