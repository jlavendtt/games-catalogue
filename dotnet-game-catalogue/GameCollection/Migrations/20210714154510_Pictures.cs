using Microsoft.EntityFrameworkCore.Migrations;

namespace GameCollection.Migrations
{
    public partial class Pictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserRatings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pic",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserRatings");

            migrationBuilder.DropColumn(
                name: "Pic",
                table: "Games");
        }
    }
}
