using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject.Database.Migrations
{
    public partial class Add_FK_To_Post_Authors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Author",
                table: "Posts",
                column: "Author");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_Author",
                table: "Posts",
                column: "Author",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_Author",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_Author",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
