using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Infrastructure.Migrations
{
    public partial class second_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEE+cSTTaqnn01FD/sKAm6OEr+hzuV1b6lnolVW1qAw1qooW+AZEAh4xAS+4B0A/ctA==");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEIk4bJ6uc3LxVbxiFHJ0nptlzWxXiPItDbVovQEHimxhW77MCBjItW3v43+JUyPXng==");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEOwkt382ru5IKhxHycPreqr91dw/0gQzDG/2haVutBoRI/jrWlwlg8AP/XbDVWxYJg==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAECBPzeAlLNoe3NwI/AF+QPam5pZmRzIYGgHHTHFy3XLW8DEKEM+b4jXLx7uAaWpKsQ==");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAECcckFeqkJmA7kpUHIHsyvduwn/kA3TILokKVQzCU8xRRKYdi4WniRjZbO7gr0XNag==");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEFD+TB/4pu+0whZLSZFdXHaPt5t/pvyE9T3LLWUgbtkFqIDVXvKbGPfl5NaKFL549A==");
        }
    }
}
