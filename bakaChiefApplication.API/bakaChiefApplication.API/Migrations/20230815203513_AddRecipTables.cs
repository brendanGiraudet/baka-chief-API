using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recips",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PersonsNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageFilePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipIngredients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    IngredientId = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    MeasureUnit = table.Column<string>(type: "TEXT", nullable: false),
                    RecipId = table.Column<string>(type: "TEXT", nullable: false)
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
                name: "RecipSteps",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    RecipId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipSteps_Recips_RecipId",
                        column: x => x.RecipId,
                        principalTable: "Recips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipIngredients_IngredientId",
                table: "RecipIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipIngredients_RecipId",
                table: "RecipIngredients",
                column: "RecipId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipSteps_RecipId",
                table: "RecipSteps",
                column: "RecipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipIngredients");

            migrationBuilder.DropTable(
                name: "RecipSteps");

            migrationBuilder.DropTable(
                name: "Recips");
        }
    }
}
