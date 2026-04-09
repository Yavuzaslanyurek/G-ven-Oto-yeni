using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuvenOto.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAndDateToIlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingFeatureValues_Listings_IlanId",
                table: "ListingFeatureValues");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Models_ModelId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "ListingFeatureValues");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Listings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IlanId",
                table: "ListingFeatureValues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModelId1",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId1",
                table: "Cars",
                column: "ModelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_ModelId1",
                table: "Cars",
                column: "ModelId1",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingFeatureValues_Listings_IlanId",
                table: "ListingFeatureValues",
                column: "IlanId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Models_ModelId",
                table: "Listings",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelId1",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingFeatureValues_Listings_IlanId",
                table: "ListingFeatureValues");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Models_ModelId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ModelId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "ModelId1",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "IlanId",
                table: "ListingFeatureValues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ListingId",
                table: "ListingFeatureValues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingFeatureValues_Listings_IlanId",
                table: "ListingFeatureValues",
                column: "IlanId",
                principalTable: "Listings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Models_ModelId",
                table: "Listings",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
