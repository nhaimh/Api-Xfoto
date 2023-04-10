using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BnDapi.Migrations
{
    /// <inheritdoc />
    public partial class initSanPham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPhamImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageA = table.Column<string>(type: "text", nullable: true),
                    ImageB = table.Column<string>(type: "text", nullable: true),
                    SanPhamId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhamImage_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamImage_SanPhamId",
                table: "SanPhamImage",
                column: "SanPhamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPhamImage");

            migrationBuilder.DropTable(
                name: "SanPham");
        }
    }
}
