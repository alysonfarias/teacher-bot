using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Infrastructure.Migrations
{
    public partial class migration_teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                value: "AQAAAAEAAAPoAAAAEDElrsvZVsnVF/Ukt48iZ4UlWtJ0S0NcimQOKwsZMQeSbOK5WPGGgzIVXRC8e8QI5g==");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEJlF28Xl49ikFfTUt5ht85nz5cCNGZzhFzHPglz4Q1qRUXF7hVkhNOK/yWR0+fmKQg==");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAECoU1zgDdLo+739X+uzTV8noB59CwMsj5W4EmKxqIN5FPA755QIw0fNuczyC3QINpA==");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arquives_Activities_ActivityId1",
                table: "Arquives");

            migrationBuilder.DropIndex(
                name: "IX_Arquives_ActivityId1",
                table: "Arquives");

            migrationBuilder.DropColumn(
                name: "ActivityId1",
                table: "Arquives");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEGls60SWpLo+rxWJI4chI/kJKjyH11AYJHvjfGf2lG6BGZh5rgufGeC8/zDd+jkI1A==");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEC/58/vORHjAuS+pMFInxwkjrJcrYH55dibVRK1amP3pBfNFba7L7JRQWQTTG/6Csw==");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEKMz6AxMvjpy735v0ifCEg2zXjMpAVzKyCgujmT2KoY3SxIFvWBe+giehpu7JDn7ZQ==");
        }
    }
}
