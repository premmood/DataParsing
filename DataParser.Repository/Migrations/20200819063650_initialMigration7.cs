using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class initialMigration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Injury_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    injury_cause = table.Column<string>(type: "[char](8)", nullable: true),
                    icd_indicator = table.Column<string>(type: "[char](1)", nullable: true),
                    icd_code1 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code2 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code3 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code4 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code5 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code6 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code7 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code8 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code9 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code10 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code11 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code12 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code13 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code14 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code15 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code16 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code17 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code18 = table.Column<string>(type: "[varchar](8)", nullable: true),
                    icd_code19 = table.Column<string>(type: "[varchar](8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injury_Info", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Injury_Info");
        }
    }
}
