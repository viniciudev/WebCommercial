using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class addcolunasfin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "tb_financial",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdSale",
                table: "tb_financial",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdSalesman",
                table: "tb_financial",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdService",
                table: "tb_financial",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_financial_IdProduct",
                table: "tb_financial",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_tb_financial_IdSale",
                table: "tb_financial",
                column: "IdSale");

            migrationBuilder.CreateIndex(
                name: "IX_tb_financial_IdSalesman",
                table: "tb_financial",
                column: "IdSalesman");

            migrationBuilder.CreateIndex(
                name: "IX_tb_financial_IdService",
                table: "tb_financial",
                column: "IdService");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_financial_tb_product_IdProduct",
                table: "tb_financial",
                column: "IdProduct",
                principalTable: "tb_product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_financial_tb_sale_IdSale",
                table: "tb_financial",
                column: "IdSale",
                principalTable: "tb_sale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_financial_tb_salesman_IdSalesman",
                table: "tb_financial",
                column: "IdSalesman",
                principalTable: "tb_salesman",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_financial_tb_ServiceProvided_IdService",
                table: "tb_financial",
                column: "IdService",
                principalTable: "tb_ServiceProvided",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_financial_tb_product_IdProduct",
                table: "tb_financial");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_financial_tb_sale_IdSale",
                table: "tb_financial");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_financial_tb_salesman_IdSalesman",
                table: "tb_financial");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_financial_tb_ServiceProvided_IdService",
                table: "tb_financial");

            migrationBuilder.DropIndex(
                name: "IX_tb_financial_IdProduct",
                table: "tb_financial");

            migrationBuilder.DropIndex(
                name: "IX_tb_financial_IdSale",
                table: "tb_financial");

            migrationBuilder.DropIndex(
                name: "IX_tb_financial_IdSalesman",
                table: "tb_financial");

            migrationBuilder.DropIndex(
                name: "IX_tb_financial_IdService",
                table: "tb_financial");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "tb_financial");

            migrationBuilder.DropColumn(
                name: "IdSale",
                table: "tb_financial");

            migrationBuilder.DropColumn(
                name: "IdSalesman",
                table: "tb_financial");

            migrationBuilder.DropColumn(
                name: "IdService",
                table: "tb_financial");
        }
    }
}
