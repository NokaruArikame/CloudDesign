using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerEntityDataWCF.Migrations
{
    public partial class ChangedParentsIdCanBeNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_ArchiveFolders_ParentId",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFolders_ArchiveFolders_ParentId",
                table: "ArchiveFolders");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ArchiveFolders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ArchiveFiles",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFiles_ArchiveFolders_ParentId",
                table: "ArchiveFiles",
                column: "ParentId",
                principalTable: "ArchiveFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFolders_ArchiveFolders_ParentId",
                table: "ArchiveFolders",
                column: "ParentId",
                principalTable: "ArchiveFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFiles_ArchiveFolders_ParentId",
                table: "ArchiveFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveFolders_ArchiveFolders_ParentId",
                table: "ArchiveFolders");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ArchiveFolders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ArchiveFiles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFiles_ArchiveFolders_ParentId",
                table: "ArchiveFiles",
                column: "ParentId",
                principalTable: "ArchiveFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveFolders_ArchiveFolders_ParentId",
                table: "ArchiveFolders",
                column: "ParentId",
                principalTable: "ArchiveFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
