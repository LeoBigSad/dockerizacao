using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarefa5.Data.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class DataNascimentoParaDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataNascimento",
                table: "Pessoa",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Pessoa",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
