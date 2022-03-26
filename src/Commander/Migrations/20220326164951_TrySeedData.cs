using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commander.Migrations
{
    public partial class TrySeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Linux" },
                    { 2, "Git" },
                    { 3, "DotNet" }
                });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "AdminPrivilegesRequired", "HowTo", "Line", "PlatformId" },
                values: new object[,]
                {
                    { 1, false, "Check git repository status", "git status", 2 },
                    { 2, false, "Check disk usage", "df -h", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
