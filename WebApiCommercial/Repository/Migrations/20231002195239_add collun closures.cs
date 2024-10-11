using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addcollunclosures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "kilometerTraveled2",
                table: "tb_closures",
                newName: "Odometer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Odometer",
                table: "tb_closures",
                newName: "kilometerTraveled2");
        }
    }
}
