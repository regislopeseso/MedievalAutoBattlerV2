using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedievalAutoBattlerV2.Migrations
{
    /// <inheritdoc />
    public partial class CreateNPC_table_and_DeckEntries_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NpcId",
                table: "cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeckEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeckEntries_cards_CardId",
                        column: x => x.CardId,
                        principalTable: "cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Npcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Npcs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_cards_NpcId",
                table: "cards",
                column: "NpcId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckEntries_CardId",
                table: "DeckEntries",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_cards_Npcs_NpcId",
                table: "cards",
                column: "NpcId",
                principalTable: "Npcs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cards_Npcs_NpcId",
                table: "cards");

            migrationBuilder.DropTable(
                name: "DeckEntries");

            migrationBuilder.DropTable(
                name: "Npcs");

            migrationBuilder.DropIndex(
                name: "IX_cards_NpcId",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "NpcId",
                table: "cards");
        }
    }
}
