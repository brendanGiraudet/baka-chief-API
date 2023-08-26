using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSvgImageNutrimentType : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "RecipId",
                table: "RecipSteps",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "RecipId",
                table: "RecipIngredients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "SvgImage",
                table: "NutrimentTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipIngredients_Recips_RecipId",
                table: "RecipIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipSteps_Recips_RecipId",
                table: "RecipSteps");

            migrationBuilder.DropColumn(
                name: "SvgImage",
                table: "NutrimentTypes");

            migrationBuilder.AlterColumn<string>(
                name: "RecipId",
                table: "RecipSteps",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecipId",
                table: "RecipIngredients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

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
    }
}
