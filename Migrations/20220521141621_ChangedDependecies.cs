using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerEntityDataWCF.Migrations
{
    public partial class ChangedDependecies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_ArchiveFolders_ParentFolderId",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_UserFolder_UserFolderId",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFolders_ArchiveFolders_ArchiveFolderId",
                table: "ArchiveFolders");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFolders_UserFolder_UserFolderId",
                table: "ArchiveFolders");

            migrationBuilder.DropIndex(
                name: "IX_ArchiveFolders_ArchiveFolderId",
                table: "ArchiveFolders");

            migrationBuilder.DropIndex(
                name: "IX_ArchiveFiles_ParentFolderId",
                table: "ArchiveFiles");

            migrationBuilder.DropColumn(
                name: "ArchiveFolderId",
                table: "ArchiveFolders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ArchiveFolders");

            migrationBuilder.DropColumn(
                name: "ParentFolderId",
                table: "ArchiveFiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ArchiveFiles");

            migrationBuilder.AlterColumn<int>(
                name: "UserFolderId",
                table: "ArchiveFolders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "ArchiveFolders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserFolderId",
                table: "ArchiveFiles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "ArchiveFiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFolders_FolderId",
                table: "ArchiveFolders",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_ParentId",
                table: "ArchiveFiles",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFiles_ArchiveFolders_ParentId",
                table: "ArchiveFiles",
                column: "ParentId",
                principalTable: "ArchiveFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFiles_UserFolder_UserFolderId",
                table: "ArchiveFiles",
                column: "UserFolderId",
                principalTable: "UserCloud",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFolders_ArchiveFolders_FolderId",
                table: "ArchiveFolders",
                column: "ParentId",
                principalTable: "ArchiveFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFolders_UserFolder_UserFolderId",
                table: "ArchiveFolders",
                column: "UserFolderId",
                principalTable: "UserCloud",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_ArchiveFolders_ParentId",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_UserFolder_UserFolderId",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFolders_ArchiveFolders_FolderId",
                table: "ArchiveFolders");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFolders_UserFolder_UserFolderId",
                table: "ArchiveFolders");

            migrationBuilder.DropIndex(
                name: "IX_ArchiveFolders_FolderId",
                table: "ArchiveFolders");

            migrationBuilder.DropIndex(
                name: "IX_ArchiveFiles_ParentId",
                table: "ArchiveFiles");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ArchiveFolders");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ArchiveFiles");

            migrationBuilder.AlterColumn<int>(
                name: "UserFolderId",
                table: "ArchiveFolders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ArchiveFolderId",
                table: "ArchiveFolders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ArchiveFolders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserFolderId",
                table: "ArchiveFiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ParentFolderId",
                table: "ArchiveFiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ArchiveFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFolders_ArchiveFolderId",
                table: "ArchiveFolders",
                column: "ArchiveFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveFiles_ParentFolderId",
                table: "ArchiveFiles",
                column: "ParentFolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFiles_ArchiveFolders_ParentFolderId",
                table: "ArchiveFiles",
                column: "ParentFolderId",
                principalTable: "ArchiveFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFiles_UserFolder_UserFolderId",
                table: "ArchiveFiles",
                column: "UserFolderId",
                principalTable: "UserCloud",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFolders_ArchiveFolders_ArchiveFolderId",
                table: "ArchiveFolders",
                column: "ArchiveFolderId",
                principalTable: "ArchiveFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFolders_UserFolder_UserFolderId",
                table: "ArchiveFolders",
                column: "UserFolderId",
                principalTable: "UserCloud",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
