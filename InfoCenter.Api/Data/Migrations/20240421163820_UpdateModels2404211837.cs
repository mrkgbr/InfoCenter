﻿using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoCenter.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels2404211837 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "ArticleDetails");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "ArticleDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "EndDate",
                table: "ArticleDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDate",
                table: "ArticleDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}