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
            //ACK
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

            //ACK
            modelBuilder.Entity<ClientType>().HasData(
               new ClientType { Id = 1, Name = "Regular" },
               new ClientType { Id = 2, Name = "VIP" },
               new ClientType { Id = 3, Name = "Company" }
            );

            //ACK
            modelBuilder.Entity<Client>().HasData(
                new Client { ClientId = "c63447a0-24dd-4390-9914-2962d12fb40c", UserId = "c63447a0-24dd-4390-9914-2962d12fb40c", Country = "URSS", ClientTypeId = 2 },
                new Client { ClientId = "c8795973-e00b-44fb-9701-a9fb61f7ac82", UserId = "c8795973-e00b-44fb-9701-a9fb61f7ac82", Country = "Roman Empire", ClientTypeId = 3 },
                new Client { ClientId = "4", UserId = "4", Country = "Japan", ClientTypeId = 1 },
                new Client { ClientId = "5", UserId = "5", Country = "Candy Kingdom", ClientTypeId = 2 },
                new Client { ClientId = "6", UserId = "6", Country = "Wano", ClientTypeId = 3 },
                new Client { ClientId = "7", UserId = "7", Country = "Falconia", ClientTypeId = 1 }
            );

            //ACK
            modelBuilder.Entity<User>().HasData(
                new User { Id = "c63447a0-24dd-4390-9914-2962d12fb40c", UserName = "gorbachov@gmail.com", NormalizedUserName = "GORBACHOV@GMAIL.COM", Email = "gorbachov@gmail.com", NormalizedEmail = "GORBACHOV@GMAIL.COM", EmailConfirmed = true, PasswordHash = "03954d41-9eaa-4411-8a1d-67b1b5d39ab6", SecurityStamp = "123", ConcurrencyStamp = "123", Name = "Mijail", Surname = "Gorbachov", IsDeleted = false },
                new User { Id = "c8795973-e00b-44fb-9701-a9fb61f7ac82", UserName = "jesus@mail.re", NormalizedUserName = "JESUS@MAIL.RE", Email = "jesus@mail.re", NormalizedEmail = "JESUS@MAIL.RE", EmailConfirmed = true, PasswordHash = "03954d41-9eaa-4411-8a1d-67b1b5d39ab6", SecurityStamp = "123", ConcurrencyStamp = "123", Name = "Jesus", Surname = "Nazareno", IsDeleted = false },
                new User { Id = "4", UserName = "godzilla@jmail.jp", NormalizedUserName = "GODZILLA@JMAIL.JP", Email = "godzilla@jmail.jp", NormalizedEmail = "GODZILLA@JMAIL.JP", EmailConfirmed = true, PasswordHash = "03954d41-9eaa-4411-8a1d-67b1b5d39ab6", SecurityStamp = "123", ConcurrencyStamp = "123", Name = "Godzilla", Surname = "Kaiju", IsDeleted = false },
                new User { Id = "5", UserName = "pbgum@ooomail.at", NormalizedUserName = "PBGUM@OOOMAIL.AT", Email = "pbgum@ooomail.at", NormalizedEmail = "PBGUM@OOOMAIL.AT", EmailConfirmed = true, PasswordHash = "03954d41-9eaa-4411-8a1d-67b1b5d39ab6", SecurityStamp = "123", ConcurrencyStamp = "123", Name = "Bonnibel", Surname = "Bubblegum", IsDeleted = false },
                new User { Id = "6", UserName = "momo@mailbird.op", NormalizedUserName = "MOMO@MAILBIRD.OP", Email = "momo@mailbird.op", NormalizedEmail = "MOMO@MAILBIRD.OP", EmailConfirmed = true, PasswordHash = "03954d41-9eaa-4411-8a1d-67b1b5d39ab6", SecurityStamp = "123", ConcurrencyStamp = "123", Name = "Momonosuke", Surname = "Kozuki", IsDeleted = false },
                new User { Id = "7", UserName = "grifi@midmail.ml", NormalizedUserName = "GRIFI@MIDMAIL.ML", Email = "grifi@midmail.ml", NormalizedEmail = "GRIFI@MIDMAIL.ML", EmailConfirmed = true, PasswordHash = "03954d41-9eaa-4411-8a1d-67b1b5d39ab6", SecurityStamp = "123", ConcurrencyStamp = "123", Name = "Griffith", Surname = "White Falcon", IsDeleted = false }
            );

            //ACK
            modelBuilder.Entity<FacilityType>().HasData(
                    new FacilityType { Id = 1, Name = "Cafeteria" },
                    new FacilityType { Id = 2, Name = "Workshop" },
                    new FacilityType { Id = 3, Name = "Clothing Store" },
                    new FacilityType { Id = 4, Name = "Gift Shop" },
                    new FacilityType { Id = 5, Name = "Currency exchange office" },
                    new FacilityType { Id = 6, Name = "Sushi Bar" },
                    new FacilityType { Id = 7, Name = "Restaurant" },
                    new FacilityType { Id = 8, Name = "Dentist" }
            );

            //ACK
            modelBuilder.Entity<Facility>().HasData(
                new Facility { Id = 1, Name = "Breadway", Address = "Street 15, 14077", Description = "A popular bakery offering a variety of breads and pastries.", ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663766/womxzvcwlkmgebmkzypa.webp", AirportId = 1, FacilityTypeId = 1 },
                new Facility { Id = 2, Name = "AMXWorkshop", Address = "Street 20, 23078", Description = "A workshop specializing in aircraft maintenance and repair.", ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663767/yej7dkz5v8nwp1cemm5l.jpg", AirportId = 1, FacilityTypeId = 2 },
                new Facility { Id = 3, Name = "Tascon", Address = "Street 5, 66778", Description = "A high-end shoe store offering a variety of stylish footwear.", ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663768/gt2fpdjqrqoqqrvrltm5.jpg", AirportId = 1, FacilityTypeId = 3 },
                new Facility { Id = 4, Name = "ArtesaniaDominicana", Address = "Street 1, 45556", Description = "A store offering a wide range of handcrafted goods from local artisans.", ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663767/kbxqsrk2vu5xstwxrvxr.jpg", AirportId = 1, FacilityTypeId = 4 },
                new Facility { Id = 5, Name = "CambioExchange", Address = "Street 20, 23078", Description = "A currency exchange service offering competitive rates.", ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663767/i4tka668odgaukhbiigd.jpg", AirportId = 1, FacilityTypeId = 5 },
                new Facility { Id = 6, Name = "Ryu", Address = "Street 7, 12078", Description = "A Japanese restaurant offering a variety of sushi and other traditional dishes.", ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663766/ryd91lefb0jsz0sfgr8x.jpg", AirportId = 2, FacilityTypeId = 6 },
                new Facility { Id = 7, Name = "Tagliatella", Address = "Street 1, 16078", Description = "An Italian restaurant offering a variety of pasta dishes and pizzas.", ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663766/ovqroknpskzubu6g3trd.jpg", AirportId = 2, FacilityTypeId = 7 },
                new Facility { Id = 8, Name = "Dentist", Address = "p sherman 42 wallaby way sydney", Description = "A dentist with a fish bowl.", ImgUrl = "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663766/ovqroknpskzubu6g3trd.jpg", AirportId = 2, FacilityTypeId = 8 }
            );

            //ACK
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

            //ACK
            modelBuilder.Entity<OwnerRole>().HasData(
                new OwnerRole { Id = 1, Name = "Passenger" },
                new OwnerRole { Id = 2, Name = "Pilot" },
                new OwnerRole { Id = 3, Name = "Co-Pilot" },
                new OwnerRole { Id = 4, Name = "Flight Attendant" }
            );


            //ACK
            modelBuilder.Entity<Plane>().HasData(
                new Plane { Id = 1, Classification = "Commercial", CargoCapacity = 20000, CrewCount = 5, PassengerCapacity = 200, OwnerId = "4" },
                new Plane { Id = 2, Classification = "Private", CargoCapacity = 5000, CrewCount = 2, PassengerCapacity = 10, OwnerId = "4" },
                new Plane { Id = 3, Classification = "Cargo", CargoCapacity = 50000, CrewCount = 5, PassengerCapacity = 0, OwnerId = "5" },
                new Plane { Id = 4, Classification = "Military", CargoCapacity = 15000, CrewCount = 10, PassengerCapacity = 50, OwnerId = "6" },
                new Plane { Id = 5, Classification = "Commercial", CargoCapacity = 25000, CrewCount = 6, PassengerCapacity = 250, OwnerId = "7" }
            );


            modelBuilder.Entity<RepairType>().HasData(
               new RepairType { Id = 1, Name = "Engine Overhaul" },
               new RepairType { Id = 2, Name = "Hydraulic System Repair" },
               new RepairType { Id = 3, Name = "Electrical System Repair" },
               new RepairType { Id = 4, Name = "Avionics Repair" },
               new RepairType { Id = 5, Name = "Structural Repair" },
               new RepairType { Id = 6, Name = "Fuel System Repair" }
               );

          

        }
    }
}
