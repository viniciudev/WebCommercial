using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AddTablessaleandsaleitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdSeller = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_sale_tb_client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "tb_client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_sale_tb_company_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "tb_company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_sale_tb_salesman_IdSeller",
                        column: x => x.IdSeller,
                        principalTable: "tb_salesman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_saleItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    InclusionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdSale = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: true),
                    IdService = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_saleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_saleItems_tb_product_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "tb_product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_saleItems_tb_sale_IdSale",
                        column: x => x.IdSale,
                        principalTable: "tb_sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_saleItems_tb_ServiceProvided_IdService",
                        column: x => x.IdService,
                        principalTable: "tb_ServiceProvided",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_sale_IdClient",
                table: "tb_sale",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sale_IdCompany",
                table: "tb_sale",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sale_IdSeller",
                table: "tb_sale",
                column: "IdSeller");

            migrationBuilder.CreateIndex(
                name: "IX_tb_saleItems_IdProduct",
                table: "tb_saleItems",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_tb_saleItems_IdSale",
                table: "tb_saleItems",
                column: "IdSale");

            migrationBuilder.CreateIndex(
                name: "IX_tb_saleItems_IdService",
                table: "tb_saleItems",
                column: "IdService");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_saleItems");

            migrationBuilder.DropTable(
                name: "tb_sale");
        }
    }
}
