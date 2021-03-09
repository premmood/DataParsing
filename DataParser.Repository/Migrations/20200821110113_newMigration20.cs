using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class newMigration20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "field_name",
                table: "Response_File");

            migrationBuilder.AddColumn<string>(
                name: "fieldName",
                table: "Response_File",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fieldName",
                table: "Response_File");

            migrationBuilder.AddColumn<string>(
                name: "field_name",
                table: "Response_File",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
