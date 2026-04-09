using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuvenOto.Migrations
{
    /// <inheritdoc />
    public partial class TabloIsimleriniDuzenle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingFeatureValues_Features_FeatureId",
                table: "ListingFeatureValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingFeatureValues_Listings_ListingId",
                table: "ListingFeatureValues");

            migrationBuilder.DropIndex(
                name: "IX_ListingFeatureValues_ListingId",
                table: "ListingFeatureValues");

            migrationBuilder.DeleteData(
                table: "VehicleDamageRecords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleInspections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleInspections",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "FeatureId",
                table: "ListingFeatureValues",
                newName: "OzellikId");

            migrationBuilder.RenameIndex(
                name: "IX_ListingFeatureValues_FeatureId",
                table: "ListingFeatureValues",
                newName: "IX_ListingFeatureValues_OzellikId");

            migrationBuilder.AddColumn<int>(
                name: "IlanId",
                table: "ListingFeatureValues",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "VehicleDamageRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "DamageReason",
                value: "Carpisma hasari.");

            migrationBuilder.UpdateData(
                table: "VehicleDamageRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "DamageReason",
                value: "Agir Hasar kaydi.");

            migrationBuilder.CreateIndex(
                name: "IX_ListingFeatureValues_IlanId",
                table: "ListingFeatureValues",
                column: "IlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingFeatureValues_Features_OzellikId",
                table: "ListingFeatureValues",
                column: "OzellikId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingFeatureValues_Listings_IlanId",
                table: "ListingFeatureValues",
                column: "IlanId",
                principalTable: "Listings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingFeatureValues_Features_OzellikId",
                table: "ListingFeatureValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingFeatureValues_Listings_IlanId",
                table: "ListingFeatureValues");

            migrationBuilder.DropIndex(
                name: "IX_ListingFeatureValues_IlanId",
                table: "ListingFeatureValues");

            migrationBuilder.DropColumn(
                name: "IlanId",
                table: "ListingFeatureValues");

            migrationBuilder.RenameColumn(
                name: "OzellikId",
                table: "ListingFeatureValues",
                newName: "FeatureId");

            migrationBuilder.RenameIndex(
                name: "IX_ListingFeatureValues_OzellikId",
                table: "ListingFeatureValues",
                newName: "IX_ListingFeatureValues_FeatureId");

            migrationBuilder.UpdateData(
                table: "VehicleDamageRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "DamageReason",
                value: "Mesaj: Sayin ilgili, 57ED244 plakali arac 12.03.2019 tarihinde 'Carpisma' nedeniyle 12.500 TL hasar kaydi almistir.");

            migrationBuilder.UpdateData(
                table: "VehicleDamageRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "DamageReason",
                value: "Mesaj: Sayin ilgili, 57ED244 plakali arac 05.10.2022 tarihinde 'Agir Hasar' (Pert) kaydi almistir. Tutar: 85.000 TL");

            migrationBuilder.InsertData(
                table: "VehicleDamageRecords",
                columns: new[] { "Id", "Amount", "DamageDate", "DamageReason", "IsHeavyDamage", "Plate" },
                values: new object[] { 3, 4200.0, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mesaj: Sayin ilgili, 57AAR642 plakali arac 20.08.2023 tarihinde 'Park Halinde Carpilma' nedeniyle 4.200 TL hasar kaydi almistir.", false, "57AAR642" });

            migrationBuilder.InsertData(
                table: "VehicleInspections",
                columns: new[] { "Id", "InspectionDate", "InspectionStation", "KilometerAtInspection", "Plate" },
                values: new object[,]
                {
                    { 3, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İstanbul Dudullu", 35000, "57AAR642" },
                    { 4, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinop Merkez", 72000, "57AAR642" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListingFeatureValues_ListingId",
                table: "ListingFeatureValues",
                column: "ListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingFeatureValues_Features_FeatureId",
                table: "ListingFeatureValues",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingFeatureValues_Listings_ListingId",
                table: "ListingFeatureValues",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
