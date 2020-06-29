using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightRegistration.Migrations
{
    public partial class UpdateTblsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentModel_PassengerModel_PassengerModelId",
                table: "AppointmentModel");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentModel_PassengerModelId",
                table: "AppointmentModel");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "AppointmentModel");

            migrationBuilder.DropColumn(
                name: "PassengerModelId",
                table: "AppointmentModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "AppointmentModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PassengerModelId",
                table: "AppointmentModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentModel_PassengerModelId",
                table: "AppointmentModel",
                column: "PassengerModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentModel_PassengerModel_PassengerModelId",
                table: "AppointmentModel",
                column: "PassengerModelId",
                principalTable: "PassengerModel",
                principalColumn: "PassengerModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
