using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class initialMigration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adjuster_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    email = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adjuster_Info", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adjuster_Info");
        }
    }
}
