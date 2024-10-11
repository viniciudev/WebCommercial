using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class altercolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "tb_budgetItems");

            migrationBuilder.RenameColumn(
                name: "IdService",
                table: "tb_budgetItems",
                newName: "IdItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdItem",
                table: "tb_budgetItems",
                newName: "IdService");

            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "tb_budgetItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
