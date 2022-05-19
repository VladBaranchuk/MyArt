using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyArt.DataAccess.Migrations
{
    public partial class addMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Board",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 19, 21, 14, 15, 66, DateTimeKind.Local).AddTicks(8418),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 8, 14, 36, 15, 644, DateTimeKind.Local).AddTicks(821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Art",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 19, 21, 14, 15, 65, DateTimeKind.Local).AddTicks(6063),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 8, 14, 36, 15, 642, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Art",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Material",
                table: "Art");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Board",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 14, 36, 15, 644, DateTimeKind.Local).AddTicks(821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 19, 21, 14, 15, 66, DateTimeKind.Local).AddTicks(8418));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Art",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 14, 36, 15, 642, DateTimeKind.Local).AddTicks(9163),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 19, 21, 14, 15, 65, DateTimeKind.Local).AddTicks(6063));
        }
    }
}
