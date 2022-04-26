using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyArt.DataAccess.Migrations
{
    public partial class AddDataToArt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Board",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 26, 0, 9, 56, 528, DateTimeKind.Local).AddTicks(9290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 23, 17, 24, 49, 212, DateTimeKind.Local).AddTicks(6290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Art",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 26, 0, 9, 56, 527, DateTimeKind.Local).AddTicks(3501),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 23, 17, 24, 49, 211, DateTimeKind.Local).AddTicks(2993));

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Art",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Art");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Board",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 23, 17, 24, 49, 212, DateTimeKind.Local).AddTicks(6290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 26, 0, 9, 56, 528, DateTimeKind.Local).AddTicks(9290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Art",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 23, 17, 24, 49, 211, DateTimeKind.Local).AddTicks(2993),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 26, 0, 9, 56, 527, DateTimeKind.Local).AddTicks(3501));
        }
    }
}
