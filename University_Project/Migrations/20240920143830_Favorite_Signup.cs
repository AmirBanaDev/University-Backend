using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_Project.Migrations
{
    /// <inheritdoc />
    public partial class Favorite_Signup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_courses_CourseId",
                table: "courses");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "courses",
                newName: "Signup");

            migrationBuilder.RenameIndex(
                name: "IX_courses_CourseId",
                table: "courses",
                newName: "IX_courses_Signup");

            migrationBuilder.AddColumn<int>(
                name: "Favorite",
                table: "courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserCourseFavorite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourseFavorite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCourseFavorite_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourseFavorite_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCourseSignup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourseSignup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCourseSignup_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourseSignup_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses_Favorite",
                table: "courses",
                column: "Favorite");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseFavorite_CourseId",
                table: "UserCourseFavorite",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseFavorite_UserId",
                table: "UserCourseFavorite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseSignup_CourseId",
                table: "UserCourseSignup",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseSignup_UserId",
                table: "UserCourseSignup",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_User_Favorite",
                table: "courses",
                column: "Favorite",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_User_Signup",
                table: "courses",
                column: "Signup",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_User_Favorite",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_courses_User_Signup",
                table: "courses");

            migrationBuilder.DropTable(
                name: "UserCourseFavorite");

            migrationBuilder.DropTable(
                name: "UserCourseSignup");

            migrationBuilder.DropIndex(
                name: "IX_courses_Favorite",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "courses");

            migrationBuilder.RenameColumn(
                name: "Signup",
                table: "courses",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_courses_Signup",
                table: "courses",
                newName: "IX_courses_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_courses_CourseId",
                table: "courses",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id");
        }
    }
}
