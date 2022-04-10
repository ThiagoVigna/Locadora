using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class Tabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.RenameTable(
                name: "Todos",
                newName: "Locacoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locacoes",
                table: "Locacoes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    ClassificacaoIndicativa = table.Column<int>(type: "INTEGER", nullable: false),
                    Lancamento = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locacoes",
                table: "Locacoes");

            migrationBuilder.RenameTable(
                name: "Locacoes",
                newName: "Todos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "Id");
        }
    }
}
