using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STB_everywhere.Migrations
{
    /// <inheritdoc />
    public partial class AddClientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndicateurTel = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresseComplete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresseLieuTravail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agenceResidence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Civilite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clientautrebanque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codepostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    confidenceRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateRDV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datecin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datenaissance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deviseCompteReserved = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Environment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    etatcivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gouvernorat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mailprincipal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationalite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nommere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nompere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paysRelations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paysnaissance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rcin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referentiel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resident = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    secondenationalite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Selfie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    statutpro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
