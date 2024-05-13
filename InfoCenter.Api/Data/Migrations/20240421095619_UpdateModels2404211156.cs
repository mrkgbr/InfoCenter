using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoCenter.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels2404211156 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleDetail_Articles_ArticleId",
                table: "ArticleDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleDetail_Contracts_ContractId",
                table: "ArticleDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleDetail_Currencies_CurrencyId",
                table: "ArticleDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleDetail",
                table: "ArticleDetail");

            migrationBuilder.RenameTable(
                name: "ArticleDetail",
                newName: "ArticleDetails");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleDetail_CurrencyId",
                table: "ArticleDetails",
                newName: "IX_ArticleDetails_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleDetail_ContractId",
                table: "ArticleDetails",
                newName: "IX_ArticleDetails_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleDetail_ArticleId",
                table: "ArticleDetails",
                newName: "IX_ArticleDetails_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleDetails",
                table: "ArticleDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleDetails_Articles_ArticleId",
                table: "ArticleDetails",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleDetails_Contracts_ContractId",
                table: "ArticleDetails",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleDetails_Currencies_CurrencyId",
                table: "ArticleDetails",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleDetails_Articles_ArticleId",
                table: "ArticleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleDetails_Contracts_ContractId",
                table: "ArticleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleDetails_Currencies_CurrencyId",
                table: "ArticleDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleDetails",
                table: "ArticleDetails");

            migrationBuilder.RenameTable(
                name: "ArticleDetails",
                newName: "ArticleDetail");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleDetails_CurrencyId",
                table: "ArticleDetail",
                newName: "IX_ArticleDetail_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleDetails_ContractId",
                table: "ArticleDetail",
                newName: "IX_ArticleDetail_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleDetails_ArticleId",
                table: "ArticleDetail",
                newName: "IX_ArticleDetail_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleDetail",
                table: "ArticleDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleDetail_Articles_ArticleId",
                table: "ArticleDetail",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleDetail_Contracts_ContractId",
                table: "ArticleDetail",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleDetail_Currencies_CurrencyId",
                table: "ArticleDetail",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}