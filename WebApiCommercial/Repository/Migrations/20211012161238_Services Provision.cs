using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class ServicesProvision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_budget_tb_company_IdCompany",
                table: "tb_budget");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_budgetItems_tb_budget_IdBudget",
                table: "tb_budgetItems");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_client_tb_company_IdCompany",
                table: "tb_client");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_descriptionFiles_tb_company_idCompany",
                table: "tb_descriptionFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_file_tb_descriptionFiles_IdDescriptionFiles",
                table: "tb_file");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_product_tb_company_IdCompany",
                table: "tb_product");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_ServiceProvided_tb_company_IdCompany",
                table: "tb_ServiceProvided");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_tb_company_IdCompany",
                table: "tb_user");

            migrationBuilder.CreateTable(
                name: "tb_serviceProvision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBudget = table.Column<int>(type: "int", nullable: true),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdCompany = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_serviceProvision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_serviceProvision_tb_budget_IdBudget",
                        column: x => x.IdBudget,
                        principalTable: "tb_budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_serviceProvision_tb_client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "tb_client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_serviceProvision_tb_company_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "tb_company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_servicesProvisionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdServiceProvision = table.Column<int>(type: "int", nullable: false),
                    TypeItem = table.Column<int>(type: "int", nullable: false),
                    IdItem = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_servicesProvisionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_servicesProvisionItems_tb_serviceProvision_IdServiceProvision",
                        column: x => x.IdServiceProvision,
                        principalTable: "tb_serviceProvision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_serviceProvision_IdBudget",
                table: "tb_serviceProvision",
                column: "IdBudget");

            migrationBuilder.CreateIndex(
                name: "IX_tb_serviceProvision_IdClient",
                table: "tb_serviceProvision",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_tb_serviceProvision_IdCompany",
                table: "tb_serviceProvision",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_tb_servicesProvisionItems_IdServiceProvision",
                table: "tb_servicesProvisionItems",
                column: "IdServiceProvision");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_budget_tb_company_IdCompany",
                table: "tb_budget",
                column: "IdCompany",
                principalTable: "tb_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_budgetItems_tb_budget_IdBudget",
                table: "tb_budgetItems",
                column: "IdBudget",
                principalTable: "tb_budget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_client_tb_company_IdCompany",
                table: "tb_client",
                column: "IdCompany",
                principalTable: "tb_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_descriptionFiles_tb_company_idCompany",
                table: "tb_descriptionFiles",
                column: "idCompany",
                principalTable: "tb_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_file_tb_descriptionFiles_IdDescriptionFiles",
                table: "tb_file",
                column: "IdDescriptionFiles",
                principalTable: "tb_descriptionFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_product_tb_company_IdCompany",
                table: "tb_product",
                column: "IdCompany",
                principalTable: "tb_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_ServiceProvided_tb_company_IdCompany",
                table: "tb_ServiceProvided",
                column: "IdCompany",
                principalTable: "tb_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_tb_company_IdCompany",
                table: "tb_user",
                column: "IdCompany",
                principalTable: "tb_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_budget_tb_company_IdCompany",
                table: "tb_budget");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_budgetItems_tb_budget_IdBudget",
                table: "tb_budgetItems");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_client_tb_company_IdCompany",
                table: "tb_client");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_descriptionFiles_tb_company_idCompany",
                table: "tb_descriptionFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_file_tb_descriptionFiles_IdDescriptionFiles",
                table: "tb_file");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_product_tb_company_IdCompany",
                table: "tb_product");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_ServiceProvided_tb_company_IdCompany",
                table: "tb_ServiceProvided");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_tb_company_IdCompany",
                table: "tb_user");

            migrationBuilder.DropTable(
                name: "tb_servicesProvisionItems");

            migrationBuilder.DropTable(
                name: "tb_serviceProvision");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_budget_tb_company_IdCompany",
                table: "tb_budget",
                column: "IdCompany",
                principalTable: "tb_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_budgetItems_tb_budget_IdBudget",
                table: "tb_budgetItems",
                column: "IdBudget",
                principalTable: "tb_budget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_client_tb_company_IdCompany",
                table: "tb_client",
                column: "IdCompany",
                principalTable: "tb_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_descriptionFiles_tb_company_idCompany",
                table: "tb_descriptionFiles",
                column: "idCompany",
                principalTable: "tb_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_file_tb_descriptionFiles_IdDescriptionFiles",
                table: "tb_file",
                column: "IdDescriptionFiles",
                principalTable: "tb_descriptionFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_product_tb_company_IdCompany",
                table: "tb_product",
                column: "IdCompany",
                principalTable: "tb_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_ServiceProvided_tb_company_IdCompany",
                table: "tb_ServiceProvided",
                column: "IdCompany",
                principalTable: "tb_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_tb_company_IdCompany",
                table: "tb_user",
                column: "IdCompany",
                principalTable: "tb_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
