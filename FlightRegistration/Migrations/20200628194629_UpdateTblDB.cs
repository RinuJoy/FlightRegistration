using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightRegistration.Migrations
{
    public partial class UpdateTblDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "UserDetails",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "UserDetails",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "UserDetails");
        }
    }
}
