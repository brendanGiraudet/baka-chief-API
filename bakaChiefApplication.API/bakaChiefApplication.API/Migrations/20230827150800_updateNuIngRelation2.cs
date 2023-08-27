using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class updateNuIngRelation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientNutrimentTypes");

            migrationBuilder.AlterColumn<string>(
                name: "SvgImage",
                table: "NutrimentTypes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "IngredientNutrimentType",
                columns: table => new
                {
                    IngredientsId = table.Column<string>(type: "TEXT", nullable: false),
                    NutrimentTypesId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientNutrimentType", x => new { x.IngredientsId, x.NutrimentTypesId });
                    table.ForeignKey(
                        name: "FK_IngredientNutrimentType_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientNutrimentType_NutrimentTypes_NutrimentTypesId",
                        column: x => x.NutrimentTypesId,
                        principalTable: "NutrimentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientNutrimentType_NutrimentTypesId",
                table: "IngredientNutrimentType",
                column: "NutrimentTypesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientNutrimentType");

            migrationBuilder.AlterColumn<string>(
                name: "SvgImage",
                table: "NutrimentTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "IngredientNutrimentTypes",
                columns: table => new
                {
                    IngredientId = table.Column<string>(type: "TEXT", nullable: false),
                    NutrimentTypeId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientNutrimentTypes", x => new { x.IngredientId, x.NutrimentTypeId });
                    table.ForeignKey(
                        name: "FK_IngredientNutrimentTypes_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientNutrimentTypes_NutrimentTypes_NutrimentTypeId",
                        column: x => x.NutrimentTypeId,
                        principalTable: "NutrimentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientNutrimentTypes_NutrimentTypeId",
                table: "IngredientNutrimentTypes",
                column: "NutrimentTypeId");
        }
    }
}
