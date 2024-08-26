using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantNest_Contest_E_Azam.Migrations
{
    /// <inheritdoc />
    public partial class Reviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_review",
                columns: table => new
                {
                    review_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    plant_id = table.Column<int>(type: "int", nullable: true),
                    accessory_id = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    review_comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    review_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_review", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_tbl_review_tbl_accessory_accessory_id",
                        column: x => x.accessory_id,
                        principalTable: "tbl_accessory",
                        principalColumn: "accessory_id");
                    table.ForeignKey(
                        name: "FK_tbl_review_tbl_plant_plant_id",
                        column: x => x.plant_id,
                        principalTable: "tbl_plant",
                        principalColumn: "plant_id");
                    table.ForeignKey(
                        name: "FK_tbl_review_tbl_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_review_accessory_id",
                table: "tbl_review",
                column: "accessory_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_review_plant_id",
                table: "tbl_review",
                column: "plant_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_review_user_id",
                table: "tbl_review",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_review");
        }
    }
}
