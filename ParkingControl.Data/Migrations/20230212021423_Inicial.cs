using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingControl.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_vaga_estacionamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    col_placa_veiculo = table.Column<string>(type: "TEXT", nullable: false),
                    col_tempo_entrada_veiculo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    col_tempo_saida_veiculo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    col_status_vaga = table.Column<int>(type: "INTEGER", nullable: false),
                    col_tempo_total_estacionamento = table.Column<TimeSpan>(type: "time", nullable: false),
                    col_preco_estacionamento = table.Column<decimal>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vaga_estacionamento", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_vaga_estacionamento");
        }
    }
}
