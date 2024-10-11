using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class alters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_user",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "CellPhone",
                table: "tb_user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "tb_user",
                columns: new[] { "Id", "BirthDate", "CellPhone", "Email", "IdCompany", "Name", "Password", "Role" },
                values: new object[] { 1, new DateTime(1983, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@padrao.com.br", 1, "Admin", "", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_user",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "tb_user");

            migrationBuilder.InsertData(
                table: "tb_user",
                columns: new[] { "Id", "BirthDate", "Email", "IdCompany", "Name", "Password", "Role" },
                values: new object[] { 1, new DateTime(1983, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@padrao.com.br", 1, "Admin", "", null });
        }
    }
}
