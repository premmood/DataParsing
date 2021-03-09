using DataParser.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataParser.Repository
{
    public class ClaimContext : DbContext
    {
        SettingConfig settingConfig = new SettingConfig();
        public ClaimContext()
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();
            configuration.GetSection("ApplicationSettings").Bind(settingConfig);
        }
        public DbSet<claim_staging> Claim_Staging { get; set; }
        public DbSet<tin_staging> Tin_Staging { get; set; }
        public DbSet<file_info> File_Info { get; set; }
        public DbSet<file_error> File_Error { get; set; }
        public DbSet<rre_info> RRE_Info { get; set; }
        public DbSet<tin_info> TIN_Info { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(settingConfig.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region claim_staging
            modelBuilder.Entity<claim_staging>().ToTable("ClaimStaging");
            modelBuilder.Entity<claim_staging>().Property(p => p.action_type).HasColumnType("char(6)");
            modelBuilder.Entity<claim_staging>().Property(p => p.rre_info_id).HasColumnType("char(9)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claim_control_num).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.cms_doi).HasColumnType("date");
            modelBuilder.Entity<claim_staging>().Property(p => p.industry_doi).HasColumnType("date");
            modelBuilder.Entity<claim_staging>().Property(p => p.orm_term_date).HasColumnType("date");
            modelBuilder.Entity<claim_staging>().Property(p => p.venue_state).HasColumnType("char(2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.lost_time).HasColumnType("varchar(20)");
            modelBuilder.Entity<claim_staging>().Property(p => p.total_medical_spent).HasColumnType("numeric(11, 2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.office_code).HasColumnType("char(9)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claim_no).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.orm_indicator).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.tin).HasColumnType("char(9)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_mbi).HasColumnType("varchar(12)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_ssn).HasColumnType("char(9)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_last_name).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_first_name).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_middle_initial).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_gender).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_dob).HasColumnType("date");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_dod).HasColumnType("date");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_address1).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_address2).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_city).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_state).HasColumnType("char(2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_zip_code).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_zip_ext).HasColumnType("char(4)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_phone).HasColumnType("varchar(10)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_phone_ext).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_rep_indicator).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_rep_last_name).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_rep_first_name).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_rep_tin).HasColumnType("char(9)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_rep_address1).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_rep_address2).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_rep_city).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_rep_state).HasColumnType("char(2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_rep_zip_code).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_rep_zip_ext).HasColumnType("char(4)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_rep_phone).HasColumnType("varchar(10)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_rep_phone_ext).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.ip_rep_firm_name).HasColumnType("varchar(70)");
            modelBuilder.Entity<claim_staging>().Property(p => p.plan_ins_type).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.contact_dept).HasColumnType("varchar(70)");
            modelBuilder.Entity<claim_staging>().Property(p => p.contact_last_name).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.contact_first_name).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.contact_phone).HasColumnType("varchar(10)");
            modelBuilder.Entity<claim_staging>().Property(p => p.contact_phone_ext).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.no_fault_limit).HasColumnType("numeric(11, 2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.exhaust_date).HasColumnType("date");
            modelBuilder.Entity<claim_staging>().Property(p => p.adj_last_name).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.adj_first_name).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.adj_phone).HasColumnType("varchar(10)");
            modelBuilder.Entity<claim_staging>().Property(p => p.adj_phone_ext).HasColumnType("char(5) ");
            modelBuilder.Entity<claim_staging>().Property(p => p.adj_email).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.self_ins_indicator).HasColumnType("char(1) ");
            modelBuilder.Entity<claim_staging>().Property(p => p.self_ins_type).HasColumnType("char(1) ");
            modelBuilder.Entity<claim_staging>().Property(p => p.policy_holder_last_name).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.policy_holder_first_name).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.dba_name).HasColumnType("varchar(70)");
            modelBuilder.Entity<claim_staging>().Property(p => p.legal_name).HasColumnType("varchar(70)");
            modelBuilder.Entity<claim_staging>().Property(p => p.policy_no).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.prd_liability_indicator).HasColumnType("char(1) ");
            modelBuilder.Entity<claim_staging>().Property(p => p.prd_name).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.prd_brand_name).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.prd_manufacturer).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.prd_alleged_harm).HasColumnType("varchar(200)");
            modelBuilder.Entity<claim_staging>().Property(p => p.injury_nature).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.injury_cause).HasColumnType("char(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_indicator).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code1).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code2).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code3).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code4).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code5).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code6).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code7).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code8).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code9).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code10).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code11).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code12).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code13).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code14).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code15).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code16).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code17).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code18).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd_code19).HasColumnType("varchar(8)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_relation).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_tin).HasColumnType("char(9)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_last_name).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_first_name).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_middle_initial).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_org_name).HasColumnType("varchar(71)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_address1).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_address2).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_city).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_state).HasColumnType("char(2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_zip_code).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_zip_ext).HasColumnType("char(4)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_phone).HasColumnType("varchar(10)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_phone_ext).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_rep_indicator).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_rep_last_name).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_rep_first_name).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_rep_firm_name).HasColumnType("varchar(70)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_rep_tin).HasColumnType("char(9)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_rep_address1).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_rep_address2).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_rep_city).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_rep_state).HasColumnType("char(2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_rep_zip_code).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_rep_zip_ext).HasColumnType("char(4)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_rep_phone).HasColumnType("varchar(10)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant1_rep_phone_ext).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_relation).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_tin).HasColumnType("char(9)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_last_name).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_first_name).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_middle_initial).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_org_name).HasColumnType("varchar(71)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_address1).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_address2).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_city).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_state).HasColumnType("char(2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_zip_code).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_zip_ext).HasColumnType("char(4)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_phone).HasColumnType("varchar(10)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_phone_ext).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_rep_indicator).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_rep_last_name).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_rep_first_name).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_rep_firm_name).HasColumnType("varchar(70)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_rep_tin).HasColumnType("char(9)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_rep_address1).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_rep_address2).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_rep_city).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_rep_state).HasColumnType("char(2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_rep_zip_code).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_rep_zip_ext).HasColumnType("char(4)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_rep_phone).HasColumnType("varchar(10)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant2_rep_phone_ext).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_relation).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_tin).HasColumnType("char(9)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_last_name).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_first_name).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_middle_initial).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_org_name).HasColumnType("varchar(71)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_address1).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_address2).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_city).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_state).HasColumnType("char(2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_zip_code).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_zip_ext).HasColumnType("char(4)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_phone).HasColumnType("varchar(10)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_phone_ext).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_rep_indicator).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_rep_last_name).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_rep_first_name).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_rep_firm_name).HasColumnType("varchar(70)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_rep_tin).HasColumnType("char(9)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_rep_address1).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_rep_address2).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_rep_city).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_rep_state).HasColumnType("char(2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_rep_zip_code).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_rep_zip_ext).HasColumnType("char(4)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_rep_phone).HasColumnType("varchar(10)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant3_rep_phone_ext).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_relation).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_tin).HasColumnType("char(9)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_last_name).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_first_name).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_middle_initial).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_org_name).HasColumnType("varchar(71)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_address1).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_address2).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_city).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_state).HasColumnType("char(2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_zip_code).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_zip_ext).HasColumnType("char(4)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_phone).HasColumnType("varchar(10)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_phone_ext).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_rep_indicator).HasColumnType("char(1)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_rep_last_name).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_rep_first_name).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_rep_firm_name).HasColumnType("varchar(70)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_rep_tin).HasColumnType("char(9)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_rep_address1).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_rep_address2).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_rep_city).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_rep_state).HasColumnType("char(2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_rep_zip_code).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_rep_zip_ext).HasColumnType("char(4)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_rep_phone).HasColumnType("varchar(10)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant4_rep_phone_ext).HasColumnType("char(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.tpoc1_date).HasColumnType("date");
            modelBuilder.Entity<claim_staging>().Property(p => p.tpoc1_amount).HasColumnType("numeric(11, 2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.tpoc1_fund_delayed_date).HasColumnType("datetime");
            modelBuilder.Entity<claim_staging>().Property(p => p.tpoc2_date).HasColumnType("date");
            modelBuilder.Entity<claim_staging>().Property(p => p.tpoc2_amount).HasColumnType("numeric(11, 2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.tpoc2_fund_delayed_date).HasColumnType("datetime");
            modelBuilder.Entity<claim_staging>().Property(p => p.tpoc3_date).HasColumnType("date");
            modelBuilder.Entity<claim_staging>().Property(p => p.tpoc3_amount).HasColumnType("numeric(11, 2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.tpoc3_fund_delayed_date).HasColumnType("datetime");
            modelBuilder.Entity<claim_staging>().Property(p => p.tpoc4_date).HasColumnType("date");
            modelBuilder.Entity<claim_staging>().Property(p => p.tpoc4_amount).HasColumnType("numeric(11, 2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.tpoc4_fund_delayed_date).HasColumnType("datetime");
            modelBuilder.Entity<claim_staging>().Property(p => p.tpoc5_date).HasColumnType("date");
            modelBuilder.Entity<claim_staging>().Property(p => p.tpoc5_amount).HasColumnType("numeric(11, 2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.tpoc5_fund_delayed_date).HasColumnType("datetime");
            modelBuilder.Entity<claim_staging>().Property(p => p.future_field1).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.future_field2).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.future_field3).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.future_field4).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.future_field5).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.future_field6).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.future_field7).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.future_field8).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.future_field9).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.future_field10).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.created_date).HasColumnType("datetime");
            modelBuilder.Entity<claim_staging>().Property(p => p.updated_date).HasColumnType("datetime");
            modelBuilder.Entity<claim_staging>().Property(p => p.claim_status).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.created_by).HasColumnType("uniqueidentifier");

            modelBuilder.Entity<claim_staging>().Property(p => p.msa_amount_medical               ).HasColumnType("numeric(11, 0)");
            modelBuilder.Entity<claim_staging>().Property(p => p.msa_amount_rx                    ).HasColumnType("numeric(11, 0)");
            modelBuilder.Entity<claim_staging>().Property(p => p.msa_vendor                       ).HasColumnType("varchar(50) ");
            modelBuilder.Entity<claim_staging>().Property(p => p.icd10_of_froi                    ).HasColumnType("varchar(50) ");
            modelBuilder.Entity<claim_staging>().Property(p => p.date_of_hire                     ).HasColumnType("datetime");
            modelBuilder.Entity<claim_staging>().Property(p => p.release_condition                ).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.cp_paid                          ).HasColumnType("bit");
            modelBuilder.Entity<claim_staging>().Property(p => p.treating_provider_first_name     ).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.treating_provider_last_name      ).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.provider_address1                ).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.provider_address2                ).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.provider_city                    ).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.provider_state                   ).HasColumnType("varchar(2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.provider_zip                     ).HasColumnType("varchar(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.provider_specialty               ).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.provider_liens_filed             ).HasColumnType("bit");
            modelBuilder.Entity<claim_staging>().Property(p => p.defense_attorney_first_name      ).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.defense_attorney_last_name       ).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.defense_attorney_firm_name       ).HasColumnType("varchar(70)");
            modelBuilder.Entity<claim_staging>().Property(p => p.defense_attorney_expenses_paid   ).HasColumnType("numeric(11, 0)");
            modelBuilder.Entity<claim_staging>().Property(p => p.defense_attorney_legal_fees_paid ).HasColumnType("numeric(11, 0)");
            modelBuilder.Entity<claim_staging>().Property(p => p.defense_attorney_address1        ).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.defense_attorney_address2        ).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.defense_attorney_city            ).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.defense_attorney_state           ).HasColumnType("varchar(2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.defense_attorney_zip             ).HasColumnType("varchar(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.defense_attorney_specialty       ).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.defense_attorney_start_date      ).HasColumnType("date");
            modelBuilder.Entity<claim_staging>().Property(p => p.defense_attorney_end_date        ).HasColumnType("date");
            modelBuilder.Entity<claim_staging>().Property(p => p.med_legal_payments               ).HasColumnType("numeric(11, 0)");
            modelBuilder.Entity<claim_staging>().Property(p => p.med_legal_provider_first_name    ).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.med_legal_provider_last_name     ).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.med_legal_provider_address1      ).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.med_legal_provider_address2      ).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.med_legal_provider_city          ).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.med_legal_provider_state         ).HasColumnType("varchar(2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.med_legal_provider_zip           ).HasColumnType("varchar(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.med_legal_specialty              ).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.pharmacy_payments                ).HasColumnType("numeric(11, 0)");
            modelBuilder.Entity<claim_staging>().Property(p => p.indemnity_rate                   ).HasColumnType("numeric(11, 0)");
            modelBuilder.Entity<claim_staging>().Property(p => p.type_of_claim                    ).HasColumnType("varchar(50) ");
            modelBuilder.Entity<claim_staging>().Property(p => p.date_last_set                    ).HasColumnType("date ");
            modelBuilder.Entity<claim_staging>().Property(p => p.cms_approved_or_non_submit       ).HasColumnType("numeric(11, 0)");
            modelBuilder.Entity<claim_staging>().Property(p => p.submitted_amount                 ).HasColumnType("numeric(11, 0)");
            modelBuilder.Entity<claim_staging>().Property(p => p.approved_amount                  ).HasColumnType("numeric(11, 0)");
            modelBuilder.Entity<claim_staging>().Property(p => p.fee_paid                         ).HasColumnType("numeric(11, 0)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant_attorney_fees_specialty ).HasColumnType("numeric(11, 0)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant_attorney_last_name      ).HasColumnType("varchar(40)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant_attorney_first_name     ).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant_attorney_firm_name      ).HasColumnType("varchar(70)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant_attorney_address1       ).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant_attorney_address2       ).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant_attorney_city           ).HasColumnType("varchar(30)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant_attorney_state          ).HasColumnType("varchar(2)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant_attorney_zip            ).HasColumnType("varchar(5)");
            modelBuilder.Entity<claim_staging>().Property(p => p.claimant_attorney_specialty      ).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.medical_payments                 ).HasColumnType("varchar(50)");
            modelBuilder.Entity<claim_staging>().Property(p => p.first_reported_injury_date       ).HasColumnType("varchar(50)");
           




            #endregion

            #region tin_staging
            modelBuilder.Entity<tin_staging>().ToTable("TinStaging");
            modelBuilder.Entity<tin_staging>().Property(p => p.tin).IsRequired().HasColumnType("char(9)");
            modelBuilder.Entity<tin_staging>().Property(p => p.office_code_site_id).HasColumnType("char(9)");
            modelBuilder.Entity<tin_staging>().Property(p => p.office_code_mailing_name).HasColumnType("varchar(70)");
            modelBuilder.Entity<tin_staging>().Property(p => p.office_code_mailing_address1).HasColumnType("varchar(50)");
            modelBuilder.Entity<tin_staging>().Property(p => p.office_code_mailing_address2).HasColumnType("varchar(50)");
            modelBuilder.Entity<tin_staging>().Property(p => p.office_code_city).HasColumnType("varchar(30)");
            modelBuilder.Entity<tin_staging>().Property(p => p.office_code_state).HasColumnType("char(2)");
            modelBuilder.Entity<tin_staging>().Property(p => p.office_code_zip).HasColumnType("char(5)");
            modelBuilder.Entity<tin_staging>().Property(p => p.office_code_zip_ext).HasColumnType("char(4)");
            modelBuilder.Entity<tin_staging>().Property(p => p.foreign_rre_address1).HasColumnType("varchar(32)");
            modelBuilder.Entity<tin_staging>().Property(p => p.foreign_rre_address2).HasColumnType("varchar(32)");
            modelBuilder.Entity<tin_staging>().Property(p => p.foreign_rre_address3).HasColumnType("varchar(32)");
            modelBuilder.Entity<tin_staging>().Property(p => p.foreign_rre_address4).HasColumnType("varchar(32)");
            modelBuilder.Entity<tin_staging>().Property(p => p.recovery_agent_mailing_name).HasColumnType("varchar(70)");
            modelBuilder.Entity<tin_staging>().Property(p => p.recovery_agent_mailing_address1).HasColumnType("varchar(50)");
            modelBuilder.Entity<tin_staging>().Property(p => p.recovery_agent_mailing_address2).HasColumnType("varchar(50)");
            modelBuilder.Entity<tin_staging>().Property(p => p.recovery_agent_city).HasColumnType("varchar(30)");
            modelBuilder.Entity<tin_staging>().Property(p => p.recovery_agent_state).HasColumnType("varchar(2)");
            modelBuilder.Entity<tin_staging>().Property(p => p.recovery_agent_zip).HasColumnType("char(5)");
            modelBuilder.Entity<tin_staging>().Property(p => p.recovery_agent_zip_ext).HasColumnType("char(4)");
            modelBuilder.Entity<claim_staging>().Property(p => p.created_by).HasColumnType("uniqueidentifier");
            modelBuilder.Entity<tin_staging>().Property(p => p.created_date).HasColumnType("datetime");
            modelBuilder.Entity<tin_staging>().Property(p => p.updated_by).HasColumnType("uniqueidentifier");
            modelBuilder.Entity<tin_staging>().Property(p => p.updated_date).HasColumnType("datetime");


            #endregion

            #region file_info
            modelBuilder.Entity<file_info>().ToTable("FileInfo");
            modelBuilder.Entity<file_info>().Property(p => p.file_name).HasColumnType("varchar(100)");
            modelBuilder.Entity<file_info>().Property(p => p.file_type).HasColumnType("varchar(100)");
            modelBuilder.Entity<file_info>().Property(p => p.transaction_date).HasColumnType("datetime");
            modelBuilder.Entity<file_info>().Property(p => p.file_status).HasColumnType("varchar(10)");
            modelBuilder.Entity<file_info>().Property(p => p.env).HasColumnType("char(4)");
            modelBuilder.Entity<file_info>().Property(p => p.start_date).HasColumnType("datetime");
            modelBuilder.Entity<file_info>().Property(p => p.end_date).HasColumnType("datetime");
            modelBuilder.Entity<file_info>().Property(p => p.received_date).HasColumnType("datetime");
            #endregion

            #region file_error
            modelBuilder.Entity<file_error>().ToTable("FileError");
            modelBuilder.Entity<file_error>().Property(p => p.error_code).HasColumnType("char(10)");
            modelBuilder.Entity<file_error>().Property(p => p.field_name).HasColumnType("varchar(50)");
            modelBuilder.Entity<file_error>().Property(p => p.value).HasColumnType("varchar(200)");
            modelBuilder.Entity<file_error>().Property(p => p.seq_id).HasColumnType("int");
            modelBuilder.Entity<file_error>().Property(p => p.claim_control_number).HasColumnType("varchar(50)");
            modelBuilder.Entity<file_error>().Property(p => p.account_id).HasColumnType("varchar(50)");
            modelBuilder.Entity<file_error>().Property(p => p.rre_info_id).HasColumnType("char(9)");
            modelBuilder.Entity<file_error>().Property(p => p.error_date).HasColumnType("datetime");
            modelBuilder.Entity<file_error>().Property(p => p.created_by).HasColumnType("int");
            modelBuilder.Entity<file_error>().Property(p => p.created_date).HasColumnType("datetime");
            modelBuilder.Entity<file_error>().Property(p => p.updated_by).HasColumnType("int");
            modelBuilder.Entity<file_error>().Property(p => p.updated_date).HasColumnType("datetime");
            #endregion

            #region rre_info
            modelBuilder.Entity<rre_info>().ToTable("RREInfo");
            modelBuilder.Entity<rre_info>().Property(p => p.rre_id).HasColumnType("char(9)");
            modelBuilder.Entity<rre_info>().Property(p => p.rre_name).HasColumnType("varchar(200)");
            modelBuilder.Entity<rre_info>().Property(p => p.address1).HasColumnType("varchar(150)");
            modelBuilder.Entity<rre_info>().Property(p => p.address2).HasColumnType("varchar(150)");
            modelBuilder.Entity<rre_info>().Property(p => p.city).HasColumnType("varchar(150)");
            modelBuilder.Entity<rre_info>().Property(p => p.state).HasColumnType("char(2)");
            modelBuilder.Entity<rre_info>().Property(p => p.zip_code).HasColumnType("char(5)");
            modelBuilder.Entity<rre_info>().Property(p => p.zip_ext).HasColumnType("char(4)");
            modelBuilder.Entity<rre_info>().Property(p => p.phone1).HasColumnType("varchar(10)");
            modelBuilder.Entity<rre_info>().Property(p => p.phone2).HasColumnType("varchar(10)");
            modelBuilder.Entity<rre_info>().Property(p => p.reporting_period).HasColumnType("tinyint");
            modelBuilder.Entity<rre_info>().Property(p => p.reporting_period).HasColumnType("int");
            modelBuilder.Entity<rre_info>().Property(p => p.authorized_rep_name).HasColumnType("varchar(100)");
            modelBuilder.Entity<rre_info>().Property(p => p.authorized_rep_email).HasColumnType("varchar(100)");
            modelBuilder.Entity<rre_info>().Property(p => p.authorized_rep_phone).HasColumnType("varchar(20)");
            modelBuilder.Entity<rre_info>().Property(p => p.account_manager_name).HasColumnType("varchar(100)");
            modelBuilder.Entity<rre_info>().Property(p => p.account_manager_email).HasColumnType("varchar(100)");
            modelBuilder.Entity<rre_info>().Property(p => p.account_manager_phone).HasColumnType("varchar(20)");
            modelBuilder.Entity<rre_info>().Property(p => p.account_id).HasColumnType("int");
            modelBuilder.Entity<rre_info>().Property(p => p.authorized_rep_phone).HasColumnType("varchar(150)");
            modelBuilder.Entity<rre_info>().Property(p => p.reporting_agent).HasColumnType("varchar(150)");
            modelBuilder.Entity<rre_info>().Property(p => p.rre_status).HasColumnType("tinyint");
            modelBuilder.Entity<rre_info>().Property(p => p.edi_rep_name).HasColumnType("varchar(200)");
            modelBuilder.Entity<rre_info>().Property(p => p.edi_rep_email).HasColumnType("varchar(200)");
            modelBuilder.Entity<rre_info>().Property(p => p.edi_rep_phone).HasColumnType("varchar(200)");
            modelBuilder.Entity<rre_info>().Property(p => p.created_by).HasColumnType("int");
            modelBuilder.Entity<rre_info>().Property(p => p.updated_date).HasColumnType("datetime");
            modelBuilder.Entity<rre_info>().Property(p => p.updated_by).HasColumnType("int");
            modelBuilder.Entity<rre_info>().Property(p => p.created_date).HasColumnType("datetime");
            modelBuilder.Entity<rre_info>().Property(p => p.plan_tin).HasColumnType("char(9)");
            #endregion                  

            #region tin_info
            modelBuilder.Entity<tin_info>().ToTable("TINInfo");
            modelBuilder.Entity<tin_info>().Property(p => p.tin).HasColumnType("char(9)");
            modelBuilder.Entity<tin_info>().Property(p => p.rre_id).HasColumnType("char(9)");
            modelBuilder.Entity<tin_info>().Property(p => p.recovery_agent_mailing_name).HasColumnType("varchar(70)");
            modelBuilder.Entity<tin_info>().Property(p => p.recovery_agent_mailing_name).HasColumnType("varchar(70)");
            modelBuilder.Entity<tin_info>().Property(p => p.recovery_agent_mail_address1).HasColumnType("varchar(50)");
            modelBuilder.Entity<tin_info>().Property(p => p.recovery_agent_mail_address2).HasColumnType("varchar(50)");
            modelBuilder.Entity<tin_info>().Property(p => p.recovery_agent_city).HasColumnType("varchar(30)");
            modelBuilder.Entity<tin_info>().Property(p => p.recovery_agent_state).HasColumnType("char(2)");
            modelBuilder.Entity<tin_info>().Property(p => p.recovery_agent_zip).HasColumnType("char(5)");
            modelBuilder.Entity<tin_info>().Property(p => p.recovery_agent_zip_ext).HasColumnType("char(4)");
            modelBuilder.Entity<tin_info>().Property(p => p.foreign_rre_address1).HasColumnType("varchar(32)");
            modelBuilder.Entity<tin_info>().Property(p => p.foreign_rre_address2).HasColumnType("varchar(32)");
            modelBuilder.Entity<tin_info>().Property(p => p.foreign_rre_address3).HasColumnType("varchar(32)");
            modelBuilder.Entity<tin_info>().Property(p => p.foreign_rre_address4).HasColumnType("varchar(32)");
            modelBuilder.Entity<tin_info>().Property(p => p.submission_date).HasColumnType("datetime");
            modelBuilder.Entity<tin_info>().Property(p => p.created_date).HasColumnType("datetime");
            modelBuilder.Entity<tin_info>().Property(p => p.updated_date).HasColumnType("datetime");
            modelBuilder.Entity<tin_info>().Property(p => p.office_code_site_id).HasColumnType("varchar(9)");
            modelBuilder.Entity<tin_info>().Property(p => p.tin_mailing_name).HasColumnType("varchar(70)");
            modelBuilder.Entity<tin_info>().Property(p => p.tin_mail_address1).HasColumnType("varchar(50)");
            modelBuilder.Entity<tin_info>().Property(p => p.tin_mail_address2).HasColumnType("varchar(50)");
            modelBuilder.Entity<tin_info>().Property(p => p.tin_city).HasColumnType("varchar(30)");
            modelBuilder.Entity<tin_info>().Property(p => p.tin_state).HasColumnType("char(2)");
            modelBuilder.Entity<tin_info>().Property(p => p.tin_zip).HasColumnType("char(5)");
            modelBuilder.Entity<tin_info>().Property(p => p.tin_zip_ext).HasColumnType("char(4)");
            #endregion

            modelBuilder.Entity<claim_staging>().HasKey(c => c.id);
            modelBuilder.Entity<rre_info>().HasKey(c => c.rre_id);           


        }

    }
}
