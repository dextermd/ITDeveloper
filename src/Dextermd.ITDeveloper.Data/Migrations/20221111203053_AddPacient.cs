using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dextermd.ITDeveloper.Data.Migrations
{
    public partial class AddPacient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HospitalizationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypePacient = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RgOrgan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RgIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacient", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacient");
        }
    }
}
