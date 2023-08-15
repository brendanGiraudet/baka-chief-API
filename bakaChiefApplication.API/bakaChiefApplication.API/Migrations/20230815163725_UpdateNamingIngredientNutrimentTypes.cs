using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNamingIngredientNutrimentTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientNutrimentType_Ingredients_IngredientId",
                table: "IngredientNutrimentType");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientNutrimentType_NutrimentTypes_NutrimentTypeId",
                table: "IngredientNutrimentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientNutrimentType",
                table: "IngredientNutrimentType");

            migrationBuilder.RenameTable(
                name: "IngredientNutrimentType",
                newName: "IngredientNutrimentTypes");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientNutrimentType_NutrimentTypeId",
                table: "IngredientNutrimentTypes",
                newName: "IX_IngredientNutrimentTypes_NutrimentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientNutrimentType_IngredientId",
                table: "IngredientNutrimentTypes",
                newName: "IX_IngredientNutrimentTypes_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientNutrimentTypes",
                table: "IngredientNutrimentTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientNutrimentTypes_Ingredients_IngredientId",
                table: "IngredientNutrimentTypes",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientNutrimentTypes_NutrimentTypes_NutrimentTypeId",
                table: "IngredientNutrimentTypes",
                column: "NutrimentTypeId",
                principalTable: "NutrimentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientNutrimentTypes_Ingredients_IngredientId",
                table: "IngredientNutrimentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientNutrimentTypes_NutrimentTypes_NutrimentTypeId",
                table: "IngredientNutrimentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientNutrimentTypes",
                table: "IngredientNutrimentTypes");

            migrationBuilder.RenameTable(
                name: "IngredientNutrimentTypes",
                newName: "IngredientNutrimentType");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientNutrimentTypes_NutrimentTypeId",
                table: "IngredientNutrimentType",
                newName: "IX_IngredientNutrimentType_NutrimentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientNutrimentTypes_IngredientId",
                table: "IngredientNutrimentType",
                newName: "IX_IngredientNutrimentType_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientNutrimentType",
                table: "IngredientNutrimentType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientNutrimentType_Ingredients_IngredientId",
                table: "IngredientNutrimentType",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientNutrimentType_NutrimentTypes_NutrimentTypeId",
                table: "IngredientNutrimentType",
                column: "NutrimentTypeId",
                principalTable: "NutrimentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
