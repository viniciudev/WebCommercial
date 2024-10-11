using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class alterbudget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdClient",
                table: "tb_budget",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdClient",
                table: "tb_budget");
        }
    }
}
