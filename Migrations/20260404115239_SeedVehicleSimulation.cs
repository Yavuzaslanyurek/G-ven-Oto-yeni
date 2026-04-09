using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuvenOto.Migrations
{
    /// <inheritdoc />
    public partial class SeedVehicleSimulation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VehicleDamageRecords",
                columns: new[] { "Id", "Amount", "DamageDate", "DamageReason", "IsHeavyDamage", "Plate" },
                values: new object[,]
                {
                    { 1, 12500.0, new DateTime(2019, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mesaj: Sayin ilgili, 57ED244 plakali arac 12.03.2019 tarihinde 'Carpisma' nedeniyle 12.500 TL hasar kaydi almistir.", false, "57ED244" },
                    { 2, 85000.0, new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mesaj: Sayin ilgili, 57ED244 plakali arac 05.10.2022 tarihinde 'Agir Hasar' (Pert) kaydi almistir. Tutar: 85.000 TL", true, "57ED244" },
                    { 3, 4200.0, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mesaj: Sayin ilgili, 57AAR642 plakali arac 20.08.2023 tarihinde 'Park Halinde Carpilma' nedeniyle 4.200 TL hasar kaydi almistir.", false, "57AAR642" }
                });

            migrationBuilder.InsertData(
                table: "VehicleInspections",
                columns: new[] { "Id", "InspectionDate", "InspectionStation", "KilometerAtInspection", "Plate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinop Merkez", 185000, "57ED244" },
                    { 2, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinop Boyabat", 240000, "57ED244" },
                    { 3, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İstanbul Dudullu", 35000, "57AAR642" },
                    { 4, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinop Merkez", 72000, "57AAR642" }
                });

            migrationBuilder.InsertData(
                table: "VehicleRegistries",
                columns: new[] { "Id", "ChassisNumber", "EngineNumber", "OwnerName", "Plate", "RegistrationDate", "VehicleColor" },
                values: new object[,]
                {
                    { 1, "SASI-ED-9988", "MOTOR-ED-1122", "Ahmet Yılmaz", "57ED244", new DateTime(2015, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beyaz" },
                    { 2, "SASI-AA-3322", "MOTOR-AA-5544", "Mehmet Demir", "57AAR642", new DateTime(2020, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Metalik Gri" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleDamageRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleDamageRecords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleDamageRecords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleInspections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleInspections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleInspections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleInspections",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleRegistries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleRegistries",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
