using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addnewcollunsSharedCommission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "tb_sharedCommission",
                newName: "RecurringAmount");

            migrationBuilder.AddColumn<bool>(
                name: "EnableSharedCommission",
                table: "tb_sharedCommission",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnableSharedCommission",
                table: "tb_sharedCommission");

            migrationBuilder.RenameColumn(
                name: "RecurringAmount",
                table: "tb_sharedCommission",
                newName: "Status");
        }
    }
}
