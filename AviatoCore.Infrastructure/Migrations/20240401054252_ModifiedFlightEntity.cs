using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AviatoCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedFlightEntity : Migration
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

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Flights",
                newName: "NeedsCheck");

            migrationBuilder.AddColumn<int>(
                name: "PlaneConditionId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                table: "Flights",
                columns: new[] { "Id", "AirportId", "ArrivalTime", "DepartureTime", "NeedsCheck", "OwnerRoleId", "PlaneConditionId", "PlaneId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 1, 1, 42, 52, 266, DateTimeKind.Local).AddTicks(7692), new DateTime(2024, 4, 1, 3, 42, 52, 266, DateTimeKind.Local).AddTicks(7784), false, 1, 1, 1 },
                    { 2, 1, new DateTime(2024, 4, 1, 4, 42, 52, 266, DateTimeKind.Local).AddTicks(7792), new DateTime(2024, 4, 1, 6, 42, 52, 266, DateTimeKind.Local).AddTicks(7793), true, 2, 2, 2 },
                    { 3, 1, new DateTime(2024, 4, 1, 7, 42, 52, 266, DateTimeKind.Local).AddTicks(7796), new DateTime(2024, 4, 1, 9, 42, 52, 266, DateTimeKind.Local).AddTicks(7797), false, 1, 3, 3 },
                    { 4, 2, new DateTime(2024, 4, 1, 10, 42, 52, 266, DateTimeKind.Local).AddTicks(7800), new DateTime(2024, 4, 1, 12, 42, 52, 266, DateTimeKind.Local).AddTicks(7801), true, 2, 4, 4 },
                    { 5, 5, new DateTime(2024, 4, 1, 13, 42, 52, 266, DateTimeKind.Local).AddTicks(7804), new DateTime(2024, 4, 1, 15, 42, 52, 266, DateTimeKind.Local).AddTicks(7805), false, 1, 5, 5 },
                    { 6, 1, new DateTime(2024, 4, 1, 16, 42, 52, 266, DateTimeKind.Local).AddTicks(7807), new DateTime(2024, 4, 1, 18, 42, 52, 266, DateTimeKind.Local).AddTicks(7809), true, 2, 1, 1 },
                    { 7, 1, new DateTime(2024, 4, 1, 19, 42, 52, 266, DateTimeKind.Local).AddTicks(7811), new DateTime(2024, 4, 1, 21, 42, 52, 266, DateTimeKind.Local).AddTicks(7812), false, 1, 2, 2 },
                    { 8, 2, new DateTime(2024, 4, 1, 22, 42, 52, 266, DateTimeKind.Local).AddTicks(7814), new DateTime(2024, 4, 2, 0, 42, 52, 266, DateTimeKind.Local).AddTicks(7816), true, 2, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_UserId",
                table: "Workers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneConditionId",
                table: "Flights",
                column: "PlaneConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_PlaneConditions_PlaneConditionId",
                table: "Flights",
                column: "PlaneConditionId",
                principalTable: "PlaneConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_PlaneConditions_PlaneConditionId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Workers_UserId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PlaneConditionId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UserId",
                table: "Clients");

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OwnersRole",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OwnersRole",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.DropColumn(
                name: "PlaneConditionId",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "NeedsCheck",
                table: "Flights",
                newName: "IsDeleted");

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
