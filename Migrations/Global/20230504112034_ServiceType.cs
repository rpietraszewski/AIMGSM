using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIMGSM.Migrations.Global
{
    /// <inheritdoc />
    public partial class ServiceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Service",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Service");
        }
    }
}
