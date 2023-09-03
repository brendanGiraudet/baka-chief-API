using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SvgImage",
                table: "NutrimentTypes",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "SvgImage",
                table: "Ingredients",
                newName: "ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "NutrimentTypes",
                newName: "SvgImage");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Ingredients",
                newName: "SvgImage");
        }
    }
}
