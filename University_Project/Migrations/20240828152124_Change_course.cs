using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_Project.Migrations
{
    /// <inheritdoc />
    public partial class Change_course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_User_UserId",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_UserId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_courses_UserId",
                table: "courses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_User_UserId",
                table: "courses",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
