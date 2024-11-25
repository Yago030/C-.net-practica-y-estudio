using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend2.Migrations
{
    /// <inheritdoc />
    public partial class AlcoholInBeerFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Alchool",
                table: "Beers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Alchool",
                table: "Beers",
                type: "decimal (18,2",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
