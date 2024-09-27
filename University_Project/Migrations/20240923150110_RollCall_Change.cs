using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_Project.Migrations
{
    /// <inheritdoc />
    public partial class RollCall_Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfPresence",
                table: "rollCalls",
                newName: "sessionNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sessionNumber",
                table: "rollCalls",
                newName: "NumberOfPresence");
        }
    }
}
