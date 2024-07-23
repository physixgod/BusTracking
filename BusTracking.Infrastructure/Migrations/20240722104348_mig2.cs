using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Societes_SocieteId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "SocieteId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Societes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Societes_SocieteId",
                table: "Users",
                column: "SocieteId",
                principalTable: "Societes",
                principalColumn: "SocieteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Societes_SocieteId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Societes");

            migrationBuilder.AlterColumn<int>(
                name: "SocieteId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Societes_SocieteId",
                table: "Users",
                column: "SocieteId",
                principalTable: "Societes",
                principalColumn: "SocieteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
