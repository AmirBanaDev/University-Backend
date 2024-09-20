using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_Project.Migrations
{
    /// <inheritdoc />
    public partial class Course_Time_Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionHour",
                table: "courses");

            migrationBuilder.RenameColumn(
                name: "SessionMinute",
                table: "courses",
                newName: "SessionTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessionTime",
                table: "courses",
                newName: "SessionMinute");

            migrationBuilder.AddColumn<int>(
                name: "SessionHour",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
