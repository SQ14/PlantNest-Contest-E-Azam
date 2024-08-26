using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantNest_Contest_E_Azam.Migrations
{
    /// <inheritdoc />
    public partial class cartupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "accessory_quantity",
                table: "tbl_cart",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "plant_quantity",
                table: "tbl_cart",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "accessory_quantity",
                table: "tbl_cart");

            migrationBuilder.DropColumn(
                name: "plant_quantity",
                table: "tbl_cart");
        }
    }
}
