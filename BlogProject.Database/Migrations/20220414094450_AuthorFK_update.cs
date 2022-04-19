using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject.Database.Migrations
{
    public partial class AuthorFK_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_Author",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Posts",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_Author",
                table: "Posts",
                newName: "IX_Posts_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Posts",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                newName: "IX_Posts_Author");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_Author",
                table: "Posts",
                column: "Author",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
