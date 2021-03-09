using System;
using System.Collections.Generic;
using System.Text;

namespace DataParser
{
    [CustomClassValidation.CheckLengthType()]
    public class ClaimInput : ClaimInputBase
    {
        #region Property       
        public string msa_amount_medical { get; set; }
        public string msa_amount_rx { get; set; }
        public string msa_vendor { get; set; }
        public string icd10_of_froi { get; set; }
        public string date_of_hire { get; set; }
        public string release_condition { get; set; }
        public string cp_paid { get; set; }
        public string treating_provider_first_name { get; set; }
        public string treating_provider_last_name { get; set; }
        public string provider_address1 { get; set; }
        public string provider_address2 { get; set; }
        public string provider_city { get; set; }
        public string provider_state { get; set; }
        public string provider_zip { get; set; }
        public string provider_specialty { get; set; }
        public string provider_liens_filed { get; set; }
        public string defense_attorney_first_name { get; set; }
        public string defense_attorney_last_name { get; set; }
        public string defense_attorney_firm_name { get; set; }
        public string defense_attorney_expenses_paid { get; set; }
        public string defense_attorney_legal_fees_paid { get; set; }
        public string defense_attorney_address1 { get; set; }
        public string defense_attorney_address2 { get; set; }
        public string defense_attorney_city { get; set; }
        public string defense_attorney_state { get; set; }
        public string defense_attorney_zip { get; set; }
        public string defense_attorney_specialty { get; set; }
        public string defense_attorney_start_date { get; set; }
        public string defense_attorney_end_date { get; set; }
        public string med_legal_payments { get; set; }
        public string med_legal_provider_first_name { get; set; }
        public string med_legal_provider_last_name { get; set; }
        public string med_legal_provider_address1 { get; set; }
        public string med_legal_provider_address2 { get; set; }
        public string med_legal_provider_city { get; set; }
        public string med_legal_provider_state { get; set; }
        public string med_legal_provider_zip { get; set; }
        public string med_legal_specialty { get; set; }
        public string pharmacy_payments { get; set; }
        public string indemnity_rate { get; set; }
        public string type_of_claim { get; set; }
        public string date_last_set { get; set; }
        public string cms_approved_or_non_submit { get; set; }
        public string submitted_amount { get; set; }
        public string approved_amount { get; set; }
        public string fee_paid { get; set; }
        public string claimant_attorney_fees_specialty { get; set; }
        public string claimant_attorney_last_name { get; set; }
        public string claimant_attorney_first_name { get; set; }
        public string claimant_attorney_firm_name { get; set; }
        public string claimant_attorney_address1 { get; set; }
        public string claimant_attorney_address2 { get; set; }
        public string claimant_attorney_city { get; set; }
        public string claimant_attorney_state { get; set; }
        public string claimant_attorney_zip { get; set; }
        public string claimant_attorney_specialty { get; set; }
        public string medical_payments { get; set; }
        public string first_reported_injury_date { get; set; }
        #endregion
    }
}
