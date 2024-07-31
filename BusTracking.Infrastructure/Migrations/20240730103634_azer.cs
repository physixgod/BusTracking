using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class azer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeImageUrl",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeImageUrl",
                table: "Employees");
        }
    }
}
