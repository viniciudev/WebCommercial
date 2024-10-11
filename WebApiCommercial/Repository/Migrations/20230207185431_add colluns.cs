using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class addcolluns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeItem",
                table: "tb_saleItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeItem",
                table: "tb_saleItems");
        }
    }
}
