using Microsoft.EntityFrameworkCore.Migrations;

namespace MySchoolProject.Migrations
{
    public partial class EditUserIdCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CustomUserClaims",
                newName: "CustomUserUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomUserUserId",
                table: "CustomUserClaims",
                newName: "UserId");
        }
    }
}
