using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcApi.Migrations
{
    /// <inheritdoc />
    public partial class FixedTypoCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreadtedAt",
                table: "Products",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Products",
                newName: "CreadtedAt");
        }
    }
}
