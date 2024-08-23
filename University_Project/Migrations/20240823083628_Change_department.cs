using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_Project.Migrations
{
    /// <inheritdoc />
    public partial class Change_department : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_User_User_ManagerId",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_departments_User_ManagerId",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "User_ManagerId",
                table: "departments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User_ManagerId",
                table: "departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_departments_User_ManagerId",
                table: "departments",
                column: "User_ManagerId",
                unique: true,
                filter: "[User_ManagerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_User_User_ManagerId",
                table: "departments",
                column: "User_ManagerId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
