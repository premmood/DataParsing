using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class initialMigration18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reporting_Period_Use",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reporting_period = table.Column<int>(nullable: false),
                    start_day = table.Column<string>(type: "varchar(2)", nullable: true),
                    end_day = table.Column<string>(type: "varchar(2)", nullable: true),
                    month_for_reporting_period = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporting_Period_Use", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reporting_Period_Use");
        }
    }
}
