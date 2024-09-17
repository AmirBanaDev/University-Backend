using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_Project.Migrations
{
    /// <inheritdoc />
    public partial class CourseContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "coursesContent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_courses_CourseId",
                table: "courses",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_courses_CourseId",
                table: "courses",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_courses_CourseId",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_CourseId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "coursesContent");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "courses");
        }
    }
}
