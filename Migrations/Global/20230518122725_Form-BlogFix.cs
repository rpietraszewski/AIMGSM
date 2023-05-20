using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIMGSM.Migrations.Global
{
    /// <inheritdoc />
    public partial class FormBlogFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Form",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Form");
        }
    }
}
