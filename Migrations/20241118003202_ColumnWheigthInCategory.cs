using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMinimal.Migrations
{
    /// <inheritdoc />
    public partial class ColumnWheigthInCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Wheight",
                table: "Categoria",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wheight",
                table: "Categoria");
        }
    }
}
