using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightRegistration.Migrations
{
    public partial class UpdateTbls2DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PassengerModel",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PassengerModel");
        }
    }
}
