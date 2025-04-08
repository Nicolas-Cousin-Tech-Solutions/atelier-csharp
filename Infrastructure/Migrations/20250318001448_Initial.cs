using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dossiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsPenal = table.Column<bool>(type: "INTEGER", nullable: false),
                    NatureDossier = table.Column<string>(type: "TEXT", nullable: false),
                    TypeDossier = table.Column<string>(type: "TEXT", nullable: false),
                    DateDesConstatations = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateDeClotureDuPv = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateEnregistrement = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReseauDeCompetences = table.Column<string>(type: "TEXT", nullable: false),
                    UniteProprietaire = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dossiers_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgentVerbalisateurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DossierId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AgentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsPrincipal = table.Column<bool>(type: "INTEGER", nullable: false),
                    ServiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AgentsExterieurs = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentVerbalisateurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentVerbalisateurs_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentVerbalisateurs_Dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "Dossiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentVerbalisateurs_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etablissements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DossierId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Siret = table.Column<string>(type: "TEXT", nullable: false),
                    RaisonSociale = table.Column<string>(type: "TEXT", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etablissements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etablissements_Dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "Dossiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transmissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DossierId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Parquets = table.Column<string>(type: "TEXT", nullable: false),
                    DateEnvoi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DessaisissementAutreParquet = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transmissions_Dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "Dossiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentVerbalisateurs_AgentId",
                table: "AgentVerbalisateurs",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentVerbalisateurs_DossierId",
                table: "AgentVerbalisateurs",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentVerbalisateurs_ServiceId",
                table: "AgentVerbalisateurs",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_ServiceId",
                table: "Dossiers",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Etablissements_DossierId",
                table: "Etablissements",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_Transmissions_DossierId",
                table: "Transmissions",
                column: "DossierId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentVerbalisateurs");

            migrationBuilder.DropTable(
                name: "Etablissements");

            migrationBuilder.DropTable(
                name: "Transmissions");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Dossiers");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
