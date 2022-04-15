using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyArt.DataAccess.Migrations
{
    public partial class FixProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "FilmComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 751, DateTimeKind.Local).AddTicks(982),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 533, DateTimeKind.Local).AddTicks(1149));

            migrationBuilder.AlterColumn<int>(
                name: "ShareCount",
                table: "Film",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ExhibitionComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 750, DateTimeKind.Local).AddTicks(479),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 532, DateTimeKind.Local).AddTicks(907));

            migrationBuilder.AlterColumn<int>(
                name: "ShareCount",
                table: "Exhibition",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Exhibition",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Exhibition",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ShareCount",
                table: "Board",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Board",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 749, DateTimeKind.Local).AddTicks(3637),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 531, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ArtComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 747, DateTimeKind.Local).AddTicks(4557),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 529, DateTimeKind.Local).AddTicks(3951));

            migrationBuilder.AlterColumn<int>(
                name: "ShareCount",
                table: "Art",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Month",
                table: "Art",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Art",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 747, DateTimeKind.Local).AddTicks(8534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 529, DateTimeKind.Local).AddTicks(7727));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "FilmComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 533, DateTimeKind.Local).AddTicks(1149),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 751, DateTimeKind.Local).AddTicks(982));

            migrationBuilder.AlterColumn<int>(
                name: "ShareCount",
                table: "Film",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ExhibitionComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 532, DateTimeKind.Local).AddTicks(907),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 750, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.AlterColumn<int>(
                name: "ShareCount",
                table: "Exhibition",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Exhibition",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Exhibition",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShareCount",
                table: "Board",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Board",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 531, DateTimeKind.Local).AddTicks(4326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 749, DateTimeKind.Local).AddTicks(3637));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ArtComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 529, DateTimeKind.Local).AddTicks(3951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 747, DateTimeKind.Local).AddTicks(4557));

            migrationBuilder.AlterColumn<int>(
                name: "ShareCount",
                table: "Art",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Month",
                table: "Art",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Art",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 529, DateTimeKind.Local).AddTicks(7727),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 39, 24, 747, DateTimeKind.Local).AddTicks(8534));
        }
    }
}
