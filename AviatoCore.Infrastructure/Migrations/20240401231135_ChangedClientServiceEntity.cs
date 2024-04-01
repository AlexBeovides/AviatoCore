using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AviatoCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedClientServiceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ClientServices",
                schema: "dbo",
                newName: "ServiceRequest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ServiceRequest",
                schema: "dbo",
                newName: "ClientServices");
        }
    }
}
