using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRElation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IngredientId",
                table: "NutrimentTypes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NutrimentTypes_IngredientId",
                table: "NutrimentTypes",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_NutrimentTypes_Ingredients_IngredientId",
                table: "NutrimentTypes",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NutrimentTypes_Ingredients_IngredientId",
                table: "NutrimentTypes");

            migrationBuilder.DropIndex(
                name: "IX_NutrimentTypes_IngredientId",
                table: "NutrimentTypes");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "NutrimentTypes");
        }
    }
}
