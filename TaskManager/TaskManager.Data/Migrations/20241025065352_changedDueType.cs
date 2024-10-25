using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedDueType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DueString",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Due", "DueString" },
                values: new object[] { new DateTime(2024, 11, 1, 2, 53, 51, 963, DateTimeKind.Local).AddTicks(5127), "" });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Due", "DueString" },
                values: new object[] { new DateTime(2024, 10, 28, 2, 53, 51, 963, DateTimeKind.Local).AddTicks(5343), "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueString",
                table: "ToDos");

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Due",
                value: new DateTime(2024, 11, 1, 1, 53, 29, 542, DateTimeKind.Local).AddTicks(8774));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Due",
                value: new DateTime(2024, 10, 28, 1, 53, 29, 542, DateTimeKind.Local).AddTicks(8833));
        }
    }
}
