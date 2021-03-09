using DataParser.Repository;
using DataParser.Repository.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DataParser
{

    public class claim_staging: ClaimStagingBase
    {
        private IUnitOfWork _unitOfWork;
        public claim_staging()
        {
            this._unitOfWork = _unitOfWork ?? new UnitOfWork();
        }

        #region Property
        public double? msa_amount_medical { get; set; }
        public double? msa_amount_rx { get; set; }
        public string msa_vendor { get; set; }
        public string icd10_of_froi { get; set; }
        public DateTime? date_of_hire { get; set; }
        public string release_condition { get; set; }
        public bool cp_paid { get; set; }// = true;
        public string treating_provider_first_name { get; set; }
        public string treating_provider_last_name { get; set; }
        public string provider_address1 { get; set; }
        public string provider_address2 { get; set; }
        public string provider_city { get; set; }
        public string provider_state { get; set; }
        public string provider_zip { get; set; }
        public string provider_specialty { get; set; }
        public bool? provider_liens_filed { get; set; }
        public string defense_attorney_first_name { get; set; }
        public string defense_attorney_last_name { get; set; }
        public string defense_attorney_firm_name { get; set; }
        public double? defense_attorney_expenses_paid { get; set; }
        public double? defense_attorney_legal_fees_paid { get; set; }
        public string defense_attorney_address1 { get; set; }
        public string defense_attorney_address2 { get; set; }
        public string defense_attorney_city { get; set; }
        public string defense_attorney_state { get; set; }
        public string defense_attorney_zip { get; set; }
        public string defense_attorney_specialty { get; set; }
        public DateTime? defense_attorney_start_date { get; set; }
        public DateTime? defense_attorney_end_date { get; set; }
        public double? med_legal_payments { get; set; }
        public string med_legal_provider_first_name { get; set; }
        public string med_legal_provider_last_name { get; set; }
        public string med_legal_provider_address1 { get; set; }
        public string med_legal_provider_address2 { get; set; }
        public string med_legal_provider_city { get; set; }
        public string med_legal_provider_state { get; set; }
        public string med_legal_provider_zip { get; set; }
        public string med_legal_specialty { get; set; }
        public double? pharmacy_payments { get; set; }
        public double? indemnity_rate { get; set; }
        public string type_of_claim { get; set; }
        public DateTime? date_last_set { get; set; }
        public double? cms_approved_or_non_submit { get; set; }
        public double? submitted_amount { get; set; }
        public double? approved_amount { get; set; }
        public double? fee_paid { get; set; }
        public double? claimant_attorney_fees_specialty { get; set; }
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

        //public claim_staging getPropertyVal(claim_staging asObj)
        //{
        //    PropertyInfo[] propInfos = asObj.GetType().GetProperties();
        //    string strAttributeValue = "10";
        //    foreach (PropertyInfo propInfo in propInfos)
        //    {
        //        // Getting the value
        //        var propValue = propInfo.GetValue(asObj, null);

        //        // Setting the value
        //        propInfo.SetValue(asObj, Convert.ChangeType(strAttributeValue, propInfo.PropertyType), null);

        //    }
        //    return asObj;
        //}
        public bool CheckForDuplicateClaim()
        {
            bool duplicateClaim = false;
            try
            {
                //duplicateClaim = this._unitOfWork.AuxRepository.Contains(x => (x.dcn == this.dcn));
                claim_staging msp = this._unitOfWork.ClaimStagingRepository.All().Where(x => (x.claim_info_id == this.claim_info_id)).FirstOrDefault();
                if (msp != null)
                {
                    duplicateClaim = true;
                }

                return duplicateClaim;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void Truncate()
        {
            try
            {
                this._unitOfWork.ClaimStagingRepository.Truncate();
            }
            catch (Exception)
            {

                throw;
            }
        
        }
        public void CallRunValidationOnClaimStagingProcs(int file_id)
        {
            _unitOfWork.ClaimStagingRepository.ExecWithStoreProcedure(
             "dbo.usp_RunValidationOnClaimStaging @file_id",
             new SqlParameter("file_id", SqlDbType.BigInt) { Value = file_id });
        }
        public void CallMergeCascadingTablesProcs()
        {
            _unitOfWork.ClaimStagingRepository.ExecWithStoreProcedure(
             "dbo.usp_MergeCascadingTables",
             null);
        }
        public void CallRunValidationOnClaimFileProcs(int file_id)
        {
            _unitOfWork.ClaimStagingRepository.ExecWithStoreProcedure(
             "dbo.usp_RunValidationOnClaimFile @file_id",
              new SqlParameter("@file_id", SqlDbType.BigInt) { Value = file_id });
        }
        public void CallSetStatusOnClaimFileProcs(int file_id)
        {
            _unitOfWork.ClaimStagingRepository.ExecWithStoreProcedure(
             "dbo.usp_SetStatusOnClaimFile @file_id",
              new SqlParameter("@file_id", SqlDbType.BigInt) { Value = file_id });
        }
        public List<response_file> CallGetResponseForFileProcs( int file_id)
        {
            return (List<response_file>)_unitOfWork.ClaimStagingRepository.ExecStoreProcedureForResult("usp_GetResponseForFile",
              new SqlParameter[] { new SqlParameter("@file_id", SqlDbType.BigInt) { Value = file_id } });
        }
        public string Create()
        {
            string result = "true";
            try
            {
                this._unitOfWork.ClaimStagingRepository.Create(this);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public bool UpdateClaim()
        {
            bool result = true;
            claim_staging claimInput = this._unitOfWork.ClaimStagingRepository.All().Single(a => a.claim_info_id == this.claim_info_id);
            try
            {
                #region 
                claimInput.claim_info_id = this.claim_info_id;
                claimInput.file_id = this.file_id;
                claimInput.seq_id = this.seq_id;
                claimInput.action_type = this.action_type;
                claimInput.rre_info_id = this.rre_info_id;
                claimInput.claim_control_num = this.claim_control_num;
                claimInput.cms_doi = this.cms_doi;
                claimInput.industry_doi = this.industry_doi;
                claimInput.orm_term_date = this.orm_term_date;
                claimInput.venue_state = this.venue_state;

                #endregion

                this._unitOfWork.ClaimStagingRepository.Update(claimInput);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
              
    }


}
