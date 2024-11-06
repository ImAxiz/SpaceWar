using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceWar.Data.Migrations
{
    /// <inheritdoc />
    public partial class _123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrimaryAttackPower",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryAttackPower",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShipDurability",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UltimateAttackPower",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimaryAttackPower",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "SecondaryAttackPower",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "ShipDurability",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "UltimateAttackPower",
                table: "Ships");
        }
    }
}
