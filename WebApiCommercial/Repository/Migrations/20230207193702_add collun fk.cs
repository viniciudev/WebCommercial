using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class addcollunfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdSaleItems",
                table: "tb_financial",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_financial_IdSaleItems",
                table: "tb_financial",
                column: "IdSaleItems");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_financial_tb_saleItems_IdSaleItems",
                table: "tb_financial",
                column: "IdSaleItems",
                principalTable: "tb_saleItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_financial_tb_saleItems_IdSaleItems",
                table: "tb_financial");

            migrationBuilder.DropIndex(
                name: "IX_tb_financial_IdSaleItems",
                table: "tb_financial");

            migrationBuilder.DropColumn(
                name: "IdSaleItems",
                table: "tb_financial");
        }
    }
}
