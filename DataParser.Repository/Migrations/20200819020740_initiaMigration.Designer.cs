﻿// <auto-generated />
using System;
using DataParser.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataParser.Repository.Migrations
{
    [DbContext(typeof(ClaimContext))]
    [Migration("20200819020740_initiaMigration")]
    partial class initiaMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataParser.Repository.Models.file_error", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("account_id")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("claim_control_number")
                        .HasColumnType("int");

                    b.Property<int?>("created_by")
                        .HasColumnType("int");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("datetime");

                    b.Property<string>("error_code")
                        .HasColumnType("char(10)");

                    b.Property<DateTime?>("error_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("file_id")
                        .HasColumnType("int");

                    b.Property<string>("rre_info_id")
                        .HasColumnType("char(9)");

                    b.Property<int?>("seq_id")
                        .HasColumnType("int");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updated_date")
                        .HasColumnType("datetime");

                    b.Property<string>("value")
                        .HasColumnType("varchar(200)");

                    b.HasKey("id");

                    b.ToTable("File_Error");
                });

            modelBuilder.Entity("DataParser.Repository.Models.file_info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("actual_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("claim_count")
                        .HasColumnType("int");

                    b.Property<DateTime?>("end_date")
                        .HasColumnType("datetime");

                    b.Property<string>("env")
                        .HasColumnType("char(4)");

                    b.Property<string>("file_name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("file_status")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("file_type")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("rec_count")
                        .HasColumnType("int");

                    b.Property<DateTime?>("received_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("rreid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("start_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("tpra_info_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("transaction_date")
                        .HasColumnType("date");

                    b.HasKey("id");

                    b.ToTable("File_Info");
                });

            modelBuilder.Entity("DataParser.claim_staging", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("account_id")
                        .HasColumnType("int");

                    b.Property<string>("action_type")
                        .HasColumnType("char(6)");

                    b.Property<string>("adj_email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("adj_first_name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("adj_last_name")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("adj_phone")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("adj_phone_ext")
                        .HasColumnType("char(5) ");

                    b.Property<string>("claim_control_num")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("claim_info_id")
                        .HasColumnType("int");

                    b.Property<string>("claim_no")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claim_status")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant1_address1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant1_address2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant1_city")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant1_first_name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant1_last_name")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("claimant1_middle_initial")
                        .HasColumnType("char(1)");

                    b.Property<string>("claimant1_org_name")
                        .HasColumnType("varchar(71)");

                    b.Property<string>("claimant1_phone")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("claimant1_phone_ext")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant1_relation")
                        .HasColumnType("char(1)");

                    b.Property<string>("claimant1_rep_address1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant1_rep_address2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant1_rep_city")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant1_rep_firm_name")
                        .HasColumnType("varchar(70)");

                    b.Property<string>("claimant1_rep_first_name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant1_rep_indicator")
                        .HasColumnType("char(1)");

                    b.Property<string>("claimant1_rep_last_name")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("claimant1_rep_phone")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("claimant1_rep_phone_ext")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant1_rep_state")
                        .HasColumnType("char(2)");

                    b.Property<string>("claimant1_rep_tin")
                        .HasColumnType("char(9)");

                    b.Property<string>("claimant1_rep_zip_code")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant1_rep_zip_ext")
                        .HasColumnType("char(4)");

                    b.Property<int?>("claimant1_seq_no")
                        .HasColumnType("int");

                    b.Property<string>("claimant1_state")
                        .HasColumnType("char(2)");

                    b.Property<string>("claimant1_tin")
                        .HasColumnType("char(9)");

                    b.Property<string>("claimant1_zip_code")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant1_zip_ext")
                        .HasColumnType("char(4)");

                    b.Property<string>("claimant2_address1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant2_address2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant2_city")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant2_first_name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant2_last_name")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("claimant2_middle_initial")
                        .HasColumnType("char(1)");

                    b.Property<string>("claimant2_org_name")
                        .HasColumnType("varchar(71)");

                    b.Property<string>("claimant2_phone")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("claimant2_phone_ext")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant2_relation")
                        .HasColumnType("char(1)");

                    b.Property<string>("claimant2_rep_address1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant2_rep_address2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant2_rep_city")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant2_rep_firm_name")
                        .HasColumnType("varchar(70)");

                    b.Property<string>("claimant2_rep_first_name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant2_rep_indicator")
                        .HasColumnType("char(1)");

                    b.Property<string>("claimant2_rep_last_name")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("claimant2_rep_phone")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("claimant2_rep_phone_ext")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant2_rep_state")
                        .HasColumnType("char(2)");

                    b.Property<string>("claimant2_rep_tin")
                        .HasColumnType("char(9)");

                    b.Property<string>("claimant2_rep_zip_code")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant2_rep_zip_ext")
                        .HasColumnType("char(4)");

                    b.Property<int?>("claimant2_seq_no")
                        .HasColumnType("int");

                    b.Property<string>("claimant2_state")
                        .HasColumnType("char(2)");

                    b.Property<string>("claimant2_tin")
                        .HasColumnType("char(9)");

                    b.Property<string>("claimant2_zip_code")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant2_zip_ext")
                        .HasColumnType("char(4)");

                    b.Property<string>("claimant3_address1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant3_address2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant3_city")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant3_first_name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant3_last_name")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("claimant3_middle_initial")
                        .HasColumnType("char(1)");

                    b.Property<string>("claimant3_org_name")
                        .HasColumnType("varchar(71)");

                    b.Property<string>("claimant3_phone")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("claimant3_phone_ext")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant3_relation")
                        .HasColumnType("char(1)");

                    b.Property<string>("claimant3_rep_address1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant3_rep_address2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant3_rep_city")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant3_rep_firm_name")
                        .HasColumnType("varchar(70)");

                    b.Property<string>("claimant3_rep_first_name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant3_rep_indicator")
                        .HasColumnType("char(1)");

                    b.Property<string>("claimant3_rep_last_name")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("claimant3_rep_phone")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("claimant3_rep_phone_ext")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant3_rep_state")
                        .HasColumnType("char(2)");

                    b.Property<string>("claimant3_rep_tin")
                        .HasColumnType("char(9)");

                    b.Property<string>("claimant3_rep_zip_code")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant3_rep_zip_ext")
                        .HasColumnType("char(4)");

                    b.Property<int?>("claimant3_seq_no")
                        .HasColumnType("int");

                    b.Property<string>("claimant3_state")
                        .HasColumnType("char(2)");

                    b.Property<string>("claimant3_tin")
                        .HasColumnType("char(9)");

                    b.Property<string>("claimant3_zip_code")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant3_zip_ext")
                        .HasColumnType("char(4)");

                    b.Property<string>("claimant4_address1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant4_address2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant4_city")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant4_first_name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant4_last_name")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("claimant4_middle_initial")
                        .HasColumnType("char(1)");

                    b.Property<string>("claimant4_org_name")
                        .HasColumnType("varchar(71)");

                    b.Property<string>("claimant4_phone")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("claimant4_phone_ext")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant4_relation")
                        .HasColumnType("char(1)");

                    b.Property<string>("claimant4_rep_address1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant4_rep_address2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("claimant4_rep_city")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant4_rep_firm_name")
                        .HasColumnType("varchar(70)");

                    b.Property<string>("claimant4_rep_first_name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("claimant4_rep_indicator")
                        .HasColumnType("char(1)");

                    b.Property<string>("claimant4_rep_last_name")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("claimant4_rep_phone")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("claimant4_rep_phone_ext")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant4_rep_state")
                        .HasColumnType("char(2)");

                    b.Property<string>("claimant4_rep_tin")
                        .HasColumnType("char(9)");

                    b.Property<string>("claimant4_rep_zip_code")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant4_rep_zip_ext")
                        .HasColumnType("char(4)");

                    b.Property<int?>("claimant4_seq_no")
                        .HasColumnType("int");

                    b.Property<string>("claimant4_state")
                        .HasColumnType("char(2)");

                    b.Property<string>("claimant4_tin")
                        .HasColumnType("char(9)");

                    b.Property<string>("claimant4_zip_code")
                        .HasColumnType("char(5)");

                    b.Property<string>("claimant4_zip_ext")
                        .HasColumnType("char(4)");

                    b.Property<DateTime?>("cms_doi")
                        .HasColumnType("date");

                    b.Property<string>("contact_dept")
                        .HasColumnType("varchar(70)");

                    b.Property<string>("contact_first_name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("contact_last_name")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("contact_phone")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("contact_phone_ext")
                        .HasColumnType("char(5)");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("datetime");

                    b.Property<string>("dba_name")
                        .HasColumnType("varchar(70)");

                    b.Property<DateTime?>("exhaust_date")
                        .HasColumnType("date");

                    b.Property<int?>("file_id")
                        .HasColumnType("int");

                    b.Property<string>("future_field1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("future_field10")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("future_field2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("future_field3")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("future_field4")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("future_field5")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("future_field6")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("future_field7")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("future_field8")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("future_field9")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("icd_code1")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code10")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code11")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code12")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code13")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code14")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code15")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code16")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code17")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code18")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code19")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code2")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code3")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code4")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code5")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code6")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code7")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code8")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_code9")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("icd_indicator")
                        .HasColumnType("char(1)");

                    b.Property<DateTime?>("industry_doi")
                        .HasColumnType("date");

                    b.Property<string>("injury_cause")
                        .HasColumnType("char(8)");

                    b.Property<string>("injury_nature")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ip_address1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ip_address2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ip_city")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime?>("ip_dob")
                        .HasColumnType("date");

                    b.Property<DateTime?>("ip_dod")
                        .HasColumnType("date");

                    b.Property<string>("ip_first_name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ip_gender")
                        .HasColumnType("char(1)");

                    b.Property<string>("ip_hicn")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("ip_last_name")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("ip_mbi")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("ip_middle_initial")
                        .HasColumnType("char(1)");

                    b.Property<string>("ip_phone")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ip_phone_ext")
                        .HasColumnType("char(5)");

                    b.Property<string>("ip_rep_address1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ip_rep_address2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ip_rep_city")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ip_rep_firm_name")
                        .HasColumnType("varchar(70)");

                    b.Property<string>("ip_rep_first_name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ip_rep_indicator")
                        .HasColumnType("char(1)");

                    b.Property<string>("ip_rep_last_name")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("ip_rep_phone")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ip_rep_phone_ext")
                        .HasColumnType("char(5)");

                    b.Property<string>("ip_rep_state")
                        .HasColumnType("char(2)");

                    b.Property<string>("ip_rep_tin")
                        .HasColumnType("char(9)");

                    b.Property<string>("ip_rep_zip_code")
                        .HasColumnType("char(5)");

                    b.Property<string>("ip_rep_zip_ext")
                        .HasColumnType("char(4)");

                    b.Property<string>("ip_ssn")
                        .HasColumnType("char(9)");

                    b.Property<string>("ip_state")
                        .HasColumnType("char(2)");

                    b.Property<string>("ip_zip_code")
                        .HasColumnType("char(5)");

                    b.Property<string>("ip_zip_ext")
                        .HasColumnType("char(4)");

                    b.Property<string>("legal_name")
                        .HasColumnType("varchar(70)");

                    b.Property<string>("lost_time")
                        .HasColumnType("varchar(20)");

                    b.Property<decimal?>("no_fault_limit")
                        .HasColumnType("numeric(11, 2)");

                    b.Property<string>("office_code")
                        .HasColumnType("char(9)");

                    b.Property<string>("orm_indicator")
                        .HasColumnType("char(1)");

                    b.Property<DateTime?>("orm_term_date")
                        .HasColumnType("date");

                    b.Property<string>("plan_ins_type")
                        .HasColumnType("char(1)");

                    b.Property<string>("policy_holder_first_name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("policy_holder_last_name")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("policy_no")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("prd_alleged_harm")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("prd_brand_name")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("prd_liability_indicator")
                        .HasColumnType("char(1) ");

                    b.Property<string>("prd_manufacturer")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("prd_name")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("rre_info_id")
                        .HasColumnType("char(9)");

                    b.Property<string>("self_ins_indicator")
                        .HasColumnType("char(1) ");

                    b.Property<string>("self_ins_type")
                        .HasColumnType("char(1) ");

                    b.Property<int?>("seq_id")
                        .HasColumnType("int");

                    b.Property<int?>("status")
                        .HasColumnType("int");

                    b.Property<string>("tin")
                        .HasColumnType("char(9)");

                    b.Property<decimal?>("total_medical_spent")
                        .HasColumnType("numeric(11, 2)");

                    b.Property<decimal?>("tpoc1_amount")
                        .HasColumnType("numeric(11, 2)");

                    b.Property<DateTime?>("tpoc1_date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("tpoc1_fund_delayed_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("tpoc1_seq_no")
                        .HasColumnType("int");

                    b.Property<decimal?>("tpoc2_amount")
                        .HasColumnType("numeric(11, 2)");

                    b.Property<DateTime?>("tpoc2_date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("tpoc2_fund_delayed_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("tpoc2_seq_no")
                        .HasColumnType("int");

                    b.Property<decimal?>("tpoc3_amount")
                        .HasColumnType("numeric(11, 2)");

                    b.Property<DateTime?>("tpoc3_date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("tpoc3_fund_delayed_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("tpoc3_seq_no")
                        .HasColumnType("int");

                    b.Property<decimal?>("tpoc4_amount")
                        .HasColumnType("numeric(11, 2)");

                    b.Property<DateTime?>("tpoc4_date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("tpoc4_fund_delayed_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("tpoc4_seq_no")
                        .HasColumnType("int");

                    b.Property<decimal?>("tpoc5_amount")
                        .HasColumnType("numeric(11, 2)");

                    b.Property<DateTime?>("tpoc5_date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("tpoc5_fund_delayed_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("tpoc5_seq_no")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updated_date")
                        .HasColumnType("datetime");

                    b.Property<string>("venue_state")
                        .HasColumnType("char(2)");

                    b.HasKey("id");

                    b.ToTable("Claim_Staging");
                });
#pragma warning restore 612, 618
        }
    }
}
