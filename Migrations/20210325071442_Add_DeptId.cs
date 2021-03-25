using Microsoft.EntityFrameworkCore.Migrations;

namespace MySchoolProject.Migrations
{
    public partial class Add_DeptId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "AdmissionLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionLists_DepartmentId",
                table: "AdmissionLists",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionLists_Departments_DepartmentId",
                table: "AdmissionLists",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionLists_Departments_DepartmentId",
                table: "AdmissionLists");

            migrationBuilder.DropIndex(
                name: "IX_AdmissionLists_DepartmentId",
                table: "AdmissionLists");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AdmissionLists");
        }
    }
}
