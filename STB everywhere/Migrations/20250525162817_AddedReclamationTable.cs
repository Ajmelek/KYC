using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STB_everywhere.Migrations
{
    /// <inheritdoc />
    public partial class AddedReclamationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DemandeModificationClient_Client_clientID",
                table: "DemandeModificationClient");

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reclamation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reclamation_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuperAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAdmin", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Login",
                table: "Admin",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reclamation_ClientId",
                table: "Reclamation",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperAdmin_Login",
                table: "SuperAdmin",
                column: "Login",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DemandeModificationClient_Client_clientID",
                table: "DemandeModificationClient",
                column: "clientID",
                principalTable: "Client",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DemandeModificationClient_Client_clientID",
                table: "DemandeModificationClient");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Reclamations");

            migrationBuilder.DropTable(
                name: "SuperAdmin");

            migrationBuilder.AddForeignKey(
                name: "FK_DemandeModificationClient_Client_clientID",
                table: "DemandeModificationClient",
                column: "clientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
