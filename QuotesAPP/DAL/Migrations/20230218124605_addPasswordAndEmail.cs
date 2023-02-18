using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuotesAPP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addPasswordAndEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Quotes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 18, 15, 46, 4, 931, DateTimeKind.Local).AddTicks(2330),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 2, 9, 23, 37, 21, 654, DateTimeKind.Local).AddTicks(2730));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 18, 15, 46, 4, 931, DateTimeKind.Local).AddTicks(1920),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 2, 9, 23, 37, 21, 654, DateTimeKind.Local).AddTicks(2340));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Authors");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Quotes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 9, 23, 37, 21, 654, DateTimeKind.Local).AddTicks(2730),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 2, 18, 15, 46, 4, 931, DateTimeKind.Local).AddTicks(2330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 9, 23, 37, 21, 654, DateTimeKind.Local).AddTicks(2340),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 2, 18, 15, 46, 4, 931, DateTimeKind.Local).AddTicks(1920));
        }
    }
}
