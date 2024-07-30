using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Rfid = table.Column<int>(type: "int", nullable: false),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gouvernement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointedBus = table.Column<bool>(type: "bit", nullable: true),
                    PointedIn = table.Column<bool>(type: "bit", nullable: true),
                    PointedOut = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Rfid);
                });

            migrationBuilder.CreateTable(
                name: "Societes",
                columns: table => new
                {
                    SocieteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societes", x => x.SocieteId);
                });

            migrationBuilder.CreateTable(
                name: "TrackingEvent",
                columns: table => new
                {
                    TrackingEventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceID = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Rfid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingEvent", x => x.TrackingEventID);
                    table.ForeignKey(
                        name: "FK_TrackingEvent_Employees_Rfid",
                        column: x => x.Rfid,
                        principalTable: "Employees",
                        principalColumn: "Rfid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocieteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Login);
                    table.ForeignKey(
                        name: "FK_Users_Societes_SocieteId",
                        column: x => x.SocieteId,
                        principalTable: "Societes",
                        principalColumn: "SocieteId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackingEvent_Rfid",
                table: "TrackingEvent",
                column: "Rfid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SocieteId",
                table: "Users",
                column: "SocieteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackingEvent");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Societes");
        }
    }
}
