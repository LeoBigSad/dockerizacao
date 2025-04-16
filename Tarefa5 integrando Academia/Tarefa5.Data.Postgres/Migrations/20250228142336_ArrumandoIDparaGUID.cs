using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarefa5.Data.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class ArrumandoIDparaGUID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Endereco",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Endereco",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Endereco",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Endereco");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Endereco",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
