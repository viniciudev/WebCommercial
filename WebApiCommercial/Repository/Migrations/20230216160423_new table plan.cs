using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class newtableplan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "tb_planCompany",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPayment",
                table: "tb_planCompany",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "tb_planCompany",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_company",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tb_planCompany_IdCompany",
                table: "tb_planCompany",
                column: "IdCompany",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_planCompany_tb_company_IdCompany",
                table: "tb_planCompany",
                column: "IdCompany",
                principalTable: "tb_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_planCompany_tb_company_IdCompany",
                table: "tb_planCompany");

            migrationBuilder.DropIndex(
                name: "IX_tb_planCompany_IdCompany",
                table: "tb_planCompany");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "tb_planCompany");

            migrationBuilder.DropColumn(
                name: "LastPayment",
                table: "tb_planCompany");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tb_planCompany");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_company");
        }
    }
}
