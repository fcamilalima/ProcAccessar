using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcAccessar.Migrations
{
    public partial class PopularMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO tbProcesso (Codigo, Titulo, Descricao, DataCriacao, CategoriaId) VALUES (102, 'AÇÃO DE EXECUÇÃO', 'AÇÃO DE EXECUÇÃO por quantia certa contra ADONIAS FRANÇA', '2021/01/11', 3)");
            migrationBuilder.Sql("INSERT INTO tbProcesso (Codigo, Titulo, Descricao, DataCriacao, CategoriaId) VALUES (103, 'AÇÃO DE RECONHECIMENTO', 'AÇÃO DE RECONHECIMENTO DE PATERNIDADE E GUARDA COM PEDIDO DE TUTELA DE URGÊNCIA', '2021/08/23', 2)");
            migrationBuilder.Sql("INSERT INTO tbProcesso (Codigo, Titulo, Descricao, DataCriacao, CategoriaId) VALUES (112, 'AÇÃO DE RESSARCIMENTO', 'CONTESTAÇÃO À AÇÃO DE RESSARCIMENTO POR DANOS MATERIAIS E MORAIS', '2021/05/25', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM tbCategoria");
            migrationBuilder.Sql("DELETE FROM tbProcesso");
        }
    }
}
