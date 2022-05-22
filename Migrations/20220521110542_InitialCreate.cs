using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerEntityDataWCF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCloud",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFolder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFolder_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArchiveFolders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    ArchiveFolderId = table.Column<int>(nullable: true),
                    UserFolderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveFolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchiveFolders_ArchiveFolders_ArchiveFolderId",
                        column: x => x.ArchiveFolderId,
                        principalTable: "ArchiveFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArchiveFolders_UserFolder_UserFolderId",
                        column: x => x.UserFolderId,
                        principalTable: "UserCloud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArchiveFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ParentFolderId = table.Column<int>(nullable: true),
                    UserFolderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchiveFiles_ArchiveFolders_ParentFolderId",
                        column: x => x.ParentFolderId,
                        principalTable: "ArchiveFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArchiveFiles_UserFolder_UserFolderId",
                        column: x => x.UserFolderId,
                        principalTable: "UserCloud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_ParentFolderId",
                table: "ArchiveFiles",
                column: "ParentFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_UserFolderId",
                table: "ArchiveFiles",
                column: "UserFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFolders_ArchiveFolderId",
                table: "ArchiveFolders",
                column: "ArchiveFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFolders_UserFolderId",
                table: "ArchiveFolders",
                column: "UserFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFolder_UserId",
                table: "UserCloud",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchiveFiles");

            migrationBuilder.DropTable(
                name: "ArchiveFolders");

            migrationBuilder.DropTable(
                name: "UserCloud");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
