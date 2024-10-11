using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class addtb_commission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CostCenter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCenter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdService = table.Column<int>(type: "int", nullable: true),
                    ServiceProvidedId = table.Column<int>(type: "int", nullable: true),
                    IdProduct = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    IdSalesman = table.Column<int>(type: "int", nullable: false),
                    SalesmanId = table.Column<int>(type: "int", nullable: true),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CommissionDay = table.Column<int>(type: "int", nullable: false),
                    TypeDay = table.Column<int>(type: "int", nullable: false),
                    IdCostCenter = table.Column<int>(type: "int", nullable: false),
                    CostCenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commission_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commission_tb_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tb_product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commission_tb_salesman_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "tb_salesman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commission_tb_ServiceProvided_ServiceProvidedId",
                        column: x => x.ServiceProvidedId,
                        principalTable: "tb_ServiceProvided",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commission");

            migrationBuilder.DropTable(
                name: "CostCenter");
        }
    }
}
