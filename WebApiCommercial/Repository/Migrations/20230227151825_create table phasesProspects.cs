using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class createtablephasesProspects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_phasesProspects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProspects = table.Column<int>(type: "int", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_phasesProspects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_phasesProspects_tb_prospects_IdProspects",
                        column: x => x.IdProspects,
                        principalTable: "tb_prospects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_phasesProspects_IdProspects",
                table: "tb_phasesProspects",
                column: "IdProspects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_phasesProspects");
        }
    }
}
