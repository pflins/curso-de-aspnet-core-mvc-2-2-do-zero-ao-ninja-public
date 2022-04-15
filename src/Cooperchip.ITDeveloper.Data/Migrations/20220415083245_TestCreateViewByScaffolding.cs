using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cooperchip.ITDeveloper.Data.Migrations
{
    public partial class TestCreateViewByScaffolding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PacienteTeste",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(90)", nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(type: "varchar(90)", nullable: true),
                    TipoPaciente = table.Column<int>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    Rg = table.Column<string>(type: "varchar(90)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteTeste", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacienteTeste");
        }
    }
}
