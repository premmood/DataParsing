using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class initialMigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Injuredparty_Rep_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    rep_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    firm_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    tin = table.Column<string>(type: "char(9)", nullable: true),
                    address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    city = table.Column<string>(type: "varchar(30)", nullable: true),
                    state = table.Column<string>(type: "char(2)", nullable: true),
                    zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    phone_ext = table.Column<string>(type: "char(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injuredparty_Rep_Info", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Injuredparty_Rep_Info");
        }
    }
}
