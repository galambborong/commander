using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commander.Migrations
{
    public partial class UpdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Shell" },
                    { 5, "Arduino" },
                    { 6, "Docker" }
                });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "AdminPrivilegesRequired", "HowTo", "Line", "PlatformId" },
                values: new object[,]
                {
                    { 3, false, "Run Docker Image in background; removing container once finished; with nice logging format", "docker run -d --rm -p <ext>:<int> -e Logging__Console__FormatterName=\"\" <namespace>/<image>:<tag>", 6 },
                    { 4, false, "List current Docker processes (containers)", "docker ps", 6 },
                    { 5, false, "Build Docker image from Dockerfile", "docker build <pwd> -t <namespace>/<image>:<tag>", 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
