using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Infrastructure.Migrations
{
    public partial class restruturandofiletype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_User_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_User_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_tb_User_Roles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "tb_User_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_tb_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "tb_Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instructors_tb_User_Roles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "tb_User_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponsiblePhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_tb_User_Roles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "tb_User_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRooms_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_ClassRooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_student_classroom",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_student_classroom", x => new { x.ClassRoomId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_tb_student_classroom_ClassRooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_student_classroom_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arquives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataBase64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arquives_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_DeliveryActive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataBase64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_DeliveryActive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_DeliveryActive_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_DeliveryActive_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Portuguese" },
                    { 2, "Mathematics" },
                    { 3, "Programming" },
                    { 4, "English" }
                });

            migrationBuilder.InsertData(
                table: "tb_User_Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Instructor" },
                    { 3, "Student" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "Email", "Name", "Password", "UpdatedAt", "UserRoleId", "Username" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@api.com", "Admin Root Application", "AQAAAAEAAAPoAAAAEKIgds7XGuDN6g6Ge+rtxdATeYyrMFbKORh0wp4jll6gF+wTzaDz1wU4L7HkD/ACMA==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "admin" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "Email", "Name", "Password", "SubjectId", "UpdatedAt", "UserRoleId", "Username" },
                values: new object[] { 1, new DateTime(2001, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "instru@api.com", "kleber", "AQAAAAEAAAPoAAAAEF3dfquH0U/CqfDu38XkFprC7/lqX623KanwdHVqhY2zPhdPuvKsGiF0WYU7rQkXRQ==", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "instru" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "Email", "Name", "Password", "ResponsiblePhone", "UpdatedAt", "UserRoleId", "Username" },
                values: new object[] { 1, new DateTime(2001, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "instru@api.com", "kleber", "AQAAAAEAAAPoAAAAEMBsjwiEvqMqqaXVpTdRWyEK9zdA+h62b4oDYUDIjo/4sul9rFrxsS0X+ql0qerUJA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "instru" });

            migrationBuilder.InsertData(
                table: "ClassRooms",
                columns: new[] { "Id", "Description", "InstructorId", "Name", "UpdatedAt" },
                values: new object[] { 10, "sale de teste", 1, "sala teste", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ClassRoomId",
                table: "Activities",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserRoleId",
                table: "Admins",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Arquives_ActivityId",
                table: "Arquives",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_InstructorId",
                table: "ClassRooms",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_SubjectId",
                table: "Instructors",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserRoleId",
                table: "Instructors",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserRoleId",
                table: "Students",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_DeliveryActive_ActivityId",
                table: "Tb_DeliveryActive",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_DeliveryActive_StudentId",
                table: "Tb_DeliveryActive",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_student_classroom_StudentId",
                table: "tb_student_classroom",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Arquives");

            migrationBuilder.DropTable(
                name: "Tb_DeliveryActive");

            migrationBuilder.DropTable(
                name: "tb_student_classroom");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ClassRooms");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "tb_Subjects");

            migrationBuilder.DropTable(
                name: "tb_User_Roles");
        }
    }
}
