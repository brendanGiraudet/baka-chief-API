using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class add_measureunit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasureUnit",
                table: "RecipIngredients");

            migrationBuilder.AddColumn<string>(
                name: "MeasureUnitId",
                table: "RecipIngredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MeasureUnits",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureUnits", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipIngredients_MeasureUnitId",
                table: "RecipIngredients",
                column: "MeasureUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipIngredients_MeasureUnits_MeasureUnitId",
                table: "RecipIngredients",
                column: "MeasureUnitId",
                principalTable: "MeasureUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipIngredients_MeasureUnits_MeasureUnitId",
                table: "RecipIngredients");

            migrationBuilder.DropTable(
                name: "MeasureUnits");

            migrationBuilder.DropIndex(
                name: "IX_RecipIngredients_MeasureUnitId",
                table: "RecipIngredients");

            migrationBuilder.DropColumn(
                name: "MeasureUnitId",
                table: "RecipIngredients");

            migrationBuilder.AddColumn<string>(
                name: "MeasureUnit",
                table: "RecipIngredients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
