using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class tablesbudgetbudgetitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_budget",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCompany = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_budget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_budget_tb_company_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "tb_company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_budgetItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBudget = table.Column<int>(type: "int", nullable: false),
                    TypeItem = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    IdService = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_budgetItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_budgetItems_tb_budget_IdBudget",
                        column: x => x.IdBudget,
                        principalTable: "tb_budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_budget_IdCompany",
                table: "tb_budget",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_tb_budgetItems_IdBudget",
                table: "tb_budgetItems",
                column: "IdBudget");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_budgetItems");

            migrationBuilder.DropTable(
                name: "tb_budget");
        }
    }
}
