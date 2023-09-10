using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraintDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipIngredients_Recips_RecipId",
                table: "RecipIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipSteps_Recips_RecipId",
                table: "RecipSteps");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipIngredients_Recips_RecipId",
                table: "RecipIngredients",
                column: "RecipId",
                principalTable: "Recips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipSteps_Recips_RecipId",
                table: "RecipSteps",
                column: "RecipId",
                principalTable: "Recips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipIngredients_Recips_RecipId",
                table: "RecipIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipSteps_Recips_RecipId",
                table: "RecipSteps");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipIngredients_Recips_RecipId",
                table: "RecipIngredients",
                column: "RecipId",
                principalTable: "Recips",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipSteps_Recips_RecipId",
                table: "RecipSteps",
                column: "RecipId",
                principalTable: "Recips",
                principalColumn: "Id");
        }
    }
}
