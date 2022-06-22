using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Infrastructure.Migrations
{
    public partial class migration_teste6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ClassRooms_ClassRoomId1",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ClassRoomId1",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ClassRoomId1",
                table: "Activities");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassRoomId1",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEDCDRQ+om9ZEJGr8X/NJc+uqocYO/sWr/Lo0GdQ16L4JuzHo14WReOoynLJrxdOoBQ==");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEG6obSlUlU7Y7LG9MxAtVZc2P0jloGiHqCHJvtLJ0UTlEhLO97OzM0hP9862xlTygA==");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEM+LQBijyxQNTXH/iu4v7RakoLf8H0LilFZMXQUUjxmV4Ig1ByXxFVQ2Pnn179058Q==");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ClassRoomId1",
                table: "Activities",
                column: "ClassRoomId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ClassRooms_ClassRoomId1",
                table: "Activities",
                column: "ClassRoomId1",
                principalTable: "ClassRooms",
                principalColumn: "Id");
        }
    }
}
