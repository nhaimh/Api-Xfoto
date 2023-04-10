using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BnDapi.Migrations
{
    /// <inheritdoc />
    public partial class updateDuAndetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuAnImgae",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageA = table.Column<string>(type: "text", nullable: true),
                    ImageB = table.Column<string>(type: "text", nullable: true),
                    DuanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAnImgae", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuAnImgae_Duans_DuanId",
                        column: x => x.DuanId,
                        principalTable: "Duans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuAnImgae_DuanId",
                table: "DuAnImgae",
                column: "DuanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuAnImgae");
        }
    }
}
