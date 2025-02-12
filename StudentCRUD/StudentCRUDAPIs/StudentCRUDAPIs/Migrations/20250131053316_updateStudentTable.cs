using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCRUDAPIs.Migrations
{
    /// <inheritdoc />
    public partial class updateStudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentGender",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentGender",
                table: "Students");
        }
    }
}
