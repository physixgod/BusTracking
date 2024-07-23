using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Societe_SocieteId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Societe",
                table: "Societe");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Societe",
                newName: "Societes");

            migrationBuilder.RenameIndex(
                name: "IX_User_SocieteId",
                table: "Users",
                newName: "IX_Users_SocieteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Login");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Societes",
                table: "Societes",
                column: "SocieteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Societes_SocieteId",
                table: "Users",
                column: "SocieteId",
                principalTable: "Societes",
                principalColumn: "SocieteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Societes_SocieteId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Societes",
                table: "Societes");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Societes",
                newName: "Societe");

            migrationBuilder.RenameIndex(
                name: "IX_Users_SocieteId",
                table: "User",
                newName: "IX_User_SocieteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Login");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Societe",
                table: "Societe",
                column: "SocieteId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Societe_SocieteId",
                table: "User",
                column: "SocieteId",
                principalTable: "Societe",
                principalColumn: "SocieteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
