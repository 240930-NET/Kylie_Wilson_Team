using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class Converter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueString",
                table: "ToDos");

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Due",
                value: new DateTime(2024, 11, 1, 3, 27, 24, 418, DateTimeKind.Local).AddTicks(6941));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Due",
                value: new DateTime(2024, 10, 28, 3, 27, 24, 418, DateTimeKind.Local).AddTicks(6988));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new DateTime(2024, 11, 1, 3, 18, 9, 502, DateTimeKind.Local).AddTicks(4359), "" });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Due", "DueString" },
                values: new object[] { new DateTime(2024, 10, 28, 3, 18, 9, 502, DateTimeKind.Local).AddTicks(4423), "" });
        }
    }
}
