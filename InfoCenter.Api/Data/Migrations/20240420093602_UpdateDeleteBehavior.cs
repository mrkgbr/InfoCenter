using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoCenter.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Units_UnitId",
                table: "Articles");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Units_UnitId",
                table: "Articles",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Units_UnitId",
                table: "Articles");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Units_UnitId",
                table: "Articles",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
