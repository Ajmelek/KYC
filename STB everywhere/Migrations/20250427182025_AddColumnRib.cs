using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STB_everywhere.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnRib : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "statutpro",
                table: "Client",
                newName: "StatutPro");

            migrationBuilder.RenameColumn(
                name: "secondenationalite",
                table: "Client",
                newName: "SecondeNationalite");

            migrationBuilder.RenameColumn(
                name: "rcin",
                table: "Client",
                newName: "RCin");

            migrationBuilder.RenameColumn(
                name: "paysnaissance",
                table: "Client",
                newName: "PaysNaissance");

            migrationBuilder.RenameColumn(
                name: "paysRelations",
                table: "Client",
                newName: "PaysRelations");

            migrationBuilder.RenameColumn(
                name: "nompere",
                table: "Client",
                newName: "NomPere");

            migrationBuilder.RenameColumn(
                name: "nommere",
                table: "Client",
                newName: "NomMere");

            migrationBuilder.RenameColumn(
                name: "mailprincipal",
                table: "Client",
                newName: "MailPrincipal");

            migrationBuilder.RenameColumn(
                name: "etatcivil",
                table: "Client",
                newName: "EtatCivil");

            migrationBuilder.RenameColumn(
                name: "deviseCompteReserved",
                table: "Client",
                newName: "DeviseCompteReserved");

            migrationBuilder.RenameColumn(
                name: "datenaissance",
                table: "Client",
                newName: "DateNaissance");

            migrationBuilder.RenameColumn(
                name: "datecin",
                table: "Client",
                newName: "DateCin");

            migrationBuilder.RenameColumn(
                name: "dateRDV",
                table: "Client",
                newName: "DateRdv");

            migrationBuilder.RenameColumn(
                name: "confidenceRate",
                table: "Client",
                newName: "ConfidenceRate");

            migrationBuilder.RenameColumn(
                name: "codepostal",
                table: "Client",
                newName: "CodePostal");

            migrationBuilder.RenameColumn(
                name: "clientautrebanque",
                table: "Client",
                newName: "ClientAutreBanque");

            migrationBuilder.RenameColumn(
                name: "agenceResidence",
                table: "Client",
                newName: "AgenceResidence");

            migrationBuilder.RenameColumn(
                name: "adresseLieuTravail",
                table: "Client",
                newName: "AdresseLieuTravail");

            migrationBuilder.RenameColumn(
                name: "adresseComplete",
                table: "Client",
                newName: "AdresseComplete");

            migrationBuilder.AddColumn<string>(
                name: "Rib",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rib",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "StatutPro",
                table: "Client",
                newName: "statutpro");

            migrationBuilder.RenameColumn(
                name: "SecondeNationalite",
                table: "Client",
                newName: "secondenationalite");

            migrationBuilder.RenameColumn(
                name: "RCin",
                table: "Client",
                newName: "rcin");

            migrationBuilder.RenameColumn(
                name: "PaysRelations",
                table: "Client",
                newName: "paysRelations");

            migrationBuilder.RenameColumn(
                name: "PaysNaissance",
                table: "Client",
                newName: "paysnaissance");

            migrationBuilder.RenameColumn(
                name: "NomPere",
                table: "Client",
                newName: "nompere");

            migrationBuilder.RenameColumn(
                name: "NomMere",
                table: "Client",
                newName: "nommere");

            migrationBuilder.RenameColumn(
                name: "MailPrincipal",
                table: "Client",
                newName: "mailprincipal");

            migrationBuilder.RenameColumn(
                name: "EtatCivil",
                table: "Client",
                newName: "etatcivil");

            migrationBuilder.RenameColumn(
                name: "DeviseCompteReserved",
                table: "Client",
                newName: "deviseCompteReserved");

            migrationBuilder.RenameColumn(
                name: "DateRdv",
                table: "Client",
                newName: "dateRDV");

            migrationBuilder.RenameColumn(
                name: "DateNaissance",
                table: "Client",
                newName: "datenaissance");

            migrationBuilder.RenameColumn(
                name: "DateCin",
                table: "Client",
                newName: "datecin");

            migrationBuilder.RenameColumn(
                name: "ConfidenceRate",
                table: "Client",
                newName: "confidenceRate");

            migrationBuilder.RenameColumn(
                name: "CodePostal",
                table: "Client",
                newName: "codepostal");

            migrationBuilder.RenameColumn(
                name: "ClientAutreBanque",
                table: "Client",
                newName: "clientautrebanque");

            migrationBuilder.RenameColumn(
                name: "AgenceResidence",
                table: "Client",
                newName: "agenceResidence");

            migrationBuilder.RenameColumn(
                name: "AdresseLieuTravail",
                table: "Client",
                newName: "adresseLieuTravail");

            migrationBuilder.RenameColumn(
                name: "AdresseComplete",
                table: "Client",
                newName: "adresseComplete");
        }
    }
}
