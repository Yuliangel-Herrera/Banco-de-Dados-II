using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFAereoNuvem.Migrations
{
    /// <inheritdoc />
    public partial class ListaDeScalesNoFlight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Scale",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scale_FlightId",
                table: "Scale",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scale_Flights_FlightId",
                table: "Scale",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scale_Flights_FlightId",
                table: "Scale");

            migrationBuilder.DropIndex(
                name: "IX_Scale_FlightId",
                table: "Scale");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Scale");
        }
    }
}
