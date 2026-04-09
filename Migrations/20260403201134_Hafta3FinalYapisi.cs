using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuvenOto.Migrations
{
    /// <inheritdoc />
    public partial class Hafta3FinalYapisi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RightFrontDoorStatus",
                table: "Listings",
                newName: "RearRightFender");

            migrationBuilder.RenameColumn(
                name: "LeftFrontDoorStatus",
                table: "Listings",
                newName: "RearRightDoor");

            migrationBuilder.AddColumn<int>(
                name: "FrontLeftDoor",
                table: "Listings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FrontLeftFender",
                table: "Listings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FrontRightDoor",
                table: "Listings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FrontRightFender",
                table: "Listings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RearLeftDoor",
                table: "Listings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RearLeftFender",
                table: "Listings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "ListingFeatureValues",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrontLeftDoor",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "FrontLeftFender",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "FrontRightDoor",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "FrontRightFender",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "RearLeftDoor",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "RearLeftFender",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "ListingFeatureValues");

            migrationBuilder.RenameColumn(
                name: "RearRightFender",
                table: "Listings",
                newName: "RightFrontDoorStatus");

            migrationBuilder.RenameColumn(
                name: "RearRightDoor",
                table: "Listings",
                newName: "LeftFrontDoorStatus");
        }
    }
}
