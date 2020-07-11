using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRest.Migrations
{
    public partial class CreacionCancionLista_reproduccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_cancion = table.Column<string>(nullable: true),
                    AlbumId = table.Column<int>(nullable: false),
                    ArtistaId = table.Column<int>(nullable: false),
                    GeneroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listas_Reproduccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_lista = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listas_Reproduccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CancionLista_reproduccion",
                columns: table => new
                {
                    Lista_reproduccionId = table.Column<int>(nullable: false),
                    CancionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancionLista_reproduccion", x => new { x.CancionId, x.Lista_reproduccionId });
                    table.ForeignKey(
                        name: "FK_CancionLista_reproduccion_Canciones_CancionId",
                        column: x => x.CancionId,
                        principalTable: "Canciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CancionLista_reproduccion_Listas_Reproduccion_Lista_reproduc~",
                        column: x => x.Lista_reproduccionId,
                        principalTable: "Listas_Reproduccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CancionLista_reproduccion_Lista_reproduccionId",
                table: "CancionLista_reproduccion",
                column: "Lista_reproduccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancionLista_reproduccion");

            migrationBuilder.DropTable(
                name: "Canciones");

            migrationBuilder.DropTable(
                name: "Listas_Reproduccion");
        }
    }
}
