using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class add_selectedreciphistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RecipId",
                table: "RecipSteps",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "IngredientNutriments",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SelectedRecipHistories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedRecipHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipSelectedRecipHistory",
                columns: table => new
                {
                    RecipsId = table.Column<string>(type: "TEXT", nullable: false),
                    SelectedRecipHistoriesId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipSelectedRecipHistory", x => new { x.RecipsId, x.SelectedRecipHistoriesId });
                    table.ForeignKey(
                        name: "FK_RecipSelectedRecipHistory_Recips_RecipsId",
                        column: x => x.RecipsId,
                        principalTable: "Recips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipSelectedRecipHistory_SelectedRecipHistories_SelectedRecipHistoriesId",
                        column: x => x.SelectedRecipHistoriesId,
                        principalTable: "SelectedRecipHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipSelectedRecipHistory_SelectedRecipHistoriesId",
                table: "RecipSelectedRecipHistory",
                column: "SelectedRecipHistoriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipSelectedRecipHistory");

            migrationBuilder.DropTable(
                name: "SelectedRecipHistories");

            migrationBuilder.AlterColumn<string>(
                name: "RecipId",
                table: "RecipSteps",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "IngredientNutriments",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
