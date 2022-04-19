using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject.Database.Migrations
{
    public partial class AuthorFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Author",
                table: "Posts",
                column: "Author");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_Author",
                table: "Posts",
                column: "Author",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_Author",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_Author",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "Author",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
