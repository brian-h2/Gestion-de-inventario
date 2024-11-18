using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMinimal.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnDurationTaskInTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationTask",
                table: "Tareas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationTask",
                table: "Tareas");
        }
    }
}
