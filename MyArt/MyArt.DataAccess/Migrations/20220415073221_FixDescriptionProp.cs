using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyArt.DataAccess.Migrations
{
    public partial class FixDescriptionProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "FilmComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 533, DateTimeKind.Local).AddTicks(1149),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 8, 16, 33, 58, 124, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ExhibitionComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 532, DateTimeKind.Local).AddTicks(907),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 8, 16, 33, 58, 123, DateTimeKind.Local).AddTicks(7847));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Board",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 531, DateTimeKind.Local).AddTicks(4326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 8, 16, 33, 58, 123, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ArtComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 529, DateTimeKind.Local).AddTicks(3951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 8, 16, 33, 58, 121, DateTimeKind.Local).AddTicks(3502));

            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "Art",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Art",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 529, DateTimeKind.Local).AddTicks(7727),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 8, 16, 33, 58, 121, DateTimeKind.Local).AddTicks(6985));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "FilmComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 8, 16, 33, 58, 124, DateTimeKind.Local).AddTicks(7912),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 533, DateTimeKind.Local).AddTicks(1149));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ExhibitionComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 8, 16, 33, 58, 123, DateTimeKind.Local).AddTicks(7847),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 532, DateTimeKind.Local).AddTicks(907));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Board",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 8, 16, 33, 58, 123, DateTimeKind.Local).AddTicks(1336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 531, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ArtComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 8, 16, 33, 58, 121, DateTimeKind.Local).AddTicks(3502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 529, DateTimeKind.Local).AddTicks(3951));

            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "Art",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Art",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 8, 16, 33, 58, 121, DateTimeKind.Local).AddTicks(6985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 10, 32, 21, 529, DateTimeKind.Local).AddTicks(7727));
        }
    }
}
