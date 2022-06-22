using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Infrastructure.Migrations
{
    public partial class migration_teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "AQAAAAEAAAPoAAAAEA1P1zPsUhrTWSDF45nSRvdwhQ0ISh3BZPL5/r1uCXfU85VtA55UfSaTQKbgu6LIMA==");

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
    }
}
