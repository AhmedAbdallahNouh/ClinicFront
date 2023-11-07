using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClincApi.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorServices_Categories_CategoryId",
                table: "DoctorServices");

            migrationBuilder.DropIndex(
                name: "IX_DoctorServices_CategoryId",
                table: "DoctorServices");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "DoctorServices");

            migrationBuilder.AddColumn<DateTime>(
                name: "VisitedDoctorPage",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitedDoctorPage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "DoctorServices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorServices_CategoryId",
                table: "DoctorServices",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorServices_Categories_CategoryId",
                table: "DoctorServices",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
