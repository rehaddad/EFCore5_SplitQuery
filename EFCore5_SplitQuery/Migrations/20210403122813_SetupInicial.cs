using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore5_SplitQuery.Migrations
{
    public partial class SetupInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etapas",
                columns: table => new
                {
                    EtapaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapas", x => x.EtapaId);
                });

            migrationBuilder.CreateTable(
                name: "Pilotos",
                columns: table => new
                {
                    PilotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EtapaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilotos", x => x.PilotoId);
                    table.ForeignKey(
                        name: "FK_Pilotos_Etapas_EtapaId",
                        column: x => x.EtapaId,
                        principalTable: "Etapas",
                        principalColumn: "EtapaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Etapas",
                columns: new[] { "EtapaId", "Cidade" },
                values: new object[] { 1, "Moto GP Qatar" });

            migrationBuilder.InsertData(
                table: "Etapas",
                columns: new[] { "EtapaId", "Cidade" },
                values: new object[] { 2, "Moto GP Italia Mugello" });

            migrationBuilder.InsertData(
                table: "Pilotos",
                columns: new[] { "PilotoId", "EtapaId", "Nome", "Pais" },
                values: new object[,]
                {
                    { 1, 1, "Marque Marques", "Espanha" },
                    { 2, 1, "Valentino Rossi", "Italia" },
                    { 3, 1, "Franco Morbidelli", "Italia" },
                    { 4, 1, "Miguel Oliveira", "Portugal" },
                    { 5, 2, "Danilo Petrucci", "Espanha" },
                    { 6, 2, "Takkaki Nakagami", "Japao" },
                    { 7, 2, "Luca Marini", "Italia" },
                    { 8, 2, "Iker Lecuona", "Espanha" },
                    { 9, 2, "Lorenzo Salvadori", "Italia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pilotos_EtapaId",
                table: "Pilotos",
                column: "EtapaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pilotos");

            migrationBuilder.DropTable(
                name: "Etapas");
        }
    }
}
