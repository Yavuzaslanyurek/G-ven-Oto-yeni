using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuvenOto.Migrations
{
    /// <inheritdoc />
    public partial class FeatureKisitlamalariEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormatType",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxLength",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Options",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormatType",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "MaxLength",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Options",
                table: "Features");
        }
    }
}
