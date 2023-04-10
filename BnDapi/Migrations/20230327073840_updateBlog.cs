using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BnDapi.Migrations
{
    /// <inheritdoc />
    public partial class updateBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Blog",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Blog");
        }
    }
}
