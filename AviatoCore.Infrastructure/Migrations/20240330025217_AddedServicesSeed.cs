using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AviatoCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedServicesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "FacilityId", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, false, "Gourmet Coffee Blend", 2.9900000000000002 },
                    { 2, 1, false, "Freshly Baked Pastries", 3.4900000000000002 },
                    { 3, 2, false, "Aircraft Engine Tune-Up", 499.99000000000001 },
                    { 4, 2, false, "Avionic Systems Check", 299.99000000000001 },
                    { 5, 3, false, "Tailored Pilot Uniforms", 199.99000000000001 },
                    { 6, 3, false, "Flight Jackets Collection", 149.99000000000001 },
                    { 7, 4, false, "Handcrafted Model Aircraft", 59.990000000000002 },
                    { 8, 4, false, "Aviation Memorabilia", 39.990000000000002 },
                    { 9, 5, false, "Foreign Currency Conversion", 0.98999999999999999 },
                    { 10, 5, false, "Traveler's Cheque Issuance", 1.99 },
                    { 11, 6, false, "Sashimi Selection", 18.989999999999998 },
                    { 12, 6, false, "Signature Sushi Rolls", 15.99 },
                    { 13, 7, false, "Authentic Italian Pasta Selection", 12.99 },
                    { 14, 7, false, "Gourmet Pizza Delivery Service", 15.99 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14);
        }
    }
}
