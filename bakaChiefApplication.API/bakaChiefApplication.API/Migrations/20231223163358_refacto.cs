using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class refacto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientNutriment");

            migrationBuilder.DropTable(
                name: "RecipIngredients");

            migrationBuilder.DropTable(
                name: "Nutriments");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.CreateTable(
                name: "RecipProductInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ProductInfocode = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    MeasureUnit = table.Column<string>(type: "TEXT", nullable: false),
                    RecipId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipProductInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipProductInfos_Products_ProductInfocode",
                        column: x => x.ProductInfocode,
                        principalTable: "Products",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipProductInfos_Recips_RecipId",
                        column: x => x.RecipId,
                        principalTable: "Recips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipProductInfos_ProductInfocode",
                table: "RecipProductInfos",
                column: "ProductInfocode");

            migrationBuilder.CreateIndex(
                name: "IX_RecipProductInfos_RecipId",
                table: "RecipProductInfos",
                column: "RecipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipProductInfos");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nutriments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutriments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipIngredients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    IngredientId = table.Column<string>(type: "TEXT", nullable: false),
                    RecipId = table.Column<string>(type: "TEXT", nullable: true),
                    MeasureUnit = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipIngredients_Recips_RecipId",
                        column: x => x.RecipId,
                        principalTable: "Recips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_RecipIngredients_IngredientId",
                table: "RecipIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipIngredients_RecipId",
                table: "RecipIngredients",
                column: "RecipId");
        }
    }
}
