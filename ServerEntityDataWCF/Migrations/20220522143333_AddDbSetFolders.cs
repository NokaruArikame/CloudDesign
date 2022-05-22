using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerEntityDataWCF.Migrations
{
    public partial class AddDbSetFolders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_IFolder_ParentId",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_IFolder_UserCloudId",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_IFolder_IFolder_ParentId",
                table: "IFolder");

            migrationBuilder.DropForeignKey(
                name: "FK_IFolder_Users_UserId",
                table: "IFolder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IFolder",
                table: "IFolder");

            migrationBuilder.RenameTable(
                name: "IFolder",
                newName: "Folders");

            migrationBuilder.RenameIndex(
                name: "IX_IFolder_UserId",
                table: "Folders",
                newName: "IX_Folders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_IFolder_ParentId",
                table: "Folders",
                newName: "IX_Folders_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Folders",
                table: "Folders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFiles_Folders_ParentId",
                table: "ArchiveFiles",
                column: "ParentId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFiles_Folders_UserCloudId",
                table: "ArchiveFiles",
                column: "UserCloudId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Folders_ParentId",
                table: "Folders",
                column: "ParentId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Users_UserId",
                table: "Folders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_Folders_ParentId",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_Folders_UserCloudId",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Folders_ParentId",
                table: "Folders");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Users_UserId",
                table: "Folders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Folders",
                table: "Folders");

            migrationBuilder.RenameTable(
                name: "Folders",
                newName: "IFolder");

            migrationBuilder.RenameIndex(
                name: "IX_Folders_UserId",
                table: "IFolder",
                newName: "IX_IFolder_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Folders_ParentId",
                table: "IFolder",
                newName: "IX_IFolder_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IFolder",
                table: "IFolder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFiles_IFolder_ParentId",
                table: "ArchiveFiles",
                column: "ParentId",
                principalTable: "IFolder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFiles_IFolder_UserCloudId",
                table: "ArchiveFiles",
                column: "UserCloudId",
                principalTable: "IFolder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IFolder_IFolder_ParentId",
                table: "IFolder",
                column: "ParentId",
                principalTable: "IFolder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IFolder_Users_UserId",
                table: "IFolder",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
