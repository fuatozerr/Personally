using Microsoft.EntityFrameworkCore.Migrations;

namespace Personally.DataAccess.Migrations
{
    public partial class DeletedItemNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Notes",
                nullable: false,
                defaultValue: 0);
        }
    }
}
