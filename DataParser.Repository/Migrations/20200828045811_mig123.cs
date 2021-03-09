using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class mig123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClaimError",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    error_code = table.Column<string>(type: "char(6)", nullable: true),
                    field_name = table.Column<string>(type: "varchar(50)", nullable: true),
                    value = table.Column<string>(type: "varchar(200)", nullable: true),
                    error_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    corrected = table.Column<string>(type: "char(1)", nullable: true),
                    corrected_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<int>(nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    error_type = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimError", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ClaimStaging",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    file_id = table.Column<int>(nullable: true),
                    seq_id = table.Column<int>(nullable: true),
                    action_type = table.Column<string>(type: "char(6)", nullable: true),
                    rre_info_id = table.Column<string>(type: "char(9)", nullable: true),
                    claim_control_num = table.Column<string>(type: "varchar(50)", nullable: true),
                    cms_doi = table.Column<DateTime>(type: "date", nullable: true),
                    industry_doi = table.Column<DateTime>(type: "date", nullable: true),
                    orm_term_date = table.Column<DateTime>(type: "date", nullable: true),
                    venue_state = table.Column<string>(type: "char(2)", nullable: true),
                    lost_time = table.Column<string>(type: "varchar(20)", nullable: true),
                    total_medical_spent = table.Column<decimal>(type: "numeric(11, 2)", nullable: true),
                    office_code = table.Column<string>(type: "char(9)", nullable: true),
                    claim_no = table.Column<string>(type: "varchar(30)", nullable: true),
                    orm_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    tin = table.Column<string>(type: "char(9)", nullable: true),
                    ip_mbi = table.Column<string>(type: "varchar(12)", nullable: true),
                    ip_hicn = table.Column<string>(type: "varchar(12)", nullable: true),
                    ip_ssn = table.Column<string>(type: "char(9)", nullable: true),
                    ip_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    ip_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    ip_middle_initial = table.Column<string>(type: "char(1)", nullable: true),
                    ip_gender = table.Column<string>(type: "char(1)", nullable: true),
                    ip_dob = table.Column<DateTime>(type: "date", nullable: true),
                    ip_dod = table.Column<DateTime>(type: "date", nullable: true),
                    ip_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ip_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ip_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    ip_state = table.Column<string>(type: "char(2)", nullable: true),
                    ip_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    ip_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    ip_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    ip_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    ip_rep_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    ip_rep_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    ip_rep_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    ip_rep_tin = table.Column<string>(type: "char(9)", nullable: true),
                    ip_rep_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ip_rep_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ip_rep_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    ip_rep_state = table.Column<string>(type: "char(2)", nullable: true),
                    ip_rep_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    ip_rep_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    ip_rep_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    ip_rep_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    ip_rep_firm_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    plan_ins_type = table.Column<string>(type: "char(1)", nullable: true),
                    contact_dept = table.Column<string>(type: "varchar(70)", nullable: true),
                    contact_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    contact_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    contact_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    contact_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    no_fault_limit = table.Column<decimal>(type: "numeric(11, 2)", nullable: true),
                    exhaust_date = table.Column<DateTime>(type: "date", nullable: true),
                    adj_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    adj_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    adj_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    adj_phone_ext = table.Column<string>(type: "char(5) ", nullable: true),
                    adj_email = table.Column<string>(type: "varchar(50)", nullable: true),
                    self_ins_indicator = table.Column<string>(type: "char(1) ", nullable: true),
                    self_ins_type = table.Column<string>(type: "char(1) ", nullable: true),
                    policy_holder_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    policy_holder_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    dba_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    legal_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    policy_no = table.Column<string>(type: "varchar(30)", nullable: true),
                    prd_liability_indicator = table.Column<string>(type: "char(1) ", nullable: true),
                    prd_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    prd_brand_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    prd_manufacturer = table.Column<string>(type: "varchar(40)", nullable: true),
                    prd_alleged_harm = table.Column<string>(type: "varchar(200)", nullable: true),
                    injury_nature = table.Column<string>(type: "varchar(50)", nullable: true),
                    injury_cause = table.Column<string>(type: "char(8)", nullable: true),
                    icd_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    icd_code1 = table.Column<string>(type: "varchar(8)", nullable: true),
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
                    claimant1_relation = table.Column<string>(type: "char(1)", nullable: true),
                    claimant1_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant1_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant1_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant1_middle_initial = table.Column<string>(type: "char(1)", nullable: true),
                    claimant1_org_name = table.Column<string>(type: "varchar(71)", nullable: true),
                    claimant1_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant1_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant1_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant1_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant1_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant1_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant1_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant1_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    claimant1_rep_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    claimant1_rep_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant1_rep_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant1_rep_firm_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    claimant1_rep_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant1_rep_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant1_rep_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant1_rep_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant1_rep_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant1_rep_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant1_rep_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant1_rep_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant1_rep_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    claimant1_seq_no = table.Column<int>(nullable: true),
                    claimant2_relation = table.Column<string>(type: "char(1)", nullable: true),
                    claimant2_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant2_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant2_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant2_middle_initial = table.Column<string>(type: "char(1)", nullable: true),
                    claimant2_org_name = table.Column<string>(type: "varchar(71)", nullable: true),
                    claimant2_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant2_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant2_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant2_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant2_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant2_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant2_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant2_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    claimant2_rep_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    claimant2_rep_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant2_rep_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant2_rep_firm_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    claimant2_rep_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant2_rep_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant2_rep_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant2_rep_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant2_rep_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant2_rep_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant2_rep_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant2_rep_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant2_rep_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    claimant2_seq_no = table.Column<int>(nullable: true),
                    claimant3_relation = table.Column<string>(type: "char(1)", nullable: true),
                    claimant3_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant3_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant3_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant3_middle_initial = table.Column<string>(type: "char(1)", nullable: true),
                    claimant3_org_name = table.Column<string>(type: "varchar(71)", nullable: true),
                    claimant3_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant3_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant3_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant3_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant3_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant3_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant3_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant3_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    claimant3_rep_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    claimant3_rep_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant3_rep_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant3_rep_firm_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    claimant3_rep_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant3_rep_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant3_rep_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant3_rep_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant3_rep_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant3_rep_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant3_rep_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant3_rep_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant3_rep_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    claimant3_seq_no = table.Column<int>(nullable: true),
                    claimant4_relation = table.Column<string>(type: "char(1)", nullable: true),
                    claimant4_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant4_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant4_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant4_middle_initial = table.Column<string>(type: "char(1)", nullable: true),
                    claimant4_org_name = table.Column<string>(type: "varchar(71)", nullable: true),
                    claimant4_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant4_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant4_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant4_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant4_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant4_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant4_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant4_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    claimant4_rep_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    claimant4_rep_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant4_rep_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant4_rep_firm_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    claimant4_rep_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant4_rep_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant4_rep_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant4_rep_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant4_rep_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant4_rep_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant4_rep_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant4_rep_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant4_rep_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    claimant4_seq_no = table.Column<int>(nullable: true),
                    tpoc1_date = table.Column<DateTime>(type: "date", nullable: true),
                    tpoc1_amount = table.Column<decimal>(type: "numeric(11, 2)", nullable: true),
                    tpoc1_fund_delayed_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    tpoc1_seq_no = table.Column<int>(nullable: true),
                    tpoc2_date = table.Column<DateTime>(type: "date", nullable: true),
                    tpoc2_amount = table.Column<decimal>(type: "numeric(11, 2)", nullable: true),
                    tpoc2_fund_delayed_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    tpoc2_seq_no = table.Column<int>(nullable: true),
                    tpoc3_date = table.Column<DateTime>(type: "date", nullable: true),
                    tpoc3_amount = table.Column<decimal>(type: "numeric(11, 2)", nullable: true),
                    tpoc3_fund_delayed_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    tpoc3_seq_no = table.Column<int>(nullable: true),
                    tpoc4_date = table.Column<DateTime>(type: "date", nullable: true),
                    tpoc4_amount = table.Column<decimal>(type: "numeric(11, 2)", nullable: true),
                    tpoc4_fund_delayed_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    tpoc4_seq_no = table.Column<int>(nullable: true),
                    tpoc5_date = table.Column<DateTime>(type: "date", nullable: true),
                    tpoc5_amount = table.Column<decimal>(type: "numeric(11, 2)", nullable: true),
                    tpoc5_fund_delayed_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    tpoc5_seq_no = table.Column<int>(nullable: true),
                    future_field1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field3 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field4 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field5 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field6 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field7 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field8 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field9 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field10 = table.Column<string>(type: "varchar(50)", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<int>(nullable: true),
                    claim_status = table.Column<string>(type: "varchar(50)", nullable: true),
                    account_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimStaging", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCodeValue",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code_id = table.Column<int>(nullable: true),
                    code_description = table.Column<string>(type: "varchar(50)", nullable: true),
                    code_value = table.Column<string>(type: "varchar(50)", nullable: true),
                    code_type = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCodeValue", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorCode",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "char(6)", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorCode", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FileError",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_id = table.Column<int>(nullable: true),
                    error_code = table.Column<string>(type: "char(10)", nullable: true),
                    field_name = table.Column<string>(type: "varchar(50)", nullable: true),
                    value = table.Column<string>(type: "varchar(200)", nullable: true),
                    seq_id = table.Column<int>(nullable: true),
                    claim_control_number = table.Column<int>(nullable: true),
                    account_id = table.Column<string>(type: "varchar(50)", nullable: true),
                    rre_info_id = table.Column<string>(type: "char(9)", nullable: true),
                    error_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<int>(nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileError", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FileInfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rreid = table.Column<string>(nullable: true),
                    file_name = table.Column<string>(type: "varchar(100)", nullable: true),
                    file_type = table.Column<string>(type: "varchar(100)", nullable: true),
                    transaction_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    rec_count = table.Column<int>(nullable: true),
                    claim_count = table.Column<int>(nullable: true),
                    file_status = table.Column<string>(type: "varchar(10)", nullable: true),
                    env = table.Column<string>(type: "char(4)", nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    end_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    received_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileInfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ReportingPeriodUse",
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
                    table.PrimaryKey("PK_ReportingPeriodUse", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ResponseFile",
                columns: table => new
                {
                    seq_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_control_num = table.Column<string>(type: "varchar(50)", nullable: true),
                    error_code = table.Column<string>(type: "char(6)", nullable: true),
                    fieldName = table.Column<string>(type: "varchar(50)", nullable: true),
                    account_id = table.Column<int>(nullable: true),
                    rre_id = table.Column<string>(type: "char(9)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseFile", x => x.seq_id);
                });

            migrationBuilder.CreateTable(
                name: "RREInfo",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(9)", nullable: false),
                    name = table.Column<string>(type: "varchar(200)", nullable: true),
                    address1 = table.Column<string>(type: "varchar(150)", nullable: true),
                    address2 = table.Column<string>(type: "varchar(150)", nullable: true),
                    address3 = table.Column<string>(type: "varchar(150)", nullable: true),
                    city = table.Column<string>(type: "varchar(150)", nullable: true),
                    state = table.Column<string>(type: "char(2)", nullable: true),
                    zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    phone1 = table.Column<string>(type: "varchar(10)", nullable: true),
                    phone2 = table.Column<string>(type: "varchar(10)", nullable: true),
                    email1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    email2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    reporting_period = table.Column<int>(type: "int", nullable: true),
                    authorized_rep = table.Column<string>(type: "varchar(50)", nullable: true),
                    authorized_rep_email = table.Column<string>(type: "varchar(50)", nullable: true),
                    account_manager = table.Column<string>(type: "varchar(50)", nullable: true),
                    account_id = table.Column<int>(type: "int", nullable: true),
                    subsidiary_name = table.Column<string>(type: "varchar(150)", nullable: true),
                    address4 = table.Column<string>(type: "varchar(150)", nullable: true),
                    country = table.Column<string>(type: "varchar(150)", nullable: true),
                    authorized_rep_phone = table.Column<string>(type: "varchar(150)", nullable: true),
                    data_specialist = table.Column<string>(type: "varchar(150)", nullable: true),
                    reporting_agent = table.Column<string>(type: "varchar(150)", nullable: true),
                    sir_indicator = table.Column<string>(type: "varchar(10)", nullable: true),
                    exclude_reporting = table.Column<bool>(type: "bit", nullable: true),
                    active_from = table.Column<DateTime>(type: "datetime", nullable: true),
                    active_to = table.Column<DateTime>(type: "datetime", nullable: true),
                    site_id_mailing_name = table.Column<string>(type: "varchar(150)", nullable: true),
                    rre_status = table.Column<byte>(type: "tinyint", nullable: true),
                    deactivated = table.Column<byte>(type: "tinyint", nullable: true),
                    mq_period = table.Column<int>(type: "int", nullable: true),
                    mq_day = table.Column<int>(type: "int", nullable: true),
                    received_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    rre_stat = table.Column<int>(type: "int", nullable: true),
                    tpra_id = table.Column<int>(type: "int", nullable: true),
                    edi_rep_name = table.Column<string>(type: "varchar(200)", nullable: true),
                    edi_rep_email = table.Column<string>(type: "varchar(200)", nullable: true),
                    edi_rep_phone = table.Column<string>(type: "varchar(200)", nullable: true),
                    agent_flag = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RREInfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionErrorInfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_id = table.Column<int>(nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionErrorInfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ValidationLock",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    is_locked = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationLock", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ValidationStaging",
                columns: table => new
                {
                    claim_info_id = table.Column<int>(nullable: false),
                    file_id = table.Column<int>(nullable: false),
                    action_type_desc = table.Column<string>(type: "varchar(52)", nullable: true),
                    rre_id = table.Column<string>(type: "char(9)", nullable: true),
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
                    ip_mbi = table.Column<string>(type: "varchar(12)", nullable: true),
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
                    icd_code1 = table.Column<string>(type: "varchar(8)", nullable: true),
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
                    icd_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    next_date_from = table.Column<DateTime>(type: "date", nullable: true),
                    claimant1_relation = table.Column<string>(type: "char(1)", nullable: true),
                    claimant1_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant1_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant1_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant1_middle_initial = table.Column<string>(type: "char(1)", nullable: true),
                    claimant1_org_name = table.Column<string>(type: "varchar(71)", nullable: true),
                    claimant1_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant1_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant1_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant1_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant1_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant1_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant1_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant1_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    claimant1_rep_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    claimant1_rep_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant1_rep_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant1_rep_firm_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    claimant1_rep_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant1_rep_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant1_rep_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant1_rep_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant1_rep_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant1_rep_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant1_rep_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant1_rep_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant1_rep_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    claimant2_relation = table.Column<string>(type: "char(1)", nullable: true),
                    claimant2_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant2_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant2_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant2_middle_initial = table.Column<string>(type: "char(1)", nullable: true),
                    claimant2_org_name = table.Column<string>(type: "varchar(71)", nullable: true),
                    claimant2_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant2_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant2_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant2_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant2_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant2_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant2_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant2_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    claimant2_rep_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    claimant2_rep_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant2_rep_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant2_rep_firm_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    claimant2_rep_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant2_rep_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant2_rep_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant2_rep_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant2_rep_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant2_rep_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant2_rep_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant2_rep_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant2_rep_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    claimant3_relation = table.Column<string>(type: "char(1)", nullable: true),
                    claimant3_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant3_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant3_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant3_middle_initial = table.Column<string>(type: "char(1)", nullable: true),
                    claimant3_org_name = table.Column<string>(type: "varchar(71)", nullable: true),
                    claimant3_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant3_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant3_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant3_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant3_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant3_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant3_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant3_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    claimant3_rep_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    claimant3_rep_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant3_rep_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant3_rep_firm_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    claimant3_rep_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant3_rep_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant3_rep_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant3_rep_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant3_rep_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant3_rep_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant3_rep_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant3_rep_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant3_rep_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    claimant4_relation = table.Column<string>(type: "char(1)", nullable: true),
                    claimant4_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant4_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant4_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant4_middle_initial = table.Column<string>(type: "char(1)", nullable: true),
                    claimant4_org_name = table.Column<string>(type: "varchar(71)", nullable: true),
                    claimant4_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant4_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant4_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant4_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant4_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant4_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant4_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant4_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    claimant4_rep_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    claimant4_rep_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    claimant4_rep_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant4_rep_firm_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    claimant4_rep_tin = table.Column<string>(type: "char(9)", nullable: true),
                    claimant4_rep_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant4_rep_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    claimant4_rep_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    claimant4_rep_state = table.Column<string>(type: "char(2)", nullable: true),
                    claimant4_rep_zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    claimant4_rep_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    claimant4_rep_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    claimant4_rep_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    tpoc1_date = table.Column<DateTime>(type: "date", nullable: true),
                    tpoc1_amount = table.Column<decimal>(type: "numeric(11, 2)", nullable: false),
                    tpoc1_fund_delayed_date = table.Column<DateTime>(type: "datetime  ", nullable: true),
                    tpoc2_date = table.Column<DateTime>(type: "date", nullable: true),
                    tpoc2_amount = table.Column<decimal>(type: "numeric(11, 2)", nullable: false),
                    tpoc2_fund_delayed_date = table.Column<DateTime>(type: "datetime  ", nullable: true),
                    tpoc3_date = table.Column<DateTime>(type: "date", nullable: true),
                    tpoc3_amount = table.Column<decimal>(type: "numeric(11, 2)", nullable: false),
                    tpoc3_fund_delayed_date = table.Column<DateTime>(type: "datetime  ", nullable: true),
                    tpoc4_date = table.Column<DateTime>(type: "date", nullable: true),
                    tpoc4_amount = table.Column<decimal>(type: "numeric(11, 2)", nullable: false),
                    tpoc4_fund_delayed_date = table.Column<DateTime>(type: "datetime  ", nullable: true),
                    tpoc5_date = table.Column<DateTime>(type: "date", nullable: true),
                    tpoc5_amount = table.Column<decimal>(type: "numeric(11, 2)", nullable: false),
                    tpoc5_fund_delayed_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ClaimInfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_id = table.Column<int>(nullable: false),
                    seq_id = table.Column<int>(nullable: false),
                    claim_control_num = table.Column<string>(type: "varchar(50)", nullable: true),
                    rre_id = table.Column<string>(type: "char(9)", nullable: true),
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
                    table.PrimaryKey("PK_ClaimInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_ClaimInfo_RREInfo_rre_id",
                        column: x => x.rre_id,
                        principalTable: "RREInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TINInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tin = table.Column<string>(type: "char(9)", nullable: true),
                    mailing_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    rre_info_id = table.Column<string>(type: "char(9)", nullable: true),
                    authorized_rep_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    mail_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    mail_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    city = table.Column<string>(type: "varchar(30)", nullable: true),
                    state = table.Column<string>(type: "char(2)", nullable: true),
                    zip = table.Column<string>(type: "char(5)", nullable: true),
                    zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    foreign_rre_address1 = table.Column<string>(type: "varchar(32)", nullable: true),
                    foreign_rre_address2 = table.Column<string>(type: "varchar(32)", nullable: true),
                    foreign_rre_address3 = table.Column<string>(type: "varchar(32)", nullable: true),
                    foreign_rre_address4 = table.Column<string>(type: "varchar(32)", nullable: true),
                    status = table.Column<int>(nullable: true),
                    submission_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<int>(nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    site_id = table.Column<string>(type: "varchar(9)", nullable: true),
                    agent_mailing_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    agent_mail_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    agent_mail_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    agent_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    agent_state = table.Column<string>(type: "char(2)", nullable: true),
                    agent_zip = table.Column<string>(type: "char(5)", nullable: true),
                    agent_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    file_id = table.Column<int>(nullable: true),
                    seq_num = table.Column<int>(nullable: true),
                    account_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TINInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TINInfo_RREInfo_rre_info_id",
                        column: x => x.rre_info_id,
                        principalTable: "RREInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdjusterInfo",
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
                    table.PrimaryKey("PK_AdjusterInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_AdjusterInfo_ClaimInfo_claim_info_id",
                        column: x => x.claim_info_id,
                        principalTable: "ClaimInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimantInfo",
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
                    rep_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    rep_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
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
                    table.PrimaryKey("PK_ClaimantInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_ClaimantInfo_ClaimInfo_claim_Info_id",
                        column: x => x.claim_Info_id,
                        principalTable: "ClaimInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InjuredpartyInfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    mbi = table.Column<string>(type: "varchar(12)", nullable: true),
                    hicn = table.Column<string>(type: "varchar(12)", nullable: true),
                    ssn = table.Column<string>(type: "char(9)", nullable: true),
                    last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    middle_initial = table.Column<string>(type: "char(1)", nullable: true),
                    gender = table.Column<string>(type: "char(1)", nullable: true),
                    dob = table.Column<DateTime>(type: "date", nullable: true),
                    dod = table.Column<DateTime>(type: "date", nullable: true),
                    address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    city = table.Column<string>(type: "varchar(30)", nullable: true),
                    state = table.Column<string>(type: "char(2)", nullable: true),
                    zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    beneficiary_ind = table.Column<string>(type: "char(1)", nullable: true),
                    beneficiary_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    historical_flag = table.Column<string>(type: "char(1)", nullable: true),
                    beneficiary_type = table.Column<string>(type: "varchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InjuredpartyInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_InjuredpartyInfo_ClaimInfo_claim_info_id",
                        column: x => x.claim_info_id,
                        principalTable: "ClaimInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InjuredpartyRepInfo",
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
                    table.PrimaryKey("PK_InjuredpartyRepInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_InjuredpartyRepInfo_ClaimInfo_claim_info_id",
                        column: x => x.claim_info_id,
                        principalTable: "ClaimInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InjuryInfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    injury_cause = table.Column<string>(type: "char(8)", nullable: true),
                    icd_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    icd_code1 = table.Column<string>(type: "varchar(8)", nullable: true),
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
                    icd_code19 = table.Column<string>(type: "varchar(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InjuryInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_InjuryInfo_ClaimInfo_claim_info_id",
                        column: x => x.claim_info_id,
                        principalTable: "ClaimInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceInfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    self_ins_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    self_ins_type = table.Column<string>(type: "char(1)", nullable: true),
                    policy_holder_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    policy_holder_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    dba_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    legal_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    policy_no = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_InsuranceInfo_ClaimInfo_claim_info_id",
                        column: x => x.claim_info_id,
                        principalTable: "ClaimInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanInfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    plan_ins_type = table.Column<string>(type: "char(1)", nullable: true),
                    contact_dept = table.Column<string>(type: "varchar(70)", nullable: true),
                    contact_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    contact_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    contact_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    contact_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    no_fault_limit = table.Column<decimal>(type: "numeric(11, 2)", nullable: true),
                    exhaust_date = table.Column<DateTime>(type: "date", nullable: true),
                    lost_time = table.Column<string>(type: "varchar(20)", nullable: true),
                    total_medical_spent = table.Column<decimal>(type: "numeric(11, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlanInfo_ClaimInfo_claim_info_id",
                        column: x => x.claim_info_id,
                        principalTable: "ClaimInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    prd_liability_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    prd_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    prd_brand_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    prd_manufacturer = table.Column<string>(type: "varchar(40)", nullable: true),
                    prd_alleged_harm = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductInfo_ClaimInfo_claim_info_id",
                        column: x => x.claim_info_id,
                        principalTable: "ClaimInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TPOCInfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    tpoc_date = table.Column<DateTime>(type: "date", nullable: true),
                    tpoc_amount = table.Column<decimal>(type: "numeric(11, 2)", nullable: true),
                    fund_delayed_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    sequence = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPOCInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_TPOCInfo_ClaimInfo_claim_info_id",
                        column: x => x.claim_info_id,
                        principalTable: "ClaimInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UDFInfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    future_field1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field3 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field4 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field5 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field6 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field7 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field8 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field9 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field10 = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UDFInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_UDFInfo_ClaimInfo_claim_info_id",
                        column: x => x.claim_info_id,
                        principalTable: "ClaimInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdjusterInfo_claim_info_id",
                table: "AdjusterInfo",
                column: "claim_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimantInfo_claim_Info_id",
                table: "ClaimantInfo",
                column: "claim_Info_id");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimInfo_rre_id",
                table: "ClaimInfo",
                column: "rre_id");

            migrationBuilder.CreateIndex(
                name: "IX_InjuredpartyInfo_claim_info_id",
                table: "InjuredpartyInfo",
                column: "claim_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_InjuredpartyRepInfo_claim_info_id",
                table: "InjuredpartyRepInfo",
                column: "claim_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_InjuryInfo_claim_info_id",
                table: "InjuryInfo",
                column: "claim_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceInfo_claim_info_id",
                table: "InsuranceInfo",
                column: "claim_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_PlanInfo_claim_info_id",
                table: "PlanInfo",
                column: "claim_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInfo_claim_info_id",
                table: "ProductInfo",
                column: "claim_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_TINInfo_rre_info_id",
                table: "TINInfo",
                column: "rre_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_TPOCInfo_claim_info_id",
                table: "TPOCInfo",
                column: "claim_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_UDFInfo_claim_info_id",
                table: "UDFInfo",
                column: "claim_info_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdjusterInfo");

            migrationBuilder.DropTable(
                name: "ClaimantInfo");

            migrationBuilder.DropTable(
                name: "ClaimError");

            migrationBuilder.DropTable(
                name: "ClaimStaging");

            migrationBuilder.DropTable(
                name: "CompanyCodeValue");

            migrationBuilder.DropTable(
                name: "ErrorCode");

            migrationBuilder.DropTable(
                name: "FileError");

            migrationBuilder.DropTable(
                name: "FileInfo");

            migrationBuilder.DropTable(
                name: "InjuredpartyInfo");

            migrationBuilder.DropTable(
                name: "InjuredpartyRepInfo");

            migrationBuilder.DropTable(
                name: "InjuryInfo");

            migrationBuilder.DropTable(
                name: "InsuranceInfo");

            migrationBuilder.DropTable(
                name: "PlanInfo");

            migrationBuilder.DropTable(
                name: "ProductInfo");

            migrationBuilder.DropTable(
                name: "ReportingPeriodUse");

            migrationBuilder.DropTable(
                name: "ResponseFile");

            migrationBuilder.DropTable(
                name: "TINInfo");

            migrationBuilder.DropTable(
                name: "TPOCInfo");

            migrationBuilder.DropTable(
                name: "TransactionErrorInfo");

            migrationBuilder.DropTable(
                name: "UDFInfo");

            migrationBuilder.DropTable(
                name: "ValidationLock");

            migrationBuilder.DropTable(
                name: "ValidationStaging");

            migrationBuilder.DropTable(
                name: "ClaimInfo");

            migrationBuilder.DropTable(
                name: "RREInfo");
        }
    }
}
