using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySchoolProject.Migrations
{
    public partial class changecolname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomUserClaims_CustomUsers_CustomUserId",
                table: "CustomUserClaims");

            migrationBuilder.DropColumn(
                name: "CustomUserUserId",
                table: "CustomUserClaims");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomUserId",
                table: "CustomUserClaims",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomUserClaims_CustomUsers_CustomUserId",
                table: "CustomUserClaims",
                column: "CustomUserId",
                principalTable: "CustomUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomUserClaims_CustomUsers_CustomUserId",
                table: "CustomUserClaims");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomUserId",
                table: "CustomUserClaims",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomUserUserId",
                table: "CustomUserClaims",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_CustomUserClaims_CustomUsers_CustomUserId",
                table: "CustomUserClaims",
                column: "CustomUserId",
                principalTable: "CustomUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
