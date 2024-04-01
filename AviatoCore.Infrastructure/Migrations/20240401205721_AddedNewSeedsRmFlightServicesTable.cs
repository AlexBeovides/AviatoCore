using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AviatoCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewSeedsRmFlightServicesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightServices");

            migrationBuilder.DeleteData(
                table: "PlaneConditions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlaneConditions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlaneConditions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlaneConditions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlaneConditions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<double>(
                name: "RepairCost",
                table: "FlightRepairs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4", 0, "123", "godzilla@jmail.jp", true, false, false, null, "Godzilla", "GODZILLA@JMAIL.JP", "GODZILLA@JMAIL.JP", "03954d41-9eaa-4411-8a1d-67b1b5d39ab6", null, false, "123", "Kaiju", false, "godzilla@jmail.jp" },
                    { "5", 0, "123", "pbgum@ooomail.at", true, false, false, null, "Bonnibel", "PBGUM@OOOMAIL.AT", "PBGUM@OOOMAIL.AT", "03954d41-9eaa-4411-8a1d-67b1b5d39ab6", null, false, "123", "Bubblegum", false, "pbgum@ooomail.at" },
                    { "6", 0, "123", "momo@mailbird.op", true, false, false, null, "Momonosuke", "MOMO@MAILBIRD.OP", "MOMO@MAILBIRD.OP", "03954d41-9eaa-4411-8a1d-67b1b5d39ab6", null, false, "123", "Kozuki", false, "momo@mailbird.op" },
                    { "7", 0, "123", "grifi@midmail.ml", true, false, false, null, "Griffith", "GRIFI@MIDMAIL.ML", "GRIFI@MIDMAIL.ML", "03954d41-9eaa-4411-8a1d-67b1b5d39ab6", null, false, "123", "White Falcon", false, "grifi@midmail.ml" },
                    { "c63447a0-24dd-4390-9914-2962d12fb40c", 0, "123", "gorbachov@gmail.com", true, false, false, null, "Mijail", "GORBACHOV@GMAIL.COM", "GORBACHOV@GMAIL.COM", "03954d41-9eaa-4411-8a1d-67b1b5d39ab6", null, false, "123", "Gorbachov", false, "gorbachov@gmail.com" },
                    { "c8795973-e00b-44fb-9701-a9fb61f7ac82", 0, "123", "jesus@mail.re", true, false, false, null, "Jesus", "JESUS@MAIL.RE", "JESUS@MAIL.RE", "03954d41-9eaa-4411-8a1d-67b1b5d39ab6", null, false, "123", "Nazareno", false, "jesus@mail.re" }
                });

            migrationBuilder.InsertData(
                table: "FacilityTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Dentist" });

            migrationBuilder.UpdateData(
                table: "OwnersRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Pilot");

            migrationBuilder.InsertData(
                table: "OwnersRole",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Co-Pilot" },
                    { 4, "Flight Attendant" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "ClientTypeId", "Country", "UserId" },
                values: new object[,]
                {
                    { "4", 1, "Japan", "4" },
                    { "5", 2, "Candy Kingdom", "5" },
                    { "6", 3, "Wano", "6" },
                    { "7", 1, "Falconia", "7" },
                    { "c63447a0-24dd-4390-9914-2962d12fb40c", 2, "URSS", "c63447a0-24dd-4390-9914-2962d12fb40c" },
                    { "c8795973-e00b-44fb-9701-a9fb61f7ac82", 3, "Roman Empire", "c8795973-e00b-44fb-9701-a9fb61f7ac82" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Address", "AirportId", "Description", "FacilityTypeId", "ImgUrl", "IsDeleted", "Name" },
                values: new object[] { 8, "p sherman 42 wallaby way sydney", 2, "A dentist with a fish bowl.", 8, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663766/ovqroknpskzubu6g3trd.jpg", false, "Dentist" });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "Id", "CargoCapacity", "Classification", "CrewCount", "IsDeleted", "OwnerId", "PassengerCapacity" },
                values: new object[,]
                {
                    { 1, 20000.0, "Commercial", 5, false, "4", 200 },
                    { 2, 5000.0, "Private", 2, false, "4", 10 },
                    { 3, 50000.0, "Cargo", 5, false, "5", 0 },
                    { 4, 15000.0, "Military", 10, false, "6", 50 },
                    { 5, 25000.0, "Commercial", 6, false, "7", 250 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: "c63447a0-24dd-4390-9914-2962d12fb40c");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: "c8795973-e00b-44fb-9701-a9fb61f7ac82");

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OwnersRole",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OwnersRole",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c63447a0-24dd-4390-9914-2962d12fb40c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8795973-e00b-44fb-9701-a9fb61f7ac82");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "FacilityTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DropColumn(
                name: "RepairCost",
                table: "FlightRepairs");

            migrationBuilder.CreateTable(
                name: "FlightServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightServices_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FlightServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "OwnersRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Captain");

            migrationBuilder.InsertData(
                table: "PlaneConditions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Good" },
                    { 3, "Fair" },
                    { 4, "Poor" },
                    { 5, "Bad" }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "RepairTypeId", "ServiceId" },
                values: new object[,]
                {
                    { 3, 1, 3 },
                    { 4, 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightServices_FlightId",
                table: "FlightServices",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightServices_ServiceId",
                table: "FlightServices",
                column: "ServiceId");
        }
    }
}
