using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addtablesClosures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_closures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LongInit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatInit = table.Column<int>(type: "int", nullable: false),
                    DateInit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    LongFinal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatFinal = table.Column<int>(type: "int", nullable: false),
                    DateFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdSalesman = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_closures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_closures_tb_salesman_IdSalesman",
                        column: x => x.IdSalesman,
                        principalTable: "tb_salesman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_closuresDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<int>(type: "int", nullable: false),
                    IdClosures = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_closuresDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_closuresDetail_tb_closures_IdClosures",
                        column: x => x.IdClosures,
                        principalTable: "tb_closures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_closures_IdSalesman",
                table: "tb_closures",
                column: "IdSalesman");

            migrationBuilder.CreateIndex(
                name: "IX_tb_closuresDetail_IdClosures",
                table: "tb_closuresDetail",
                column: "IdClosures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_closuresDetail");

            migrationBuilder.DropTable(
                name: "tb_closures");
        }
    }
}
