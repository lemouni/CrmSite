using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Courses_Courses_Courseid",
                table: "Teacher_Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Courses_Teachers_Teacherid",
                table: "Teacher_Courses");

            migrationBuilder.AlterColumn<int>(
                name: "Teacherid",
                table: "Teacher_Courses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Courseid",
                table: "Teacher_Courses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Courses_Courses_Courseid",
                table: "Teacher_Courses",
                column: "Courseid",
                principalTable: "Courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Courses_Teachers_Teacherid",
                table: "Teacher_Courses",
                column: "Teacherid",
                principalTable: "Teachers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Courses_Courses_Courseid",
                table: "Teacher_Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Courses_Teachers_Teacherid",
                table: "Teacher_Courses");

            migrationBuilder.AlterColumn<int>(
                name: "Teacherid",
                table: "Teacher_Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Courseid",
                table: "Teacher_Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Courses_Courses_Courseid",
                table: "Teacher_Courses",
                column: "Courseid",
                principalTable: "Courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Courses_Teachers_Teacherid",
                table: "Teacher_Courses",
                column: "Teacherid",
                principalTable: "Teachers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
