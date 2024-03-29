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
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirportId = table.Column<int>(type: "int", nullable: false),
                    FacilityTypeId = table.Column<int>(type: "int", nullable: false)
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
                    OwnerRoleId = table.Column<int>(type: "int", nullable: false)
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
                    Price = table.Column<double>(type: "float", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                table: "Planes",
                columns: new[] { "Id", "CargoCapacity", "Classification", "CrewCount", "OwnerId", "PassengerCapacity" },
                values: new object[,]
                {
                    { 1, 20000.0, "Commercial", 5, "684c656f-0424-4c06-9a2e-92bac4f3d9bd", 200 },
                    { 2, 5000.0, "Private", 2, "8e03cd57-c768-4a44-b174-45a450441b44", 10 },
                    { 3, 50000.0, "Cargo", 5, "029eaca6-cb0f-408b-b6c4-c51cea6e5441", 0 },
                    { 4, 15000.0, "Military", 10, "029eaca6-cb0f-408b-b6c4-c51cea6e5441", 50 },
                    { 5, 25000.0, "Commercial", 6, "684c656f-0424-4c06-9a2e-92bac4f3d9bd", 250 }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Address", "AirportId", "FacilityTypeId", "ImgUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Street 15, 14077", 1, 1, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663766/womxzvcwlkmgebmkzypa.webp", "Breadway" },
                    { 2, "Street 20, 23078", 1, 2, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663767/yej7dkz5v8nwp1cemm5l.jpg", "AMXWorkshop" },
                    { 3, "Street 5, 66778", 1, 3, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663768/gt2fpdjqrqoqqrvrltm5.jpg", "Tascon" },
                    { 4, "Street 1, 45556", 1, 4, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663767/kbxqsrk2vu5xstwxrvxr.jpg", "ArtesaniaDominicana" },
                    { 5, "Street 20, 23078", 1, 5, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663767/i4tka668odgaukhbiigd.jpg", "CambioExchange" },
                    { 6, "Street 7, 12078", 2, 6, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663766/ryd91lefb0jsz0sfgr8x.jpg", "Ryu" },
                    { 7, "Street 1, 16078", 2, 7, "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711663766/ovqroknpskzubu6g3trd.jpg", "Tagliatella" }
                });

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
                name: "PlaneConditions");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "OwnersRole");

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
        }
    }
}
