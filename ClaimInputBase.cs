﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataParser
{
    public class ClaimInputBase
    {
        #region Properties
        public int id { get; set; }
        public string claim_info_id { get; set; }
        public string file_id { get; set; }
        public string seq_id { get; set; }
        public string action_type { get; set; }
        public string rre_info_id { get; set; }
        public string claim_control_num { get; set; }
        public string cms_doi { get; set; }
        public string industry_doi { get; set; }
        public string orm_term_date { get; set; }
        public string venue_state { get; set; }
        public string lost_time { get; set; }
        public string total_medical_spent { get; set; }
        public string office_code { get; set; }
        public string claim_no { get; set; }
        public string orm_indicator { get; set; }
        public string tin { get; set; }
        public string ip_mbi { get; set; }
        //public string ip_hicn { get; set; }
        public string ip_ssn { get; set; }
        public string ip_last_name { get; set; }
        public string ip_first_name { get; set; }
        public string ip_middle_initial { get; set; }
        public string ip_gender { get; set; }
        public string ip_dob { get; set; }
        public string ip_dod { get; set; }
        public string ip_address1 { get; set; }
        public string ip_address2 { get; set; }
        public string ip_city { get; set; }
        public string ip_state { get; set; }
        public string ip_zip_code { get; set; }
        public string ip_zip_ext { get; set; }
        public string ip_phone { get; set; }
        public string ip_phone_ext { get; set; }
        public string ip_rep_indicator { get; set; }
        public string ip_rep_last_name { get; set; }
        public string ip_rep_first_name { get; set; }
        public string ip_rep_tin { get; set; }
        public string ip_rep_address1 { get; set; }
        public string ip_rep_address2 { get; set; }
        public string ip_rep_city { get; set; }
        public string ip_rep_state { get; set; }
        public string ip_rep_zip_code { get; set; }
        public string ip_rep_zip_ext { get; set; }
        public string ip_rep_phone { get; set; }
        public string ip_rep_phone_ext { get; set; }
        public string ip_rep_firm_name { get; set; }
        public string plan_ins_type { get; set; }
        public string contact_dept { get; set; }
        public string contact_last_name { get; set; }
        public string contact_first_name { get; set; }
        public string contact_phone { get; set; }
        public string contact_phone_ext { get; set; }
        public string no_fault_limit { get; set; }
        public string exhaust_date { get; set; }
        public string adj_last_name { get; set; }
        public string adj_first_name { get; set; }
        public string adj_phone { get; set; }
        public string adj_phone_ext { get; set; }
        public string adj_email { get; set; }
        public string self_ins_indicator { get; set; }
        public string self_ins_type { get; set; }
        public string policy_holder_last_name { get; set; }
        public string policy_holder_first_name { get; set; }
        public string dba_name { get; set; }
        public string legal_name { get; set; }
        public string policy_no { get; set; }
        public string prd_liability_indicator { get; set; }
        public string prd_name { get; set; }
        public string prd_brand_name { get; set; }
        public string prd_manufacturer { get; set; }
        public string prd_alleged_harm { get; set; }
        public string injury_nature { get; set; }
        public string injury_cause { get; set; }
        public string icd_indicator { get; set; }
        public string icd_code1 { get; set; }
        public string icd_code2 { get; set; }
        public string icd_code3 { get; set; }
        public string icd_code4 { get; set; }
        public string icd_code5 { get; set; }
        public string icd_code6 { get; set; }
        public string icd_code7 { get; set; }
        public string icd_code8 { get; set; }
        public string icd_code9 { get; set; }
        public string icd_code10 { get; set; }
        public string icd_code11 { get; set; }
        public string icd_code12 { get; set; }
        public string icd_code13 { get; set; }
        public string icd_code14 { get; set; }
        public string icd_code15 { get; set; }
        public string icd_code16 { get; set; }
        public string icd_code17 { get; set; }
        public string icd_code18 { get; set; }
        public string icd_code19 { get; set; }
        public string claimant1_relation { get; set; }
        public string claimant1_tin { get; set; }
        public string claimant1_last_name { get; set; }
        public string claimant1_first_name { get; set; }
        public string claimant1_middle_initial { get; set; }
        public string claimant1_org_name { get; set; }
        public string claimant1_address1 { get; set; }
        public string claimant1_address2 { get; set; }
        public string claimant1_city { get; set; }
        public string claimant1_state { get; set; }
        public string claimant1_zip_code { get; set; }
        public string claimant1_zip_ext { get; set; }
        public string claimant1_phone { get; set; }
        public string claimant1_phone_ext { get; set; }
        public string claimant1_rep_indicator { get; set; }
        public string claimant1_rep_last_name { get; set; }
        public string claimant1_rep_first_name { get; set; }
        public string claimant1_rep_firm_name { get; set; }
        public string claimant1_rep_tin { get; set; }
        public string claimant1_rep_address1 { get; set; }
        public string claimant1_rep_address2 { get; set; }
        public string claimant1_rep_city { get; set; }
        public string claimant1_rep_state { get; set; }
        public string claimant1_rep_zip_code { get; set; }
        public string claimant1_rep_zip_ext { get; set; }
        public string claimant1_rep_phone { get; set; }
        public string claimant1_rep_phone_ext { get; set; }
        public string claimant1_seq_no { get; set; }
        public string claimant2_relation { get; set; }
        public string claimant2_tin { get; set; }
        public string claimant2_last_name { get; set; }
        public string claimant2_first_name { get; set; }
        public string claimant2_middle_initial { get; set; }
        public string claimant2_org_name { get; set; }
        public string claimant2_address1 { get; set; }
        public string claimant2_address2 { get; set; }
        public string claimant2_city { get; set; }
        public string claimant2_state { get; set; }
        public string claimant2_zip_code { get; set; }
        public string claimant2_zip_ext { get; set; }
        public string claimant2_phone { get; set; }
        public string claimant2_phone_ext { get; set; }
        public string claimant2_rep_indicator { get; set; }
        public string claimant2_rep_last_name { get; set; }
        public string claimant2_rep_first_name { get; set; }
        public string claimant2_rep_firm_name { get; set; }
        public string claimant2_rep_tin { get; set; }
        public string claimant2_rep_address1 { get; set; }
        public string claimant2_rep_address2 { get; set; }
        public string claimant2_rep_city { get; set; }
        public string claimant2_rep_state { get; set; }
        public string claimant2_rep_zip_code { get; set; }
        public string claimant2_rep_zip_ext { get; set; }
        public string claimant2_rep_phone { get; set; }
        public string claimant2_rep_phone_ext { get; set; }
        public string claimant2_seq_no { get; set; }
        public string claimant3_relation { get; set; }
        public string claimant3_tin { get; set; }
        public string claimant3_last_name { get; set; }
        public string claimant3_first_name { get; set; }
        public string claimant3_middle_initial { get; set; }
        public string claimant3_org_name { get; set; }
        public string claimant3_address1 { get; set; }
        public string claimant3_address2 { get; set; }
        public string claimant3_city { get; set; }
        public string claimant3_state { get; set; }
        public string claimant3_zip_code { get; set; }
        public string claimant3_zip_ext { get; set; }
        public string claimant3_phone { get; set; }
        public string claimant3_phone_ext { get; set; }
        public string claimant3_rep_indicator { get; set; }
        public string claimant3_rep_last_name { get; set; }
        public string claimant3_rep_first_name { get; set; }
        public string claimant3_rep_firm_name { get; set; }
        public string claimant3_rep_tin { get; set; }
        public string claimant3_rep_address1 { get; set; }
        public string claimant3_rep_address2 { get; set; }
        public string claimant3_rep_city { get; set; }
        public string claimant3_rep_state { get; set; }
        public string claimant3_rep_zip_code { get; set; }
        public string claimant3_rep_zip_ext { get; set; }
        public string claimant3_rep_phone { get; set; }
        public string claimant3_rep_phone_ext { get; set; }
        public string claimant3_seq_no { get; set; }
        public string claimant4_relation { get; set; }
        public string claimant4_tin { get; set; }
        public string claimant4_last_name { get; set; }
        public string claimant4_first_name { get; set; }
        public string claimant4_middle_initial { get; set; }
        public string claimant4_org_name { get; set; }
        public string claimant4_address1 { get; set; }
        public string claimant4_address2 { get; set; }
        public string claimant4_city { get; set; }
        public string claimant4_state { get; set; }
        public string claimant4_zip_code { get; set; }
        public string claimant4_zip_ext { get; set; }
        public string claimant4_phone { get; set; }
        public string claimant4_phone_ext { get; set; }
        public string claimant4_rep_indicator { get; set; }
        public string claimant4_rep_last_name { get; set; }
        public string claimant4_rep_first_name { get; set; }
        public string claimant4_rep_firm_name { get; set; }
        public string claimant4_rep_tin { get; set; }
        public string claimant4_rep_address1 { get; set; }
        public string claimant4_rep_address2 { get; set; }
        public string claimant4_rep_city { get; set; }
        public string claimant4_rep_state { get; set; }
        public string claimant4_rep_zip_code { get; set; }
        public string claimant4_rep_zip_ext { get; set; }
        public string claimant4_rep_phone { get; set; }
        public string claimant4_rep_phone_ext { get; set; }
        public string claimant4_seq_no { get; set; }
        public string tpoc1_date { get; set; }
        public string tpoc1_amount { get; set; }
        public string tpoc1_fund_delayed_date { get; set; }
        public string tpoc1_seq_no { get; set; }
        public string tpoc2_date { get; set; }
        public string tpoc2_amount { get; set; }
        public string tpoc2_fund_delayed_date { get; set; }
        public string tpoc2_seq_no { get; set; }
        public string tpoc3_date { get; set; }
        public string tpoc3_amount { get; set; }
        public string tpoc3_fund_delayed_date { get; set; }
        public string tpoc3_seq_no { get; set; }
        public string tpoc4_date { get; set; }
        public string tpoc4_amount { get; set; }
        public string tpoc4_fund_delayed_date { get; set; }
        public string tpoc4_seq_no { get; set; }
        public string tpoc5_date { get; set; }
        public string tpoc5_amount { get; set; }
        public string tpoc5_fund_delayed_date { get; set; }
        public string tpoc5_seq_no { get; set; }
        public string future_field1 { get; set; }
        public string future_field2 { get; set; }
        public string future_field3 { get; set; }
        public string future_field4 { get; set; }
        public string future_field5 { get; set; }
        public string future_field6 { get; set; }
        public string future_field7 { get; set; }
        public string future_field8 { get; set; }
        public string future_field9 { get; set; }
        public string future_field10 { get; set; }
        public string created_date { get; set; }
        public string updated_date { get; set; }
        public string status { get; set; }
        public string claim_status { get; set; }
        public string account_id { get; set; }
        public string created_by { get; set; }
        #endregion
    }

}
