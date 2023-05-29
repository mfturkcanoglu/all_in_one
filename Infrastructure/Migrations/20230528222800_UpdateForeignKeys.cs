using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_AspNetUsers_LecturerId1",
                table: "course");

            migrationBuilder.DropForeignKey(
                name: "FK_course_student_AspNetUsers_StudentId1",
                table: "course_student");

            migrationBuilder.DropIndex(
                name: "IX_course_student_StudentId1",
                table: "course_student");

            migrationBuilder.DropIndex(
                name: "IX_course_LecturerId1",
                table: "course");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "course_student");

            migrationBuilder.DropColumn(
                name: "LecturerId1",
                table: "course");

            migrationBuilder.AlterColumn<string>(
                name: "student_id",
                table: "course_student",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "lecturer_id",
                table: "course",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_course_student_student_id",
                table: "course_student",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_course_lecturer_id",
                table: "course",
                column: "lecturer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_course_AspNetUsers_lecturer_id",
                table: "course",
                column: "lecturer_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_course_student_AspNetUsers_student_id",
                table: "course_student",
                column: "student_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_AspNetUsers_lecturer_id",
                table: "course");

            migrationBuilder.DropForeignKey(
                name: "FK_course_student_AspNetUsers_student_id",
                table: "course_student");

            migrationBuilder.DropIndex(
                name: "IX_course_student_student_id",
                table: "course_student");

            migrationBuilder.DropIndex(
                name: "IX_course_lecturer_id",
                table: "course");

            migrationBuilder.AlterColumn<Guid>(
                name: "student_id",
                table: "course_student",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "StudentId1",
                table: "course_student",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "lecturer_id",
                table: "course",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "LecturerId1",
                table: "course",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_course_student_StudentId1",
                table: "course_student",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_course_LecturerId1",
                table: "course",
                column: "LecturerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_course_AspNetUsers_LecturerId1",
                table: "course",
                column: "LecturerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_course_student_AspNetUsers_StudentId1",
                table: "course_student",
                column: "StudentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
