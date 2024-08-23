using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_Project.Migrations
{
    /// <inheritdoc />
    public partial class CourseTypeUniqueness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_departments_User_ManagerId",
                table: "departments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "coursesType",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_User_DepartmentId",
                table: "User",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_departments_User_ManagerId",
                table: "departments",
                column: "User_ManagerId",
                unique: true,
                filter: "[User_ManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_coursesType_Name",
                table: "coursesType",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_departments_DepartmentId",
                table: "User",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_departments_DepartmentId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_DepartmentId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_departments_User_ManagerId",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_coursesType_Name",
                table: "coursesType");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "coursesType",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_departments_User_ManagerId",
                table: "departments",
                column: "User_ManagerId");
        }
    }
}
