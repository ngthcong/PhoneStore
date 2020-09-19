using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneStore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "inv_em_id",
                table: "invoice",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "inv_em_id",
                table: "invoice");
        }
    }
}
