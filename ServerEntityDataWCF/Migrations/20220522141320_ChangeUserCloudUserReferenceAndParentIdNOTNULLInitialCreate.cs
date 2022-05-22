using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerEntityDataWCF.Migrations
{
    public partial class ChangeUserCloudUserReferenceAndParentIdNOTNULLInitialCreate : Migration
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
                name: "IFolder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IFolder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IFolder_IFolder_ParentId",
                        column: x => x.ParentId,
                        principalTable: "IFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IFolder_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ParentId = table.Column<int>(nullable: false),
                    UserCloudId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchiveFiles_IFolder_ParentId",
                        column: x => x.ParentId,
                        principalTable: "IFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchiveFiles_IFolder_UserCloudId",
                        column: x => x.UserCloudId,
                        principalTable: "IFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_ParentId",
                table: "ArchiveFiles",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_UserCloudId",
                table: "ArchiveFiles",
                column: "UserCloudId");

            migrationBuilder.CreateIndex(
                name: "IX_IFolder_ParentId",
                table: "IFolder",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_IFolder_UserId",
                table: "IFolder",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchiveFiles");

            migrationBuilder.DropTable(
                name: "IFolder");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
