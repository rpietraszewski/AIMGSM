using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIMGSM.Migrations.Global
{
    /// <inheritdoc />
    public partial class ImageDevice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Device",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Device");
        }
    }
}
