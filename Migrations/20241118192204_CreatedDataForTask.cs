using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiMinimal.Migrations
{
    /// <inheritdoc />
    public partial class CreatedDataForTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "IdTask", "CategoryID", "DateCreation", "Description", "DurationTask", "PriorityTask", "TaskName" },
                values: new object[,]
                {
                    { new Guid("f5601b55-2076-4b30-91d0-ecbb6648d099"), new Guid("f4dd7e80-b991-4992-8207-fdf90ac21b02"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 2, "Arreglar bug en azure" },
                    { new Guid("f5601b55-2076-4b30-91d0-ecbb6648d0af"), new Guid("f4dd7e80-b991-4992-8207-fdf90ac21b8b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, "Limpiar la casa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "IdTask",
                keyValue: new Guid("f5601b55-2076-4b30-91d0-ecbb6648d099"));

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "IdTask",
                keyValue: new Guid("f5601b55-2076-4b30-91d0-ecbb6648d0af"));
        }
    }
}
