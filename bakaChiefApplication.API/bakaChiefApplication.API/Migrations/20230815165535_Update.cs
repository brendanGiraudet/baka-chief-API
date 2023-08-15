using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientNutrimentTypes",
                table: "IngredientNutrimentTypes");

            migrationBuilder.DropIndex(
                name: "IX_IngredientNutrimentTypes_IngredientId",
                table: "IngredientNutrimentTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "IngredientNutrimentTypes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientNutrimentTypes",
                table: "IngredientNutrimentTypes",
                columns: new[] { "IngredientId", "NutrimentTypeId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientNutrimentTypes",
                table: "IngredientNutrimentTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "IngredientNutrimentTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientNutrimentTypes",
                table: "IngredientNutrimentTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientNutrimentTypes_IngredientId",
                table: "IngredientNutrimentTypes",
                column: "IngredientId");
        }
    }
}
