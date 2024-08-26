using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantNest_Contest_E_Azam.Migrations
{
    /// <inheritdoc />
    public partial class Accessories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_accessory",
                columns: table => new
                {
                    accessory_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accessory_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accessory_purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accessory_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    accessory_image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_accessory", x => x.accessory_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_accessory");
        }
    }
}
