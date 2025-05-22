using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectTracker.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InAppPrioritiy = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUsers",
                columns: table => new
                {
                    AssignedUsersId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUsers", x => new { x.AssignedUsersId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_ProjectUsers_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUsers_Users_AssignedUsersId",
                        column: x => x.AssignedUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkItemStatus = table.Column<int>(type: "int", nullable: false),
                    InAppPrioritiy = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    AssignedUserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkItems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkItems_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "InAppPrioritiy", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Description for project 1", 0, "Project 1", 1 },
                    { 2, "Description for project 2", 1, "Project 2", 0 },
                    { 3, "Entity ilişkilerini test etmek için örnek proje", 2, "Proje Takip Sistemi", 1 },
                    { 4, "Takip uygulaması", 2, "iş Yönetimi Sistemi", 1 },
                    { 5, "Müşteri ilişkileri yönetimi", 1, "CRM Yazılımı", 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Developer" },
                    { 3, "Project Manager" },
                    { 4, "Tester" },
                    { 5, "User" },
                    { 6, "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Mail", "Name", "RoleId", "Surname" },
                values: new object[,]
                {
                    { 1, "ali@example.com", "Ali", 1, "Yılmaz" },
                    { 2, "ahmet.yilmaz@example.com", "Ahmet", 1, "Yılmaz" },
                    { 3, "ayse@example.com", "Ayşe", 2, "Demir" },
                    { 4, "ayse.kara@example.com", "Ayşe", 2, "Kara" },
                    { 5, "muhammet@example.com", "Muhammet", 2, "Deneme" },
                    { 6, "efe@example.com", "Efe", 3, "Can" },
                    { 7, "mehmet.demir@example.com", "Mehmet", 3, "Demir" },
                    { 8, "elif.celik@example.com", "Elif", 4, "Çelik" }
                });

            migrationBuilder.InsertData(
                table: "ProjectUsers",
                columns: new[] { "AssignedUsersId", "ProjectsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "Id", "AssignedUserId", "Description", "InAppPrioritiy", "Name", "ProjectId", "WorkItemStatus" },
                values: new object[,]
                {
                    { 1, 2, "Login ekranı yapılacak", 2, "Kullanıcı Girişi", 1, 1 },
                    { 2, 3, "Raporlama eklenecek", 1, "Raporlama Modülü", 1, 0 },
                    { 3, 4, "Listeleme ekranı", 0, "Müşteri Listesi", 2, 0 },
                    { 4, 2, "ProjectController yazılacak", 1, "API geliştirme", 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_ProjectsId",
                table: "ProjectUsers",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_AssignedUserId",
                table: "WorkItems",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_ProjectId",
                table: "WorkItems",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectUsers");

            migrationBuilder.DropTable(
                name: "WorkItems");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
