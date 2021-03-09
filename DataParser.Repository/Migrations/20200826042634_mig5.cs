using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ip_mbi",
                table: "ValidationStaging",
                type: "varchar(12)",
                nullable: true);

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
        }
    }
}
