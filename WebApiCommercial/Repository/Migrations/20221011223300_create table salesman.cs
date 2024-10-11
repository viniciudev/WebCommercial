using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class createtablesalesman : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_salesman",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameSate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<int>(type: "int", nullable: false),
                    IdCompany = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_salesman", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_salesman_tb_company_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "tb_company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_salesman_IdCompany",
                table: "tb_salesman",
                column: "IdCompany");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_salesman");
        }
    }
}
