using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuvenOto.Migrations
{
    /// <inheritdoc />
    public partial class ModelHierarchyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentModelId",
                table: "Models",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_ParentModelId",
                table: "Models",
                column: "ParentModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Models_ParentModelId",
                table: "Models",
                column: "ParentModelId",
                principalTable: "Models",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Models_ParentModelId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_ParentModelId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "ParentModelId",
                table: "Models");
        }
    }
}
