using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AviatoCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsDeletedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Planes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Flights",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Airports");
        }
    }
}
