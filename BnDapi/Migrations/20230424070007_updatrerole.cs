using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BnDapi.Migrations
{
    /// <inheritdoc />
    public partial class updatrerole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Roles\" (\"Id\", \"Name\", \"NormalizedName\", \"ConcurrencyStamp\") VALUES ('', 'Editor', 'EDITOR', 'ee76e0dc-57ad-4bf4-85a8-40d3a0a70883');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
