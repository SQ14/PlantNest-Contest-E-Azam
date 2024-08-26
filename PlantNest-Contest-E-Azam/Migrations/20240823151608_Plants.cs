using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantNest_Contest_E_Azam.Migrations
{
    /// <inheritdoc />
    public partial class Plants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_plant",
                columns: table => new
                {
                    plant_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plant_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plant_species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plant_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    plant_discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    plant_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plant_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_plant", x => x.plant_id);
                    table.ForeignKey(
                        name: "FK_tbl_plant_tbl_category_category_id",
                        column: x => x.category_id,
                        principalTable: "tbl_category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_plant_category_id",
                table: "tbl_plant",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_plant");
        }
    }
}
