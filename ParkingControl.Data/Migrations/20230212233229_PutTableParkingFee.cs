using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingControl.Data.Migrations
{
    public partial class PutTableParkingFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_taxa_estacionamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InitialValidityDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FinalValidityDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FullHourPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    AditionalHourPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_taxa_estacionamento", x => x.Id);
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
        }
    }
}
