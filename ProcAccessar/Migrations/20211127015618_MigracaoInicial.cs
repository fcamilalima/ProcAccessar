using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcAccessar.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbProcesso",
                columns: table => new
                {
                    ProcessoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProcesso", x => x.ProcessoId);
                });

            migrationBuilder.CreateTable(
                name: "tbCategoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategoria", x => x.CategoriaId);
                    table.ForeignKey(
                        name: "FK_tbCategoria_tbProcesso_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "tbProcesso",
                        principalColumn: "ProcessoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbCategoria_ProcessoId",
                table: "tbCategoria",
                column: "ProcessoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCategoria");

            migrationBuilder.DropTable(
                name: "tbProcesso");
        }
    }
}
