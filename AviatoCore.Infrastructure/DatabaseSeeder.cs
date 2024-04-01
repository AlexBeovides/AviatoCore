using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure
{
    public class DatabaseSeeder
    {

        public DatabaseSeeder()
        {
           
        }

        public async Task SeedData(ModelBuilder modelBuilder)
        {

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
               new ClientType { Id = 2, Name = "VIP" },
               new ClientType { Id = 3, Name = "Company" }
            );

            modelBuilder.Entity<FacilityType>().HasData(
                    new FacilityType { Id = 1, Name = "Cafeteria" },
                    new FacilityType { Id = 2, Name = "Workshop" },
                    new FacilityType { Id = 3, Name = "Clothing Store" },
                    new FacilityType { Id = 4, Name = "Gift Shop" },
                    new FacilityType { Id = 5, Name = "Currency exchange office" },
                    new FacilityType { Id = 6, Name = "Sushi Bar" },
                    new FacilityType { Id = 7, Name = "Restaurant" }
            );

            modelBuilder.Entity<Facility>().HasData(
                new Facility { Id = 1, Name = "Breadway", Address = "Street 15, 14077", Description = "A popular bakery offering a variety of breads and pastries.", ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663766/womxzvcwlkmgebmkzypa.webp", AirportId = 1, FacilityTypeId = 1 },
                new Facility { Id = 2, Name = "AMXWorkshop", Address = "Street 20, 23078", Description = "A workshop specializing in aircraft maintenance and repair.", ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663767/yej7dkz5v8nwp1cemm5l.jpg", AirportId = 1, FacilityTypeId = 2 },
                new Facility { Id = 3, Name = "Tascon", Address = "Street 5, 66778", Description = "A high-end shoe store offering a variety of stylish footwear.", ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663768/gt2fpdjqrqoqqrvrltm5.jpg", AirportId = 1, FacilityTypeId = 3 },
                new Facility { Id = 4, Name = "ArtesaniaDominicana", Address = "Street 1, 45556", Description = "A store offering a wide range of handcrafted goods from local artisans.", ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663767/kbxqsrk2vu5xstwxrvxr.jpg", AirportId = 1, FacilityTypeId = 4 },
                new Facility { Id = 5, Name = "CambioExchange", Address = "Street 20, 23078", Description = "A currency exchange service offering competitive rates.", ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663767/i4tka668odgaukhbiigd.jpg", AirportId = 1, FacilityTypeId = 5 },
                new Facility { Id = 6, Name = "Ryu", Address = "Street 7, 12078", Description = "A Japanese restaurant offering a variety of sushi and other traditional dishes.", ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663766/ryd91lefb0jsz0sfgr8x.jpg", AirportId = 2, FacilityTypeId = 6 },
                new Facility { Id = 7, Name = "Tagliatella", Address = "Street 1, 16078", Description = "An Italian restaurant offering a variety of pasta dishes and pizzas.", ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663766/ovqroknpskzubu6g3trd.jpg", AirportId = 2, FacilityTypeId = 7 }
            );

            modelBuilder.Entity<Service>().HasData(
                 // Breadway - Cafeteria (FacilityId = 1)
                 new Service { Id = 1, Name = "Gourmet Coffee Blend", Description = "Delicious blend of gourmet coffee", Price = 2.99, FacilityId = 1, IsDeleted = false, ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" },
                 new Service { Id = 2, Name = "Freshly Baked Pastries", Description = "Freshly baked pastries made with love", Price = 3.49, FacilityId = 1, IsDeleted = false, ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" },
                 // AMXWorkshop - Hangar (FacilityId = 2)
                 new Service { Id = 3, Name = "Aircraft Engine Tune-Up", Description = "Professional aircraft engine tune-up service", Price = 499.99, FacilityId = 2, IsDeleted = false, ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" },
                 new Service { Id = 4, Name = "Avionic Systems Check", Description = "Thorough avionic systems check for your aircraft", Price = 299.99, FacilityId = 2, IsDeleted = false, ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" },
                 // Tascon - Clothing Store (FacilityId = 3)
                 new Service { Id = 5, Name = "Tailored Pilot Uniforms", Description = "Custom-tailored pilot uniforms for a perfect fit", Price = 199.99, FacilityId = 3, IsDeleted = false, ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" },
                 new Service { Id = 6, Name = "Flight Jackets Collection", Description = "Stylish collection of flight jackets", Price = 149.99, FacilityId = 3, IsDeleted = false, ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" },
                 // ArtesaniaDominicana - Gift Shop (FacilityId = 4)
                 new Service { Id = 7, Name = "Handcrafted Model Aircraft", Description = "Beautiful handcrafted model aircraft", Price = 59.99, FacilityId = 4, IsDeleted = false, ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" },
                 new Service { Id = 8, Name = "Aviation Memorabilia", Description = "Unique aviation memorabilia for collectors", Price = 39.99, FacilityId = 4, IsDeleted = false, ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" },
                 // CambioExchange - Currency Exchange Office (FacilityId = 5)
                 new Service { Id = 9, Name = "Foreign Currency Conversion", Description = "Convenient foreign currency conversion service", Price = 0.99, FacilityId = 5, IsDeleted = false, ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" },
                 new Service { Id = 10, Name = "Traveler's Cheque Issuance", Description = "Secure traveler's cheque issuance service", Price = 1.99, FacilityId = 5, IsDeleted = false, ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" },
                 // Ryu - Sushi Bar (FacilityId = 6)
                 new Service { Id = 11, Name = "Sashimi Selection", Description = "Fresh and delicious sashimi selection", Price = 18.99, FacilityId = 6, IsDeleted = false, ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" },
                 new Service { Id = 12, Name = "Signature Sushi Rolls", Description = "Exquisite signature sushi rolls", Price = 15.99, FacilityId = 6, IsDeleted = false, ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" },
                 // Tagliatella - Restaurant (FacilityId = 7)
                 new Service { Id = 13, Name = "Authentic Italian Pasta Selection", Description = "Authentic Italian pasta dishes", Price = 12.99, FacilityId = 7, IsDeleted = false, ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" },
                 new Service { Id = 14, Name = "Gourmet Pizza Delivery Service", Description = "Delicious gourmet pizza delivered to your location", Price = 15.99, FacilityId = 7, IsDeleted = false, ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" }
             );

            modelBuilder.Entity<OwnerRole>().HasData(
                new OwnerRole { Id = 1, Name = "Passenger" },
                new OwnerRole { Id = 2, Name = "Captain" }
            );

            modelBuilder.Entity<PlaneCondition>().HasData(
                new PlaneCondition { Id = 1, Name = "New" },
                new PlaneCondition { Id = 2, Name = "Good" },
                new PlaneCondition { Id = 3, Name = "Fair" },
                new PlaneCondition { Id = 4, Name = "Poor" },
                new PlaneCondition { Id = 5, Name = "Bad" }
            );

            modelBuilder.Entity<RepairType>().HasData(
               new RepairType { Id = 1, Name = "Engine Overhaul" },
               new RepairType { Id = 2, Name = "Hydraulic System Repair" },
               new RepairType { Id = 3, Name = "Electrical System Repair" },
               new RepairType { Id = 4, Name = "Avionics Repair" },
               new RepairType { Id = 5, Name = "Structural Repair" },
               new RepairType { Id = 6, Name = "Fuel System Repair" }
           );

            modelBuilder.Entity<Repair>().HasData(
               new Repair { Id = 3, ServiceId = 3, RepairTypeId = 1 },
               new Repair { Id = 4, ServiceId = 4, RepairTypeId = 4 }
           );
        }
    }
}
