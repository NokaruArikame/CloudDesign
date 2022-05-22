using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerEntityDataWCF.Migrations
{
    public partial class ChangedDependecies1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_UserFolder_UserFolderId",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFolders_UserFolder_UserFolderId",
                table: "ArchiveFolders");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFolder_Users_UserId",
                table: "UserCloud");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFolder",
                table: "UserCloud");

            migrationBuilder.DropIndex(
                name: "IX_UserFolder_UserId",
                table: "UserCloud");

            migrationBuilder.RenameTable(
                name: "UserCloud",
                newName: "UserFolders");

            migrationBuilder.AddColumn<int>(
                name: "UserFolderId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFolders",
                table: "UserFolders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserFolderId",
                table: "Users",
                column: "UserFolderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFiles_UserFolders_UserFolderId",
                table: "ArchiveFiles",
                column: "UserFolderId",
                principalTable: "UserFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFolders_UserFolders_UserFolderId",
                table: "ArchiveFolders",
                column: "UserFolderId",
                principalTable: "UserFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserFolders_UserFolderId",
                table: "Users",
                column: "UserFolderId",
                principalTable: "UserFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_UserFolders_UserFolderId",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFolders_UserFolders_UserFolderId",
                table: "ArchiveFolders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserFolders_UserFolderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserFolderId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFolders",
                table: "UserFolders");

            migrationBuilder.DropColumn(
                name: "UserFolderId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "UserFolders",
                newName: "UserCloud");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFolder",
                table: "UserCloud",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserFolder_UserId",
                table: "UserCloud",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFiles_UserFolder_UserFolderId",
                table: "ArchiveFiles",
                column: "UserFolderId",
                principalTable: "UserCloud",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFolders_UserFolder_UserFolderId",
                table: "ArchiveFolders",
                column: "UserFolderId",
                principalTable: "UserCloud",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFolder_Users_UserId",
                table: "UserCloud",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
