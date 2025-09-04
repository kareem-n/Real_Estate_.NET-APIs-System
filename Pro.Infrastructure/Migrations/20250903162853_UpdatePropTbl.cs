using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MainImgId",
                table: "Properties",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_MainImgId",
                table: "Properties",
                column: "MainImgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Images_MainImgId",
                table: "Properties",
                column: "MainImgId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Images_MainImgId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_MainImgId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "MainImgId",
                table: "Properties");
        }
    }
}
