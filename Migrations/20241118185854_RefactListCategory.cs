using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiMinimal.Migrations
{
    /// <inheritdoc />
    public partial class RefactListCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoryID",
                keyValue: new Guid("f4dd7e80-b991-4992-8207-fdf90ac21b02"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoryID",
                keyValue: new Guid("f4dd7e80-b991-4992-8207-fdf90ac21b8b"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoryID", "Description", "Name", "Wheight" },
                values: new object[,]
                {
                    { new Guid("f4dd7e80-b991-4992-8207-fdf90ac21b02"), null, "Trabajo", 40 },
                    { new Guid("f4dd7e80-b991-4992-8207-fdf90ac21b8b"), null, "Limpieza", 20 }
                });
        }
    }
}
