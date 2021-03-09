using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class initialMigration12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claimant_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_Info_id = table.Column<int>(nullable: true),
                    relation = table.Column<string>(type: "char(1)", nullable: true),
                    tin = table.Column<string>(type: "char(9)", nullable: true),
                    last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    middle_initial = table.Column<string>(type: "char(1)", nullable: true),
                    entity_org_name = table.Column<string>(type: "varchar(71)", nullable: true),
                    address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    city = table.Column<string>(type: "varchar(30)", nullable: true),
                    state = table.Column<string>(type: "char(2)", nullable: true),
                    zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    rep_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    rep_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    rep_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    rep_firm_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    rep_tin = table.Column<string>(type: "char(9)", nullable: true),
                    rep_address1 = table.Column<string>(type: " varchar(50)", nullable: true),
                    rep_address2 = table.Column<string>(type: " varchar(50)", nullable: true),
                    rep_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    rep_state = table.Column<string>(type: "char(2)", nullable: true),
                    rep_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    rep_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    rep_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    rep_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    sequence = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claimant_Info", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claimant_Info");
        }
    }
}
