using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightRegistration.Migrations
{
    public partial class UpdateTbls1DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PassengerAppointmentModel",
                columns: table => new
                {
                    PassengerAppointmentModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassengerModelId = table.Column<int>(nullable: false),
                    AppointmentModelId = table.Column<int>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerAppointmentModel", x => x.PassengerAppointmentModelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassengerAppointmentModel");
        }
    }
}
