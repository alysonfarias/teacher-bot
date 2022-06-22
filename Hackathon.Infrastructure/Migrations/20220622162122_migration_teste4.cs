using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Infrastructure.Migrations
{
    public partial class migration_teste4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
