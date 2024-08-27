using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_Project.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionLength",
                table: "courses");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Schedule",
                table: "courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SessionHour",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessionMinute",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_courses_DepartmentId",
                table: "courses",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_departments_DepartmentId",
                table: "courses",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_departments_DepartmentId",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_DepartmentId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "SessionHour",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "SessionMinute",
                table: "courses");

            migrationBuilder.AddColumn<float>(
                name: "SessionLength",
                table: "courses",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
