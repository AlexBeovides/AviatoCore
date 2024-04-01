using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AviatoCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedServiceAndFacilityEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A popular bakery offering a variety of breads and pastries.");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "A workshop specializing in aircraft maintenance and repair.");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "A high-end shoe store offering a variety of stylish footwear.");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "A store offering a wide range of handcrafted goods from local artisans.");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "A currency exchange service offering competitive rates.");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "A Japanese restaurant offering a variety of sushi and other traditional dishes.");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "An Italian restaurant offering a variety of pasta dishes and pizzas.");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 1, 5, 11, 36, 393, DateTimeKind.Local).AddTicks(1783), new DateTime(2024, 4, 1, 7, 11, 36, 393, DateTimeKind.Local).AddTicks(1841) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 11, 36, 393, DateTimeKind.Local).AddTicks(1849), new DateTime(2024, 4, 1, 10, 11, 36, 393, DateTimeKind.Local).AddTicks(1850) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 1, 11, 11, 36, 393, DateTimeKind.Local).AddTicks(1853), new DateTime(2024, 4, 1, 13, 11, 36, 393, DateTimeKind.Local).AddTicks(1855) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 1, 14, 11, 36, 393, DateTimeKind.Local).AddTicks(1858), new DateTime(2024, 4, 1, 16, 11, 36, 393, DateTimeKind.Local).AddTicks(1859) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 1, 17, 11, 36, 393, DateTimeKind.Local).AddTicks(1861), new DateTime(2024, 4, 1, 19, 11, 36, 393, DateTimeKind.Local).AddTicks(1863) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 1, 20, 11, 36, 393, DateTimeKind.Local).AddTicks(1865), new DateTime(2024, 4, 1, 22, 11, 36, 393, DateTimeKind.Local).AddTicks(1866) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 1, 23, 11, 36, 393, DateTimeKind.Local).AddTicks(1869), new DateTime(2024, 4, 2, 1, 11, 36, 393, DateTimeKind.Local).AddTicks(1870) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 2, 2, 11, 36, 393, DateTimeKind.Local).AddTicks(1872), new DateTime(2024, 4, 2, 4, 11, 36, 393, DateTimeKind.Local).AddTicks(1873) });

            migrationBuilder.InsertData(
                table: "RepairTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Engine Overhaul" },
                    { 2, "Hydraulic System Repair" },
                    { 3, "Electrical System Repair" },
                    { 4, "Avionics Repair" },
                    { 5, "Structural Repair" },
                    { 6, "Fuel System Repair" }
                });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Delicious blend of gourmet coffee", "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Freshly baked pastries made with love", "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Professional aircraft engine tune-up service", "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Thorough avionic systems check for your aircraft", "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Custom-tailored pilot uniforms for a perfect fit", "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Stylish collection of flight jackets", "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Beautiful handcrafted model aircraft", "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Unique aviation memorabilia for collectors", "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Convenient foreign currency conversion service", "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Secure traveler's cheque issuance service", "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Fresh and delicious sashimi selection", "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Exquisite signature sushi rolls", "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Authentic Italian pasta dishes", "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Delicious gourmet pizza delivered to your location", "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png" });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "RepairTypeId", "ServiceId" },
                values: new object[,]
                {
                    { 3, 1, 3 },
                    { 4, 4, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Facilities");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 1, 1, 42, 52, 266, DateTimeKind.Local).AddTicks(7692), new DateTime(2024, 4, 1, 3, 42, 52, 266, DateTimeKind.Local).AddTicks(7784) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 1, 4, 42, 52, 266, DateTimeKind.Local).AddTicks(7792), new DateTime(2024, 4, 1, 6, 42, 52, 266, DateTimeKind.Local).AddTicks(7793) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 1, 7, 42, 52, 266, DateTimeKind.Local).AddTicks(7796), new DateTime(2024, 4, 1, 9, 42, 52, 266, DateTimeKind.Local).AddTicks(7797) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 1, 10, 42, 52, 266, DateTimeKind.Local).AddTicks(7800), new DateTime(2024, 4, 1, 12, 42, 52, 266, DateTimeKind.Local).AddTicks(7801) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 42, 52, 266, DateTimeKind.Local).AddTicks(7804), new DateTime(2024, 4, 1, 15, 42, 52, 266, DateTimeKind.Local).AddTicks(7805) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 1, 16, 42, 52, 266, DateTimeKind.Local).AddTicks(7807), new DateTime(2024, 4, 1, 18, 42, 52, 266, DateTimeKind.Local).AddTicks(7809) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 1, 19, 42, 52, 266, DateTimeKind.Local).AddTicks(7811), new DateTime(2024, 4, 1, 21, 42, 52, 266, DateTimeKind.Local).AddTicks(7812) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 4, 1, 22, 42, 52, 266, DateTimeKind.Local).AddTicks(7814), new DateTime(2024, 4, 2, 0, 42, 52, 266, DateTimeKind.Local).AddTicks(7816) });
        }
    }
}
