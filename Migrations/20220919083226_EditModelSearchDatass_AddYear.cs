using Microsoft.EntityFrameworkCore.Migrations;

namespace Jobject_Parse.Migrations
{
    public partial class EditModelSearchDatass_AddYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "SearchDatass",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "SearchDatass");
        }
    }
}
