using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class initialMigration15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Validation_Staging",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: false),
                    file_id = table.Column<int>(nullable: false),
                    action_type_desc = table.Column<string>(type: "varchar(52)", nullable: true),
                    rre_info_id = table.Column<string>(type: "char(9)", nullable: true),
                    next_period = table.Column<int>(nullable: false),
                    rre_name = table.Column<string>(type: "varchar(210)", nullable: true),
                    RRENAME = table.Column<string>(type: "varchar(200)", nullable: true),
                    rre_status = table.Column<byte>(type: "tinyint", nullable: false),
                    cms_doi = table.Column<DateTime>(type: "date", nullable: true),
                    industry_doi = table.Column<DateTime>(type: "date", nullable: true),
                    orm_term_date = table.Column<DateTime>(type: "date", nullable: true),
                    venue_state = table.Column<string>(type: "char(2)", nullable: true),
                    office_code = table.Column<string>(type: "char(9)", nullable: true),
                    claim_no = table.Column<string>(type: "varchar(30)", nullable: true),
                    icn = table.Column<string>(type: "varchar(30)", nullable: true),
                    status_id = table.Column<int>(nullable: false),
                    status = table.Column<string>(type: "varchar(50)", nullable: true),
                    claim_status = table.Column<int>(nullable: false),
                    orm_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    tin = table.Column<string>(type: "char(9)", nullable: true),
                    claim_received_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    claim_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    ip_hicn = table.Column<string>(type: "varchar(12)", nullable: true),
                    ip_ssn = table.Column<string>(type: "char(9)", nullable: true),
                    ip_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    ip_middle_initial = table.Column<string>(type: "char(1)", nullable: true),
                    ip_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    injured_party_name = table.Column<string>(type: "varchar(75)", nullable: true),
                    ip_gender = table.Column<string>(type: "varchar(50)", nullable: true),
                    ip_dob = table.Column<DateTime>(type: "date", nullable: true),
                    ip_dod = table.Column<DateTime>(type: "date", nullable: true),
                    ip_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ip_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ip_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    ip_state = table.Column<string>(type: "char(2)", nullable: true),
                    ip_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    ip_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    ip_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    ip_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    ip_rep_firm_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    ip_rep_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    ip_rep_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    injured_party_rep_name = table.Column<string>(type: "varchar(72)", nullable: true),
                    ip_rep_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ip_rep_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ip_rep_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    ip_rep_state = table.Column<string>(type: "char(2)", nullable: true),
                    ip_rep_tin = table.Column<string>(type: "char(9)", nullable: true),
                    ip_rep_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    ip_rep_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    ip_rep_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    ip_rep_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    rep_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    ins_type = table.Column<string>(type: "char(1)", nullable: true),
                    ins_type_desc = table.Column<string>(type: "varchar(50)", nullable: true),
                    contact_dept = table.Column<string>(type: "varchar(70)", nullable: true),
                    contact_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    contact_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    contact_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    contact_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    exhaust_date = table.Column<DateTime>(type: "date", nullable: true),
                    no_fault_limit = table.Column<decimal>(type: "numeric(11, 2)", nullable: true),
                    lost_time = table.Column<string>(type: "varchar(20)", nullable: true),
                    adj_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    adj_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    adjuster_full_name = table.Column<string>(type: "varchar(72)", nullable: true),
                    adj_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    adj_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    adj_email = table.Column<string>(type: "varchar(50)", nullable: true),
                    self_ins_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    self_ins_type = table.Column<string>(type: "char(1)", nullable: true),
                    legal_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    dba_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    policy_holder_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    policy_holder_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    policy_no = table.Column<string>(type: "varchar(30)", nullable: true),
                    prd_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    prd_brand_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    prd_manufacturer = table.Column<string>(type: "varchar(40)", nullable: true),
                    prd_liability_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    prd_alleged_harm = table.Column<string>(type: "varchar(200)", nullable: true),
                    icd_code2 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code3 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code4 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code5 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code6 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code7 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code8 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code9 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code10 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code11 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code12 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code13 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code14 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code15 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code16 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code17 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code18 = table.Column<string>(type: "varchar(8)", nullable: true),
                    icd_code19 = table.Column<string>(type: "varchar(8)", nullable: true),
                    next_date_from = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validation_Staging", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Validation_Staging");
        }
    }
}
