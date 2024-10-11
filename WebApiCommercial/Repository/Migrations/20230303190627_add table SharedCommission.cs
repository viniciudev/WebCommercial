using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addtableSharedCommission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_sharedCommission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSaleItems = table.Column<int>(type: "int", nullable: false),
                    IdSalesman = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CommissionDay = table.Column<int>(type: "int", nullable: false),
                    TypeDay = table.Column<int>(type: "int", nullable: false),
                    IdCostCenter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_sharedCommission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_sharedCommission_tb_costCenter_IdCostCenter",
                        column: x => x.IdCostCenter,
                        principalTable: "tb_costCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_sharedCommission_tb_saleItems_IdSaleItems",
                        column: x => x.IdSaleItems,
                        principalTable: "tb_saleItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_sharedCommission_tb_salesman_IdSalesman",
                        column: x => x.IdSalesman,
                        principalTable: "tb_salesman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_sharedCommission_IdCostCenter",
                table: "tb_sharedCommission",
                column: "IdCostCenter");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sharedCommission_IdSaleItems",
                table: "tb_sharedCommission",
                column: "IdSaleItems");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sharedCommission_IdSalesman",
                table: "tb_sharedCommission",
                column: "IdSalesman");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_sharedCommission");
        }
    }
}
