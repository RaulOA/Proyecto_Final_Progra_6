using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Final_Progra_6.Server.Migrations
{
    /// <inheritdoc />
    public partial class Migracion20250814001219 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercent",
                table: "AppProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "AppProducts");
        }
    }
}
