using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class newstables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "tb_client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tb_product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_product_tb_company_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "tb_company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_ServiceProvided",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ServiceProvided", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_ServiceProvided_tb_company_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "tb_company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "tb_user",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "");

            migrationBuilder.CreateIndex(
                name: "IX_tb_client_IdCompany",
                table: "tb_client",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_IdCompany",
                table: "tb_product",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ServiceProvided_IdCompany",
                table: "tb_ServiceProvided",
                column: "IdCompany");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_client_tb_company_IdCompany",
                table: "tb_client",
                column: "IdCompany",
                principalTable: "tb_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_client_tb_company_IdCompany",
                table: "tb_client");

            migrationBuilder.DropTable(
                name: "tb_product");

            migrationBuilder.DropTable(
                name: "tb_ServiceProvided");

            migrationBuilder.DropIndex(
                name: "IX_tb_client_IdCompany",
                table: "tb_client");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "tb_client");

            migrationBuilder.UpdateData(
                table: "tb_user",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "Admin");
        }
    }
}
