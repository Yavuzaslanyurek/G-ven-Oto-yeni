using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuvenOto.Migrations
{
    /// <inheritdoc />
    public partial class AddListingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Kilometer = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    HoodStatus = table.Column<int>(type: "int", nullable: false),
                    RoofStatus = table.Column<int>(type: "int", nullable: false),
                    TrunkStatus = table.Column<int>(type: "int", nullable: false),
                    FrontBumperStatus = table.Column<int>(type: "int", nullable: false),
                    RearBumperStatus = table.Column<int>(type: "int", nullable: false),
                    LeftFrontDoorStatus = table.Column<int>(type: "int", nullable: false),
                    RightFrontDoorStatus = table.Column<int>(type: "int", nullable: false),
                    ExpertisePdfPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listings_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListingFeatureValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingFeatureValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListingFeatureValues_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListingFeatureValues_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListingFeatureValues_FeatureId",
                table: "ListingFeatureValues",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingFeatureValues_ListingId",
                table: "ListingFeatureValues",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_ModelId",
                table: "Listings",
                column: "ModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListingFeatureValues");

            migrationBuilder.DropTable(
                name: "Listings");
        }
    }
}
