using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class acee3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeP",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeP",
                table: "Users");
        }
    }
}
