using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Infrastructure.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    userName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_instructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_instructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_instructor_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_instructor_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ResponsiblePhones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_student_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_classroom",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_classroom", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_classroom_tb_instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "tb_instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_activity",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: false),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false),
                    dueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_activity", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_activity_tb_classroom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "tb_classroom",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_student_classroom",
                columns: table => new
                {
                    id_classroom = table.Column<int>(type: "int", nullable: false),
                    id_student = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_student_classroom", x => new { x.id_classroom, x.id_student });
                    table.ForeignKey(
                        name: "FK_tb_student_classroom_tb_classroom_id_classroom",
                        column: x => x.id_classroom,
                        principalTable: "tb_classroom",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_student_classroom_tb_student_id_student",
                        column: x => x.id_student,
                        principalTable: "tb_student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_arquive",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    dataBase64 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    ActivityId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_arquive", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_arquive_FileTypes_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_arquive_tb_activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "tb_activity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_arquive_tb_activity_ActivityId1",
                        column: x => x.ActivityId1,
                        principalTable: "tb_activity",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_arquive_tb_classroom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "tb_classroom",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FileTypes",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "PDF" },
                    { 2, "PNG" },
                    { 3, "JPEG" },
                    { 4, "JPG" },
                    { 5, "MP3" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Portuguese" },
                    { 2, "Mathematics" },
                    { 3, "Programming" },
                    { 4, "English" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Instructor" },
                    { 3, "Student" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "birthDate", "CreatedAt", "email", "name", "password", "UpdatedAt", "UserRoleId", "userName" },
                values: new object[] { 1, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@api.com", "Admin Root Application", "AQAAAAEAAAPoAAAAEPx+ytbWRKAc+Yjy05HlGh3gHVAl2EN18T99RSjA5WJ2hUDS6mFKq56fSkf+NdP8Og==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_activity_ClassRoomId",
                table: "tb_activity",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_activity_id",
                table: "tb_activity",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_arquive_ActivityId",
                table: "tb_arquive",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_arquive_ActivityId1",
                table: "tb_arquive",
                column: "ActivityId1");

            migrationBuilder.CreateIndex(
                name: "IX_tb_arquive_ClassRoomId",
                table: "tb_arquive",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_arquive_FileTypeId",
                table: "tb_arquive",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_arquive_id",
                table: "tb_arquive",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_classroom_id",
                table: "tb_classroom",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_classroom_InstructorId",
                table: "tb_classroom",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_instructor_SubjectId",
                table: "tb_instructor",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_student_classroom_id_student",
                table: "tb_student_classroom",
                column: "id_student");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_arquive");

            migrationBuilder.DropTable(
                name: "tb_student_classroom");

            migrationBuilder.DropTable(
                name: "FileTypes");

            migrationBuilder.DropTable(
                name: "tb_activity");

            migrationBuilder.DropTable(
                name: "tb_student");

            migrationBuilder.DropTable(
                name: "tb_classroom");

            migrationBuilder.DropTable(
                name: "tb_instructor");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
