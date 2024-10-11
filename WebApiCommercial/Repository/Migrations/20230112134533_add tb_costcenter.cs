using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class addtb_costcenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commission_CostCenter_CostCenterId",
                table: "Commission");

            migrationBuilder.DropForeignKey(
                name: "FK_Commission_tb_product_ProductId",
                table: "Commission");

            migrationBuilder.DropForeignKey(
                name: "FK_Commission_tb_salesman_SalesmanId",
                table: "Commission");

            migrationBuilder.DropForeignKey(
                name: "FK_Commission_tb_ServiceProvided_ServiceProvidedId",
                table: "Commission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CostCenter",
                table: "CostCenter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commission",
                table: "Commission");

            migrationBuilder.DropIndex(
                name: "IX_Commission_CostCenterId",
                table: "Commission");

            migrationBuilder.DropIndex(
                name: "IX_Commission_ProductId",
                table: "Commission");

            migrationBuilder.DropIndex(
                name: "IX_Commission_SalesmanId",
                table: "Commission");

            migrationBuilder.DropIndex(
                name: "IX_Commission_ServiceProvidedId",
                table: "Commission");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                table: "Commission");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Commission");

            migrationBuilder.DropColumn(
                name: "SalesmanId",
                table: "Commission");

            migrationBuilder.DropColumn(
                name: "ServiceProvidedId",
                table: "Commission");

            migrationBuilder.RenameTable(
                name: "CostCenter",
                newName: "tb_costCenter");

            migrationBuilder.RenameTable(
                name: "Commission",
                newName: "tb_commission");

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "tb_costCenter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_costCenter",
                table: "tb_costCenter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_commission",
                table: "tb_commission",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_costCenter_IdCompany",
                table: "tb_costCenter",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_tb_commission_IdCostCenter",
                table: "tb_commission",
                column: "IdCostCenter");

            migrationBuilder.CreateIndex(
                name: "IX_tb_commission_IdProduct",
                table: "tb_commission",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_tb_commission_IdSalesman",
                table: "tb_commission",
                column: "IdSalesman");

            migrationBuilder.CreateIndex(
                name: "IX_tb_commission_IdService",
                table: "tb_commission",
                column: "IdService");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_commission_tb_costCenter_IdCostCenter",
                table: "tb_commission",
                column: "IdCostCenter",
                principalTable: "tb_costCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_commission_tb_product_IdProduct",
                table: "tb_commission",
                column: "IdProduct",
                principalTable: "tb_product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_commission_tb_salesman_IdSalesman",
                table: "tb_commission",
                column: "IdSalesman",
                principalTable: "tb_salesman",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_commission_tb_ServiceProvided_IdService",
                table: "tb_commission",
                column: "IdService",
                principalTable: "tb_ServiceProvided",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_costCenter_tb_company_IdCompany",
                table: "tb_costCenter",
                column: "IdCompany",
                principalTable: "tb_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_commission_tb_costCenter_IdCostCenter",
                table: "tb_commission");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_commission_tb_product_IdProduct",
                table: "tb_commission");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_commission_tb_salesman_IdSalesman",
                table: "tb_commission");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_commission_tb_ServiceProvided_IdService",
                table: "tb_commission");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_costCenter_tb_company_IdCompany",
                table: "tb_costCenter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_costCenter",
                table: "tb_costCenter");

            migrationBuilder.DropIndex(
                name: "IX_tb_costCenter_IdCompany",
                table: "tb_costCenter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_commission",
                table: "tb_commission");

            migrationBuilder.DropIndex(
                name: "IX_tb_commission_IdCostCenter",
                table: "tb_commission");

            migrationBuilder.DropIndex(
                name: "IX_tb_commission_IdProduct",
                table: "tb_commission");

            migrationBuilder.DropIndex(
                name: "IX_tb_commission_IdSalesman",
                table: "tb_commission");

            migrationBuilder.DropIndex(
                name: "IX_tb_commission_IdService",
                table: "tb_commission");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "tb_costCenter");

            migrationBuilder.RenameTable(
                name: "tb_costCenter",
                newName: "CostCenter");

            migrationBuilder.RenameTable(
                name: "tb_commission",
                newName: "Commission");

            migrationBuilder.AddColumn<int>(
                name: "CostCenterId",
                table: "Commission",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Commission",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesmanId",
                table: "Commission",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceProvidedId",
                table: "Commission",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CostCenter",
                table: "CostCenter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commission",
                table: "Commission",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Commission_CostCenterId",
                table: "Commission",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Commission_ProductId",
                table: "Commission",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Commission_SalesmanId",
                table: "Commission",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Commission_ServiceProvidedId",
                table: "Commission",
                column: "ServiceProvidedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commission_CostCenter_CostCenterId",
                table: "Commission",
                column: "CostCenterId",
                principalTable: "CostCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commission_tb_product_ProductId",
                table: "Commission",
                column: "ProductId",
                principalTable: "tb_product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commission_tb_salesman_SalesmanId",
                table: "Commission",
                column: "SalesmanId",
                principalTable: "tb_salesman",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commission_tb_ServiceProvided_ServiceProvidedId",
                table: "Commission",
                column: "ServiceProvidedId",
                principalTable: "tb_ServiceProvided",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
