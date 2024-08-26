using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantNest_Contest_E_Azam.Migrations
{
    /// <inheritdoc />
    public partial class Orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_order",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cart_id = table.Column<int>(type: "int", nullable: false),
                    order_quantity = table.Column<int>(type: "int", nullable: false),
                    order_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    order_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_order", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_tbl_order_tbl_cart_cart_id",
                        column: x => x.cart_id,
                        principalTable: "tbl_cart",
                        principalColumn: "cart_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_order_cart_id",
                table: "tbl_order",
                column: "cart_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_order");
        }
    }
}
