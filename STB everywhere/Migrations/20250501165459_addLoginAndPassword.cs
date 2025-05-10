using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STB_everywhere.Migrations
{
    /// <inheritdoc />
    public partial class addLoginAndPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Motif",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Objetrelation",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Motif",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Objetrelation",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Client");
        }
    }
}
