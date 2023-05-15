using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWorkshop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class someRecovery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarWorkshopService_CarWorkshops_CarWorkshopId",
                table: "CarWorkshopService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarWorkshopService",
                table: "CarWorkshopService");

            migrationBuilder.RenameTable(
                name: "CarWorkshopService",
                newName: "Services");

            migrationBuilder.RenameIndex(
                name: "IX_CarWorkshopService_CarWorkshopId",
                table: "Services",
                newName: "IX_Services_CarWorkshopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_CarWorkshops_CarWorkshopId",
                table: "Services",
                column: "CarWorkshopId",
                principalTable: "CarWorkshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_CarWorkshops_CarWorkshopId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "CarWorkshopService");

            migrationBuilder.RenameIndex(
                name: "IX_Services_CarWorkshopId",
                table: "CarWorkshopService",
                newName: "IX_CarWorkshopService_CarWorkshopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarWorkshopService",
                table: "CarWorkshopService",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarWorkshopService_CarWorkshops_CarWorkshopId",
                table: "CarWorkshopService",
                column: "CarWorkshopId",
                principalTable: "CarWorkshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
