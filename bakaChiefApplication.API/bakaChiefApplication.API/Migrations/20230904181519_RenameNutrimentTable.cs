using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class RenameNutrimentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientNutrimentType");

            migrationBuilder.DropTable(
                name: "NutrimentTypes");

            migrationBuilder.CreateTable(
                name: "Nutriments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutriments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientNutriment",
                columns: table => new
                {
                    IngredientsId = table.Column<string>(type: "TEXT", nullable: false),
                    NutrimentsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientNutriment", x => new { x.IngredientsId, x.NutrimentsId });
                    table.ForeignKey(
                        name: "FK_IngredientNutriment_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientNutriment_Nutriments_NutrimentsId",
                        column: x => x.NutrimentsId,
                        principalTable: "Nutriments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientNutriment_NutrimentsId",
                table: "IngredientNutriment",
                column: "NutrimentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientNutriment");

            migrationBuilder.DropTable(
                name: "Nutriments");

            migrationBuilder.CreateTable(
                name: "NutrimentTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutrimentTypes", x => x.Id);
                });

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
    }
}
