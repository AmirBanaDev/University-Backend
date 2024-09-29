using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_Project.Migrations
{
    /// <inheritdoc />
    public partial class add_user_favo_signs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseFavorite_User_UserId",
                table: "UserCourseFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseFavorite_courses_CourseId",
                table: "UserCourseFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseSignup_User_UserId",
                table: "UserCourseSignup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseSignup_courses_CourseId",
                table: "UserCourseSignup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCourseFavorite",
                table: "UserCourseFavorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCourseSignup",
                table: "UserCourseSignup");

            migrationBuilder.RenameTable(
                name: "UserCourseFavorite",
                newName: "userCourseFavorite");

            migrationBuilder.RenameTable(
                name: "UserCourseSignup",
                newName: "userCourseSignups");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourseFavorite_UserId",
                table: "userCourseFavorite",
                newName: "IX_userCourseFavorite_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourseFavorite_CourseId",
                table: "userCourseFavorite",
                newName: "IX_userCourseFavorite_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourseSignup_UserId",
                table: "userCourseSignups",
                newName: "IX_userCourseSignups_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourseSignup_CourseId",
                table: "userCourseSignups",
                newName: "IX_userCourseSignups_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userCourseFavorite",
                table: "userCourseFavorite",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userCourseSignups",
                table: "userCourseSignups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userCourseFavorite_User_UserId",
                table: "userCourseFavorite",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userCourseFavorite_courses_CourseId",
                table: "userCourseFavorite",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userCourseSignups_User_UserId",
                table: "userCourseSignups",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userCourseSignups_courses_CourseId",
                table: "userCourseSignups",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userCourseFavorite_User_UserId",
                table: "userCourseFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_userCourseFavorite_courses_CourseId",
                table: "userCourseFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_userCourseSignups_User_UserId",
                table: "userCourseSignups");

            migrationBuilder.DropForeignKey(
                name: "FK_userCourseSignups_courses_CourseId",
                table: "userCourseSignups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userCourseFavorite",
                table: "userCourseFavorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userCourseSignups",
                table: "userCourseSignups");

            migrationBuilder.RenameTable(
                name: "userCourseFavorite",
                newName: "UserCourseFavorite");

            migrationBuilder.RenameTable(
                name: "userCourseSignups",
                newName: "UserCourseSignup");

            migrationBuilder.RenameIndex(
                name: "IX_userCourseFavorite_UserId",
                table: "UserCourseFavorite",
                newName: "IX_UserCourseFavorite_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_userCourseFavorite_CourseId",
                table: "UserCourseFavorite",
                newName: "IX_UserCourseFavorite_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_userCourseSignups_UserId",
                table: "UserCourseSignup",
                newName: "IX_UserCourseSignup_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_userCourseSignups_CourseId",
                table: "UserCourseSignup",
                newName: "IX_UserCourseSignup_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCourseFavorite",
                table: "UserCourseFavorite",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCourseSignup",
                table: "UserCourseSignup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseFavorite_User_UserId",
                table: "UserCourseFavorite",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseFavorite_courses_CourseId",
                table: "UserCourseFavorite",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseSignup_User_UserId",
                table: "UserCourseSignup",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseSignup_courses_CourseId",
                table: "UserCourseSignup",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
