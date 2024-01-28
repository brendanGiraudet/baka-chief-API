using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bakaChiefApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class add_reciptype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipTypeId",
                table: "Recips",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecipTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recips_RecipTypeId",
                table: "Recips",
                column: "RecipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recips_RecipTypes_RecipTypeId",
                table: "Recips",
                column: "RecipTypeId",
                principalTable: "RecipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recips_RecipTypes_RecipTypeId",
                table: "Recips");

            migrationBuilder.DropTable(
                name: "RecipTypes");

            migrationBuilder.DropIndex(
                name: "IX_Recips_RecipTypeId",
                table: "Recips");

            migrationBuilder.DropColumn(
                name: "RecipTypeId",
                table: "Recips");
        }
    }
}
