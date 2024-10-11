using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class addcolumnservicesprovision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "tb_serviceProvision",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "tb_serviceProvision");
        }
    }
}
