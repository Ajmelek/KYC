using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STB_everywhere.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnNumeroTelephone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EtatCivil",
                table: "Client",
                newName: "etatcivil");

            migrationBuilder.AddColumn<string>(
                name: "EtatCivil",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EtatCivil",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "etatcivil",
                table: "Client",
                newName: "EtatCivil");
        }
    }
}
