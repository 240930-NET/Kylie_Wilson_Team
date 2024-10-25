using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class JsonConverter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Due",
                value: new DateTime(2024, 11, 1, 3, 18, 9, 502, DateTimeKind.Local).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Due",
                value: new DateTime(2024, 10, 28, 3, 18, 9, 502, DateTimeKind.Local).AddTicks(4423));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Due",
                value: new DateTime(2024, 11, 1, 2, 53, 51, 963, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Due",
                value: new DateTime(2024, 10, 28, 2, 53, 51, 963, DateTimeKind.Local).AddTicks(5343));
        }
    }
}
