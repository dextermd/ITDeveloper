using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dextermd.ITDeveloper.Data.Migrations
{
    public partial class Add_Field_Id_PacientStatus_In_Pacient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PacientStatus",
                table: "PacientStatus");

            migrationBuilder.RenameTable(
                name: "PacientStatus",
                newName: "PacientStatus");

            migrationBuilder.AddColumn<Guid>(
                name: "PacientStatusId",
                table: "Pacient",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b00166cd-7b1c-436a-9a92-4f3d31448d5b"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PacientStatus",
                table: "PacientStatus",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pacient_PacientStatusId",
                table: "Pacient",
                column: "PacientStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacient_PacientStatus_PacientStatusId",
                table: "Pacient",
                column: "PacientStatusId",
                principalTable: "PacientStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacient_PacientStatus_PacientStatusId",
                table: "Pacient");

            migrationBuilder.DropIndex(
                name: "IX_Pacient_PacientStatusId",
                table: "Pacient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PacientStatus",
                table: "PacientStatus");

            migrationBuilder.DropColumn(
                name: "PacientStatusId",
                table: "Pacient");

            migrationBuilder.RenameTable(
                name: "PacientStatus",
                newName: "PacientStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PacientStatus",
                table: "PacientStatus",
                column: "Id");
        }
    }
}
