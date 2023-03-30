using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class mudança : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EditadoPor",
                table: "Categorias",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Editado",
                table: "Categorias",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EditadoPor",
                table: "Categorias",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Editado",
                table: "Categorias",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }
    }
}
