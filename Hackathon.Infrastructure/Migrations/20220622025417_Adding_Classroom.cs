using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Infrastructure.Migrations
{
    public partial class Adding_Classroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEA1P1zPsUhrTWSDF45nSRvdwhQ0ISh3BZPL5/r1uCXfU85VtA55UfSaTQKbgu6LIMA==");

            migrationBuilder.InsertData(
                table: "ClassRooms",
                columns: new[] { "Id", "Description", "InstructorId", "InstructorId1", "Name", "UpdatedAt" },
                values: new object[] { 10, "sale de teste", 1, null, "sala teste", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAENWPUoX5t8IrrPFgy2bdgbUV6SiQEU2pB8+HWRn864q/f29BGJgK8pCacLNnmTdzVQ==");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEB0RjWDu1AxJ1OVugwmF36s46aww/LGXxaafm4jzIE1haBK42wMNp/Z3IlKtSItLOw==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEBsWc/D0DLfDaKsfCB071/SwulSKmgw4Dj8v91kPIAmY8ZHOqJ6r0IAOw7karceldQ==");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEB2sb8GjXx93/9QBcmdxjU7yhBXYzE+lqkWUp9knzVM3q2YuUbVTv2mBi0zIWJsltA==");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEEit5xra9oOk4sUogpx3nmyChaSJJ1y9kUpa/89kg1sbLTvUFJ+ZY66Wl59mw4mpTg==");
        }
    }
}
