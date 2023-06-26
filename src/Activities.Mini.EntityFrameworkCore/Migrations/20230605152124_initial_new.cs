using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Activities.Mini.Migrations
{
    public partial class initial_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_WxActivityUser_WxUser_WxUserId",
                table: "WxActivityUser",
                column: "WxUserId",
                principalTable: "WxUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WxActivityUser_WxUser_WxUserId",
                table: "WxActivityUser");
        }
    }
}
