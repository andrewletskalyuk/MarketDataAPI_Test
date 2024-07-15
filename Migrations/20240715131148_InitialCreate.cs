using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarketDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MappingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Exchange = table.Column<string>(type: "text", nullable: false),
                    DefaultOrderSize = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MappingDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InstrumentyId = table.Column<int>(type: "integer", nullable: false),
                    ActiveTickId = table.Column<int>(type: "integer", nullable: true),
                    SimulationId = table.Column<int>(type: "integer", nullable: true),
                    OandaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mappings_MappingDetails_ActiveTickId",
                        column: x => x.ActiveTickId,
                        principalTable: "MappingDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mappings_MappingDetails_OandaId",
                        column: x => x.OandaId,
                        principalTable: "MappingDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mappings_MappingDetails_SimulationId",
                        column: x => x.SimulationId,
                        principalTable: "MappingDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Kind = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TickSize = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    BaseCurrency = table.Column<string>(type: "text", nullable: false),
                    InstrumentyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instruments_Mappings_InstrumentyId",
                        column: x => x.InstrumentyId,
                        principalTable: "Mappings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_InstrumentyId",
                table: "Instruments",
                column: "InstrumentyId");

            migrationBuilder.CreateIndex(
                name: "IX_Mappings_ActiveTickId",
                table: "Mappings",
                column: "ActiveTickId");

            migrationBuilder.CreateIndex(
                name: "IX_Mappings_OandaId",
                table: "Mappings",
                column: "OandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mappings_SimulationId",
                table: "Mappings",
                column: "SimulationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "Mappings");

            migrationBuilder.DropTable(
                name: "MappingDetails");
        }
    }
}
