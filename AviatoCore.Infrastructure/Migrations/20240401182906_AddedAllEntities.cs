using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AviatoCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAllEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Workers_UserId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UserId",
                table: "Clients");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Airports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "FacilityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnersRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnersRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaneConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoCapacity = table.Column<double>(type: "float", nullable: false),
                    CrewCount = table.Column<int>(type: "int", nullable: false),
                    PassengerCapacity = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planes_Clients_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepairTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirportId = table.Column<int>(type: "int", nullable: false),
                    FacilityTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facilities_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facilities_FacilityTypes_FacilityTypeId",
                        column: x => x.FacilityTypeId,
                        principalTable: "FacilityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AirportId = table.Column<int>(type: "int", nullable: false),
                    PlaneId = table.Column<int>(type: "int", nullable: false),
                    OwnerRoleId = table.Column<int>(type: "int", nullable: false),
                    NeedsCheck = table.Column<bool>(type: "bit", nullable: false),
                    PlaneConditionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_OwnersRole_OwnerRoleId",
                        column: x => x.OwnerRoleId,
                        principalTable: "OwnersRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_PlaneConditions_PlaneConditionId",
                        column: x => x.PlaneConditionId,
                        principalTable: "PlaneConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Planes_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "Planes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientServices_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCost = table.Column<double>(type: "float", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    RepairTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repairs_RepairTypes_RepairTypeId",
                        column: x => x.RepairTypeId,
                        principalTable: "RepairTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repairs_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightRepairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    RepairId = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightRepairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightRepairs_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FlightRepairs_Repairs_RepairId",
                        column: x => x.RepairId,
                        principalTable: "Repairs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RepairDependencies",
                columns: table => new
                {
                    PlaneConditionId = table.Column<int>(type: "int", nullable: false),
                    RepairAId = table.Column<int>(type: "int", nullable: false),
                    RepairBId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairDependencies", x => new { x.PlaneConditionId, x.RepairAId, x.RepairBId });
                    table.ForeignKey(
                        name: "FK_RepairDependencies_PlaneConditions_PlaneConditionId",
                        column: x => x.PlaneConditionId,
                        principalTable: "PlaneConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairDependencies_Repairs_RepairAId",
                        column: x => x.RepairAId,
                        principalTable: "Repairs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepairDependencies_Repairs_RepairBId",
                        column: x => x.RepairBId,
                        principalTable: "Repairs",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: false);

            migrationBuilder.InsertData(
                table: "FacilityTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cafeteria" },
                    { 2, "Workshop" },
                    { 3, "Clothing Store" },
                    { 4, "Gift Shop" },
                    { 5, "Currency exchange office" },
                    { 6, "Sushi Bar" },
                    { 7, "Restaurant" }
                });

            migrationBuilder.InsertData(
                table: "OwnersRole",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Passenger" },
                    { 2, "Captain" }
                });

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

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Address", "AirportId", "Description", "FacilityTypeId", "ImgUrl", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "Street 15, 14077", 1, "A popular bakery offering a variety of breads and pastries.", 1, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663766/womxzvcwlkmgebmkzypa.webp", false, "Breadway" },
                    { 2, "Street 20, 23078", 1, "A workshop specializing in aircraft maintenance and repair.", 2, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663767/yej7dkz5v8nwp1cemm5l.jpg", false, "AMXWorkshop" },
                    { 3, "Street 5, 66778", 1, "A high-end shoe store offering a variety of stylish footwear.", 3, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663768/gt2fpdjqrqoqqrvrltm5.jpg", false, "Tascon" },
                    { 4, "Street 1, 45556", 1, "A store offering a wide range of handcrafted goods from local artisans.", 4, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663767/kbxqsrk2vu5xstwxrvxr.jpg", false, "ArtesaniaDominicana" },
                    { 5, "Street 20, 23078", 1, "A currency exchange service offering competitive rates.", 5, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663767/i4tka668odgaukhbiigd.jpg", false, "CambioExchange" },
                    { 6, "Street 7, 12078", 2, "A Japanese restaurant offering a variety of sushi and other traditional dishes.", 6, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663766/ryd91lefb0jsz0sfgr8x.jpg", false, "Ryu" },
                    { 7, "Street 1, 16078", 2, "An Italian restaurant offering a variety of pasta dishes and pizzas.", 7, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663766/ovqroknpskzubu6g3trd.jpg", false, "Tagliatella" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "FacilityId", "ImgUrl", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Delicious blend of gourmet coffee", 1, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png", false, "Gourmet Coffee Blend", 2.9900000000000002 },
                    { 2, "Freshly baked pastries made with love", 1, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png", false, "Freshly Baked Pastries", 3.4900000000000002 },
                    { 3, "Professional aircraft engine tune-up service", 2, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png", false, "Aircraft Engine Tune-Up", 499.99000000000001 },
                    { 4, "Thorough avionic systems check for your aircraft", 2, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png", false, "Avionic Systems Check", 299.99000000000001 },
                    { 5, "Custom-tailored pilot uniforms for a perfect fit", 3, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png", false, "Tailored Pilot Uniforms", 199.99000000000001 },
                    { 6, "Stylish collection of flight jackets", 3, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png", false, "Flight Jackets Collection", 149.99000000000001 },
                    { 7, "Beautiful handcrafted model aircraft", 4, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png", false, "Handcrafted Model Aircraft", 59.990000000000002 },
                    { 8, "Unique aviation memorabilia for collectors", 4, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png", false, "Aviation Memorabilia", 39.990000000000002 },
                    { 9, "Convenient foreign currency conversion service", 5, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png", false, "Foreign Currency Conversion", 0.98999999999999999 },
                    { 10, "Secure traveler's cheque issuance service", 5, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png", false, "Traveler's Cheque Issuance", 1.99 },
                    { 11, "Fresh and delicious sashimi selection", 6, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png", false, "Sashimi Selection", 18.989999999999998 },
                    { 12, "Exquisite signature sushi rolls", 6, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png", false, "Signature Sushi Rolls", 15.99 },
                    { 13, "Authentic Italian pasta dishes", 7, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png", false, "Authentic Italian Pasta Selection", 12.99 },
                    { 14, "Delicious gourmet pizza delivered to your location", 7, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png", false, "Gourmet Pizza Delivery Service", 15.99 }
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
                name: "IX_Workers_UserId",
                table: "Workers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ClientId",
                table: "ClientServices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ServiceId",
                table: "ClientServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_AirportId",
                table: "Facilities",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_FacilityTypeId",
                table: "Facilities",
                column: "FacilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightRepairs_FlightId",
                table: "FlightRepairs",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightRepairs_RepairId",
                table: "FlightRepairs",
                column: "RepairId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportId",
                table: "Flights",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_OwnerRoleId",
                table: "Flights",
                column: "OwnerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneConditionId",
                table: "Flights",
                column: "PlaneConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightServices_FlightId",
                table: "FlightServices",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightServices_ServiceId",
                table: "FlightServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_OwnerId",
                table: "Planes",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairDependencies_RepairAId",
                table: "RepairDependencies",
                column: "RepairAId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairDependencies_RepairBId",
                table: "RepairDependencies",
                column: "RepairBId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_RepairTypeId",
                table: "Repairs",
                column: "RepairTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_ServiceId",
                table: "Repairs",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ClientId",
                table: "Reviews",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ServiceId",
                table: "Reviews",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_FacilityId",
                table: "Services",
                column: "FacilityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientServices");

            migrationBuilder.DropTable(
                name: "FlightRepairs");

            migrationBuilder.DropTable(
                name: "FlightServices");

            migrationBuilder.DropTable(
                name: "RepairDependencies");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "OwnersRole");

            migrationBuilder.DropTable(
                name: "PlaneConditions");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "RepairTypes");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "FacilityTypes");

            migrationBuilder.DropIndex(
                name: "IX_Workers_UserId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Airports");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_UserId",
                table: "Workers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");
        }
    }
}
