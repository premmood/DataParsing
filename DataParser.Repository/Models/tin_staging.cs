using DataParser.Repository;
using DataParser.Repository.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataParser.Repository.Models
{
    public class tin_staging
    {
        private IUnitOfWork _unitOfWork;
        public tin_staging()
        {
            this._unitOfWork = _unitOfWork ?? new UnitOfWork();
        }
        #region properties
        public int id { get; set; }
        public string tin { get; set; }
        public string office_code_site_id { get; set; }
        public int? file_id { get; set; }
        public int seq_id { get; set; }
        public string office_code_mailing_name { get; set; }
        public string office_code_mailing_address1 { get; set; }
        public string office_code_mailing_address2 { get; set; }
        public string office_code_city { get; set; }
        public string office_code_state { get; set; }
        public string office_code_zip { get; set; }
        public string office_code_zip_ext { get; set; }
        public string foreign_rre_address1 { get; set; }
        public string foreign_rre_address2 { get; set; }
        public string foreign_rre_address3 { get; set; }
        public string foreign_rre_address4 { get; set; }
        public string recovery_agent_mailing_name { get; set; }
        public string recovery_agent_mailing_address1 { get; set; }
        public string recovery_agent_mailing_address2 { get; set; }
        public string recovery_agent_city { get; set; }
        public string recovery_agent_state { get; set; }
        public string recovery_agent_zip { get; set; }
        public string recovery_agent_zip_ext { get; set; }
        public int? account_id { get; set; }
        public DateTime? submission_date { get; set; }
        public Guid? created_by { get; set; }
        public DateTime? created_date { get; set; }
        public Guid? updated_by { get; set; }
        public DateTime? updated_date { get; set; }

        #endregion
        public void Truncate()
        {
            try
            {
                this._unitOfWork.TinStagingRepository.Truncate();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void CallRunValidationOnTinStagingProcs(int file_id)
        {
            _unitOfWork.ClaimStagingRepository.ExecWithStoreProcedure(
             "dbo.usp_RunValidationOnTINStaging @file_id",
             new SqlParameter("file_id", SqlDbType.BigInt) { Value = file_id });
        }
        public void CallMergeTINCascadingTablesProcs()
        {
            _unitOfWork.ClaimStagingRepository.ExecWithStoreProcedure(
             "dbo.usp_MergeTINCascadingTables",
             null);
        }
        public void CallRunValidationOnTINFileProcs(int file_id)
        {
            _unitOfWork.ClaimStagingRepository.ExecWithStoreProcedure(
             "dbo.usp_RunValidationOnTINFile @file_id",
              new SqlParameter("@file_id", SqlDbType.BigInt) { Value = file_id });
        }
        public List<response_file> CallGetTINResponseProcs(int file_id)
        {
            return (List<response_file>)_unitOfWork.ClaimStagingRepository.ExecStoreProcedureForResult("usp_GetTINResponse",
                 new SqlParameter[] { new SqlParameter("@file_id", SqlDbType.BigInt) { Value = file_id } });
        }
    }
}
