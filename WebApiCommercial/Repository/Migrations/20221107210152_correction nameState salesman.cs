using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class correctionnameStatesalesman : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameSate",
                table: "tb_salesman",
                newName: "NameState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameState",
                table: "tb_salesman",
                newName: "NameSate");
        }
    }
}
