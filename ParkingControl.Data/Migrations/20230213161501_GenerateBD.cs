using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingControl.Data.Migrations
{
    public partial class GenerateBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_taxa_estacionamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InitialValidityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalValidityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullHourPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AditionalHourPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_taxa_estacionamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_vaga_estacionamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    col_placa_veiculo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    col_tempo_entrada_veiculo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    col_tempo_saida_veiculo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    col_status_vaga = table.Column<int>(type: "int", nullable: false),
                    col_tempo_total_estacionamento = table.Column<TimeSpan>(type: "time", nullable: false),
                    col_preco_estacionamento = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vaga_estacionamento", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tb_taxa_estacionamento",
                columns: new[] { "Id", "AditionalHourPrice", "FinalValidityDate", "FullHourPrice", "InitialValidityDate" },
                values: new object[] { 1, 1.00m, new DateTime(2023, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), 2.00m, new DateTime(2023, 1, 1, 0, 0, 1, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_taxa_estacionamento");

            migrationBuilder.DropTable(
                name: "tb_vaga_estacionamento");
        }
    }
}
