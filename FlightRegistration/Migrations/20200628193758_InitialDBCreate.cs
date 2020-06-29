using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightRegistration.Migrations
{
    public partial class InitialDBCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PassengerModel",
                columns: table => new
                {
                    PassengerModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Weight = table.Column<float>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerModel", x => x.PassengerModelId);
                });

            migrationBuilder.CreateTable(
                name: "TokenManager",
                columns: table => new
                {
                    TokenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenKey = table.Column<string>(nullable: true),
                    IssuedOn = table.Column<DateTime>(nullable: false),
                    ExpiresOn = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenManager", x => x.TokenID);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Contact_No = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UserTypeID = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentModel",
                columns: table => new
                {
                    AppointmentModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    PassengerModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentModel", x => x.AppointmentModelId);
                    table.ForeignKey(
                        name: "FK_AppointmentModel_PassengerModel_PassengerModelId",
                        column: x => x.PassengerModelId,
                        principalTable: "PassengerModel",
                        principalColumn: "PassengerModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentModel_PassengerModelId",
                table: "AppointmentModel",
                column: "PassengerModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentModel");

            migrationBuilder.DropTable(
                name: "TokenManager");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "PassengerModel");
        }
    }
}
