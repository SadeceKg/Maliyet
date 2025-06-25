using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HakedisYonetimSistemi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProjeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToplamButce",
                table: "Projeler",
                newName: "Butce");

            migrationBuilder.RenameColumn(
                name: "Musteri",
                table: "Projeler",
                newName: "MusteriAdi");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "Projeler",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MaliyetKalemleri",
                keyColumn: "Id",
                keyValue: 1,
                column: "OlusturulmaTarihi",
                value: new DateTime(2025, 6, 25, 9, 59, 37, 530, DateTimeKind.Local).AddTicks(5793));

            migrationBuilder.UpdateData(
                table: "MaliyetKalemleri",
                keyColumn: "Id",
                keyValue: 2,
                column: "OlusturulmaTarihi",
                value: new DateTime(2025, 6, 25, 9, 59, 37, 530, DateTimeKind.Local).AddTicks(5796));

            migrationBuilder.UpdateData(
                table: "MaliyetKalemleri",
                keyColumn: "Id",
                keyValue: 3,
                column: "OlusturulmaTarihi",
                value: new DateTime(2025, 6, 25, 9, 59, 37, 530, DateTimeKind.Local).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "Projeler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Adres", "OlusturulmaTarihi" },
                values: new object[] { null, new DateTime(2025, 6, 25, 9, 59, 37, 530, DateTimeKind.Local).AddTicks(5613) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "Projeler");

            migrationBuilder.RenameColumn(
                name: "MusteriAdi",
                table: "Projeler",
                newName: "Musteri");

            migrationBuilder.RenameColumn(
                name: "Butce",
                table: "Projeler",
                newName: "ToplamButce");

            migrationBuilder.UpdateData(
                table: "MaliyetKalemleri",
                keyColumn: "Id",
                keyValue: 1,
                column: "OlusturulmaTarihi",
                value: new DateTime(2025, 6, 25, 9, 46, 18, 669, DateTimeKind.Local).AddTicks(1045));

            migrationBuilder.UpdateData(
                table: "MaliyetKalemleri",
                keyColumn: "Id",
                keyValue: 2,
                column: "OlusturulmaTarihi",
                value: new DateTime(2025, 6, 25, 9, 46, 18, 669, DateTimeKind.Local).AddTicks(1048));

            migrationBuilder.UpdateData(
                table: "MaliyetKalemleri",
                keyColumn: "Id",
                keyValue: 3,
                column: "OlusturulmaTarihi",
                value: new DateTime(2025, 6, 25, 9, 46, 18, 669, DateTimeKind.Local).AddTicks(1051));

            migrationBuilder.UpdateData(
                table: "Projeler",
                keyColumn: "Id",
                keyValue: 1,
                column: "OlusturulmaTarihi",
                value: new DateTime(2025, 6, 25, 9, 46, 18, 669, DateTimeKind.Local).AddTicks(908));
        }
    }
}
