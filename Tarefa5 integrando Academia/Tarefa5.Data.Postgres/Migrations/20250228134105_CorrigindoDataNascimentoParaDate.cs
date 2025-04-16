using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarefa5.Data.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoDataNascimentoParaDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adiciona uma nova coluna temporária do tipo Date
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimentoTemp",
                table: "Pessoa",
                type: "date",
                nullable: true);

            // Converte os valores da coluna antiga "DataNascimento" para a nova coluna
            migrationBuilder.Sql("UPDATE \"Pessoa\" SET \"DataNascimentoTemp\" = TO_DATE(\"DataNascimento\", 'YYYY-MM-DD') WHERE \"DataNascimento\" ~ '^[0-9]{4}-[0-9]{2}-[0-9]{2}$';");

            // Remove a coluna antiga
            migrationBuilder.DropColumn(name: "DataNascimento", table: "Pessoa");

            // Renomeia a nova coluna para "DataNascimento"
            migrationBuilder.RenameColumn(name: "DataNascimentoTemp", table: "Pessoa", newName: "DataNascimento");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Pessoa",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");
        }
    }
}
