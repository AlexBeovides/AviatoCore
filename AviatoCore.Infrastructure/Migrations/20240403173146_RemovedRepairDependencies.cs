using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AviatoCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRepairDependencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_PlaneConditions_PlaneConditionId",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "ClientServices");

            migrationBuilder.DropTable(
                name: "RepairDependencies");

            migrationBuilder.DropTable(
                name: "PlaneConditions");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PlaneConditionId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "PlaneConditionId",
                table: "Flights");

            migrationBuilder.CreateTable(
                name: "ServiceRequest",
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
                    table.PrimaryKey("PK_ServiceRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRequest_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequest_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/docdba0ow/image/upload/v1712007305/Gourmet%20Coffe.jpg");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/docdba0ow/image/upload/v1712007423/Freshly%20baked%20pastries.jpg");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/docdba0ow/image/upload/v1712007651/Engine%20Tune%20Up.jpg");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/docdba0ow/image/upload/v1712007703/Avionic%20System%20Check.jpg");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/docdba0ow/image/upload/v1712007891/Tailored%20Pilot%20uniforms.jpg");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/docdba0ow/image/upload/v1712008050/Flight%20Jackets.webp");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/docdba0ow/image/upload/v1712008286/Handcrafted%20Aircraft%20Models.webp");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/docdba0ow/image/upload/v1712008436/Aviation%20Memorabilia.webp");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/docdba0ow/image/upload/v1712008543/Foreign%20Currency%20Exchange.jpg");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/docdba0ow/image/upload/v1712008693/Traveler%20Cheque.webp");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/docdba0ow/image/upload/v1712009126/Sashimi%20Selection.jpg");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/docdba0ow/image/upload/v1712009133/Sushi%20Rolls.jpg");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/docdba0ow/image/upload/v1712009258/Italian%20pasta.webp");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/docdba0ow/image/upload/v1712009458/Gourmet%20Pizza.jpg");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_ClientId",
                table: "ServiceRequest",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_ServiceId",
                table: "ServiceRequest",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRequest");

            migrationBuilder.AddColumn<int>(
                name: "PlaneConditionId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ClientServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dp9wcmorr/image/upload/v1711962325/ee5y2czkx2nigv4qeasj.png");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneConditionId",
                table: "Flights",
                column: "PlaneConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ClientId",
                table: "ClientServices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ServiceId",
                table: "ClientServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairDependencies_RepairAId",
                table: "RepairDependencies",
                column: "RepairAId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairDependencies_RepairBId",
                table: "RepairDependencies",
                column: "RepairBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_PlaneConditions_PlaneConditionId",
                table: "Flights",
                column: "PlaneConditionId",
                principalTable: "PlaneConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
