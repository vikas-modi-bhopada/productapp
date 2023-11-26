using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApi.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cart");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
