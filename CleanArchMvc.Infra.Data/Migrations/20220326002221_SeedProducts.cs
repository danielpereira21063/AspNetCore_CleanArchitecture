using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = string.Empty;
            sql += "INSERT INTO Products\n";
            sql += "(Name, Description, Price, Stock, Image, CategoryId) VALUES\n";
            sql += "('Caderno espiral', '100 folhas', 7.45,50, 'caderno1.jpg', 1),\n";
            sql += "('Estojo escolar', 'Estojo escolar cinza', 5.65,70, 'estojo1.jpg', 1),\n";
            sql += "('Borracha escolar', 'Borracha branca pequena', 3.25,80, 'borracha1.jpg', 1),\n";
            sql += "('Calculadora escolar', 'Calculadora simples', 15.39,20, 'calculadora1.jpg', 2);\n";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
