using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToToAirline.Migrations
{
    /// <inheritdoc />
    public partial class NotUnugue1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Flights_ArrivingAirportId",
                table: "Flights");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ArrivingAirportId",
                table: "Flights",
                column: "ArrivingAirportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Flights_ArrivingAirportId",
                table: "Flights");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ArrivingAirportId",
                table: "Flights",
                column: "ArrivingAirportId",
                unique: true);
        }
    }
}
