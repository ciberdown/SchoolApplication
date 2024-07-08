using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApplication.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Scholarships",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Scholarships");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scholarships",
                table: "Scholarships",
                columns: new[] { "StudentId", "AimSchoolId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Scholarships",
                table: "Scholarships");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Scholarships",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scholarships",
                table: "Scholarships",
                column: "Id");
        }
    }
}
