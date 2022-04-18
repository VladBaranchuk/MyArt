using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyArt.DataAccess.Migrations
{
    public partial class FixCountryType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "FilmComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 18, 3, 3, 7, 203, DateTimeKind.Local).AddTicks(6914),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 751, DateTimeKind.Local).AddTicks(982));

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Film",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ExhibitionComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 18, 3, 3, 7, 202, DateTimeKind.Local).AddTicks(6680),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 750, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Board",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 18, 3, 3, 7, 201, DateTimeKind.Local).AddTicks(9978),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 749, DateTimeKind.Local).AddTicks(3637));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ArtComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 18, 3, 3, 7, 200, DateTimeKind.Local).AddTicks(1445),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 747, DateTimeKind.Local).AddTicks(4557));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Art",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 18, 3, 3, 7, 200, DateTimeKind.Local).AddTicks(5241),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 747, DateTimeKind.Local).AddTicks(8534));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "FilmComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 751, DateTimeKind.Local).AddTicks(982),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 18, 3, 3, 7, 203, DateTimeKind.Local).AddTicks(6914));

            migrationBuilder.AlterColumn<int>(
                name: "Country",
                table: "Film",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ExhibitionComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 750, DateTimeKind.Local).AddTicks(479),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 18, 3, 3, 7, 202, DateTimeKind.Local).AddTicks(6680));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Board",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 749, DateTimeKind.Local).AddTicks(3637),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 18, 3, 3, 7, 201, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ArtComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 747, DateTimeKind.Local).AddTicks(4557),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 18, 3, 3, 7, 200, DateTimeKind.Local).AddTicks(1445));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Art",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 747, DateTimeKind.Local).AddTicks(8534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 18, 3, 3, 7, 200, DateTimeKind.Local).AddTicks(5241));
        }
    }
}
