using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Infrastructure.Migrations
{
    public partial class migration_teste5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arquives_Activities_ActivityId1",
                table: "Arquives");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_Instructors_InstructorId1",
                table: "ClassRooms");

            migrationBuilder.DropIndex(
                name: "IX_ClassRooms_InstructorId1",
                table: "ClassRooms");

            migrationBuilder.DropIndex(
                name: "IX_Arquives_ActivityId1",
                table: "Arquives");

            migrationBuilder.DropColumn(
                name: "InstructorId1",
                table: "ClassRooms");

            migrationBuilder.DropColumn(
                name: "ActivityId1",
                table: "Arquives");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstructorId1",
                table: "ClassRooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId1",
                table: "Arquives",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEF94oNJh/MKd9dL5OKGaguUFKi8kDNmh6//gRy5abSoCTcQEd/HJAK7W/WQt9/6KuA==");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEAOyO/0u9B/fuS4txWpSkWD0bzkaesyrVVST6auIP1CBZcMkzuokESr8kjtqLhwwag==");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEDadMaqMIleF6ZyNaQ99lKwBFXyWEcq44wt+wCCqochRiEVKiWARAXZaIR8fdM51ow==");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_InstructorId1",
                table: "ClassRooms",
                column: "InstructorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Arquives_ActivityId1",
                table: "Arquives",
                column: "ActivityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Arquives_Activities_ActivityId1",
                table: "Arquives",
                column: "ActivityId1",
                principalTable: "Activities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_Instructors_InstructorId1",
                table: "ClassRooms",
                column: "InstructorId1",
                principalTable: "Instructors",
                principalColumn: "Id");
        }
    }
}
