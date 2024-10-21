using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceWar.Data.Migrations
{
    /// <inheritdoc />
    public partial class ship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipXP = table.Column<int>(type: "int", nullable: false),
                    ShipXPNextLevel = table.Column<int>(type: "int", nullable: false),
                    ShipLevel = table.Column<int>(type: "int", nullable: false),
                    ShipClass = table.Column<int>(type: "int", nullable: false),
                    ShipStatus = table.Column<int>(type: "int", nullable: false),
                    PrimaryAttack = table.Column<int>(type: "int", nullable: false),
                    SecondaryAttack = table.Column<int>(type: "int", nullable: false),
                    UltimateAttack = table.Column<int>(type: "int", nullable: false),
                    ShipWasBuilt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipWasDestroyed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuiltAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DestroyedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ships");
        }
    }
}
