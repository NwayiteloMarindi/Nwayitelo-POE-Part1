using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Race_Day.Migrations
{
    /// <inheritdoc />
    public partial class inititialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    UserAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAccountEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAccountPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAccountRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAccountPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.UserAccountId);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "participant",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantDOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participant", x => x.ParticipantId);
                });

            migrationBuilder.CreateTable(
                name: "race_Events",
                columns: table => new
                {
                    Race_EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    Race_EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Race_EventDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Race_EventStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_race_Events", x => x.Race_EventId);
                });

            migrationBuilder.CreateTable(
                name: "races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Race_EventId = table.Column<int>(type: "int", nullable: false),
                    Race_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Race_Winner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Race_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Race_distance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Race_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Race_Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "registrations",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Race_EventId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    ParticipantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registrations", x => x.RegistrationId);
                });

            migrationBuilder.CreateTable(
                name: "results",
                columns: table => new
                {
                    ResultsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    ResultsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultsPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultsTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultsStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_results", x => x.ResultsId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "participant");

            migrationBuilder.DropTable(
                name: "race_Events");

            migrationBuilder.DropTable(
                name: "races");

            migrationBuilder.DropTable(
                name: "registrations");

            migrationBuilder.DropTable(
                name: "results");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
