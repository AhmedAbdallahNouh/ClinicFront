using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClincApi.Migrations
{
    /// <inheritdoc />
    public partial class v4addDescriptionColumntoConsultationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Consultations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Consultations");
        }
    }
}
