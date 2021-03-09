using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class initiaMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claim_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_id = table.Column<int>(nullable: false),
                    seq_id = table.Column<int>(nullable: false),
                    claim_control_num = table.Column<string>(type: "varchar(50)", nullable: true),
                    rre_info_id = table.Column<string>(type: "char(9)", nullable: true),
                    action_type = table.Column<string>(type: "char(6)", nullable: true),
                    cms_doi = table.Column<DateTime>(type: "date", nullable: true),
                    industry_doi = table.Column<DateTime>(type: "date", nullable: true),
                    orm_term_date = table.Column<DateTime>(type: "date", nullable: true),
                    venue_state = table.Column<string>(type: "char(2)", nullable: true),
                    office_code = table.Column<string>(type: "char(9)", nullable: true),
                    claim_no = table.Column<string>(type: "varchar(30)", nullable: true),
                    submission_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    response_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<int>(nullable: true),
                    claim_status = table.Column<int>(nullable: true),
                    orm_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    account_id = table.Column<int>(nullable: true),
                    tin = table.Column<string>(type: "char(9)", nullable: true),
                    created_by = table.Column<int>(nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    reportable_date = table.Column<DateTime>(type: "date", nullable: true),
                    reportable_flag = table.Column<string>(type: "char(1)", nullable: true),
                    status_ext = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim_Info", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claim_Info");
        }
    }
}
