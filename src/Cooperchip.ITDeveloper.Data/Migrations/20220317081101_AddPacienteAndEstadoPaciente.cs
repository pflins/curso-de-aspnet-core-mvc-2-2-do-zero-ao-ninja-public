using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cooperchip.ITDeveloper.Data.Migrations
{
    public partial class AddPacienteAndEstadoPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoPaciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPaciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EstadoPacienteId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DataInternacao = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Cpf = table.Column<string>(nullable: true),
                    TipoPaciente = table.Column<int>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    Rg = table.Column<string>(nullable: true),
                    RgOrgao = table.Column<string>(nullable: true),
                    RgDataEmissao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_EstadoPaciente_EstadoPacienteId",
                        column: x => x.EstadoPacienteId,
                        principalTable: "EstadoPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_EstadoPacienteId",
                table: "Pacientes",
                column: "EstadoPacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "EstadoPaciente");
        }
    }
}
