using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoCenter.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel2404220955 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ArticleDetails",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldPrecision: 14,
                oldScale: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ArticleDetails",
                type: "TEXT",
                precision: 14,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");
        }
    }
}
