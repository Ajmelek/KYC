using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STB_everywhere.Migrations
{
    /// <inheritdoc />
    public partial class AddDemandeModificationClientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DemandeModificationClients",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientID = table.Column<long>(type: "bigint", nullable: false),
                    etat = table.Column<int>(type: "int", nullable: false),
                    dateDemande = table.Column<string>(type: "datetime2", nullable: true),
                    dateTraitement = table.Column<string>(type: "datetime2", nullable: true),
                    utilisateur = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IndicateurTel = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresseComplete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresseLieuTravail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agenceResidence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    civilite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clientautrebanque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codepostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    confidenceRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateRDV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datecin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datenaissance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deviseCompteReserved = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    environment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    etatcivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gouvernorat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mailprincipal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nationalite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nommere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nompere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paysRelations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paysnaissance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rcin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    referentiel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resident = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    secondenationalite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    selfie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    statutpro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rib = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AutreNationalite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    prenommere = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    prenompere = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Datedelivrance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Motif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Objetrelation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    commentaire = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandeModificationClients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DemandeModificationClients_Client_clientID",
                        column: x => x.clientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DemandeModificationClients_clientID",
                table: "DemandeModificationClients",
                column: "clientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemandeModificationClients");
        }
    }
}
