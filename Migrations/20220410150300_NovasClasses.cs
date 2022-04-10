using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class NovasClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "Done",
                table: "Todos",
                newName: "Id_Filme");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Todos",
                newName: "DataLocacao");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDevolucao",
                table: "Todos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id_Cliente",
                table: "Todos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDevolucao",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Id_Cliente",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "Id_Filme",
                table: "Todos",
                newName: "Done");

            migrationBuilder.RenameColumn(
                name: "DataLocacao",
                table: "Todos",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Todos",
                type: "TEXT",
                nullable: true);
        }
    }
}
