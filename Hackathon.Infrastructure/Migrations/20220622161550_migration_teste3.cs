using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Infrastructure.Migrations
{
    public partial class migration_teste3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEFOvI1dav7/aDZNt4A5UuO5W5kR6KEjDy/7qEeZPLjA8zqdPG7B4TYh4NeyD3LXfRg==");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEP/UHTLm2GzW1WcrOkFHXHJnN3JCT9Ll1KbDsX8Wvc5WegasKU4HrHU2ytvbdfzndw==");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAAAPoAAAAEBd978dVlufCH2P+PiAeXKIPqGMn9sCSJ2lpjzmePlybOqlCwhdoeEmiLmDJHy4Z7A==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
