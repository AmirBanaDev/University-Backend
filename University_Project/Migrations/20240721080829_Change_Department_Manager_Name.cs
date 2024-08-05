using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_Project.Migrations
{
    /// <inheritdoc />
    public partial class Change_Department_Manager_Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_User_ManagerId",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_departments_ManagerId",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "departments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "departments",
                newName: "User_ManagerId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_departments_User_ManagerId",
                table: "departments",
                column: "User_ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_User_User_ManagerId",
                table: "departments",
                column: "User_ManagerId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_User_User_ManagerId",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_departments_User_ManagerId",
                table: "departments");

            migrationBuilder.RenameColumn(
                name: "User_ManagerId",
                table: "departments",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_departments_ManagerId",
                table: "departments",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_User_ManagerId",
                table: "departments",
                column: "ManagerId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
