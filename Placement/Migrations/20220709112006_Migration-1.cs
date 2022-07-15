using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Placement.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Native_place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reg_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile_No = table.Column<int>(type: "int", nullable: false),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSLC = table.Column<float>(type: "real", nullable: false),
                    XII = table.Column<float>(type: "real", nullable: false),
                    Diploma = table.Column<float>(type: "real", nullable: false),
                    HOA = table.Column<int>(type: "int", nullable: false),
                    SA = table.Column<int>(type: "int", nullable: false),
                    CGPA = table.Column<float>(type: "real", nullable: false),
                    AOI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.StudentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");
        }
    }
}
