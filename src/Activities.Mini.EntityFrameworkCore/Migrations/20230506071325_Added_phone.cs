using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Activities.Mini.Migrations
{
    public partial class Added_phone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "WxUser",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "WxUser");
        }
    }
}
