using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImgPathToPropertyTBL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PropertyImgPath",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyImgPath",
                table: "Properties");
        }
    }
}
