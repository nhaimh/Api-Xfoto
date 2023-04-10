using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BnDapi.Migrations
{
    /// <inheritdoc />
    public partial class updateintiDuAn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageB",
                table: "Duans",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageB",
                table: "Duans");
        }
    }
}
