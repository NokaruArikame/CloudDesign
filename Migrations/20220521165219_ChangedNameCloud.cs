using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerEntityDataWCF.Migrations
{
    public partial class ChangedNameCloud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_ArchiveFolders_UserFolderId",
                table: "ArchiveFolders");

            migrationBuilder.DropIndex(
                name: "IX_ArchiveFiles_UserFolderId",
                table: "ArchiveFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFolders",
                table: "UserFolders");

            migrationBuilder.DropColumn(
                name: "UserFolderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserFolderId",
                table: "ArchiveFolders");

            migrationBuilder.DropColumn(
                name: "UserFolderId",
                table: "ArchiveFiles");

            migrationBuilder.RenameTable(
                name: "UserFolders",
                newName: "UsersClouds");

            migrationBuilder.AddColumn<int>(
                name: "UserCloudId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCloudId",
                table: "ArchiveFolders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCloudId",
                table: "ArchiveFiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersClouds",
                table: "UsersClouds",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCloudId",
                table: "Users",
                column: "UserCloudId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFolders_UserCloudId",
                table: "ArchiveFolders",
                column: "UserCloudId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_UserCloudId",
                table: "ArchiveFiles",
                column: "UserCloudId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFiles_UsersClouds_UserCloudId",
                table: "ArchiveFiles",
                column: "UserCloudId",
                principalTable: "UsersClouds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFolders_UsersClouds_UserCloudId",
                table: "ArchiveFolders",
                column: "UserCloudId",
                principalTable: "UsersClouds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersClouds_UserCloudId",
                table: "Users",
                column: "UserCloudId",
                principalTable: "UsersClouds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_UsersClouds_UserCloudId",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFolders_UsersClouds_UserCloudId",
                table: "ArchiveFolders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersClouds_UserCloudId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserCloudId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ArchiveFolders_UserCloudId",
                table: "ArchiveFolders");

            migrationBuilder.DropIndex(
                name: "IX_ArchiveFiles_UserCloudId",
                table: "ArchiveFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersClouds",
                table: "UsersClouds");

            migrationBuilder.DropColumn(
                name: "UserCloudId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserCloudId",
                table: "ArchiveFolders");

            migrationBuilder.DropColumn(
                name: "UserCloudId",
                table: "ArchiveFiles");

            migrationBuilder.RenameTable(
                name: "UsersClouds",
                newName: "UserFolders");

            migrationBuilder.AddColumn<int>(
                name: "UserFolderId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserFolderId",
                table: "ArchiveFolders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserFolderId",
                table: "ArchiveFiles",
                type: "int",
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

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFolders_UserFolderId",
                table: "ArchiveFolders",
                column: "UserFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_UserFolderId",
                table: "ArchiveFiles",
                column: "UserFolderId");

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
    }
}
