using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectTracker.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "InAppPrioritiy", "ProjectDescription", "ProjectName", "ProjectStatus" },
                values: new object[] { 1, 2, "Entity ilişkilerini test etmek için örnek proje", "Proje Takip Sistemi", 1 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Developer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Mail", "Name", "RoleId", "Surname" },
                values: new object[,]
                {
                    { 1, "ali@example.com", "Ali", 1, "Yılmaz" },
                    { 2, "ayse@example.com", "Ayşe", 2, "Demir" }
                });

            migrationBuilder.InsertData(
                table: "ProjectUsers",
                columns: new[] { "AssignedUsersUserId", "ProjectsProjectId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "WorkItemId", "AssignedUserId", "Description", "InAppPrioritiy", "ProjectId", "Title", "WorkItemStatus" },
                values: new object[] { 1, 2, "ProjectController yazılacak", 1, 1, "API geliştirme", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectUsers",
                keyColumns: new[] { "AssignedUsersUserId", "ProjectsProjectId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectUsers",
                keyColumns: new[] { "AssignedUsersUserId", "ProjectsProjectId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "WorkItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2);
        }
    }
}
