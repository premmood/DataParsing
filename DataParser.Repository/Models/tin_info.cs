using System;
using System.Collections.Generic;
using System.Text;

namespace DataParser.Repository.Models
{
    public class tin_info
    {
        private IUnitOfWork _unitOfWork;
        public tin_info()
        {
            this._unitOfWork = _unitOfWork ?? new UnitOfWork();
        }

        #region Properties
        public int ID { get; set; }
        public string tin { get; set; }
        public string rre_id { get; set; }
        public int? file_id { get; set; }
        public int? seq_id { get; set; }
        public string office_code_site_id { get; set; }
        public string tin_mailing_name { get; set; }
        public string tin_mail_address1 { get; set; }
        public string tin_mail_address2 { get; set; }
        public string tin_city { get; set; }
        public string tin_state { get; set; }
        public string tin_zip { get; set; }
        public string tin_zip_ext { get; set; }
        public string foreign_rre_address1 { get; set; }
        public string foreign_rre_address2 { get; set; }
        public string foreign_rre_address3 { get; set; }
        public string foreign_rre_address4 { get; set; }
        public string recovery_agent_mailing_name { get; set; }
        public string recovery_agent_mail_address1 { get; set; }
        public string recovery_agent_mail_address2 { get; set; }
        public string recovery_agent_city { get; set; }
        public string recovery_agent_state { get; set; }
        public string recovery_agent_zip { get; set; }
        public string recovery_agent_zip_ext { get; set; }
        public int? account_id { get; set; }
        public DateTime? submission_date { get; set; }
        public int? created_by { get; set; }
        public DateTime? created_date { get; set; }
        public int? updated_by { get; set; }
        public DateTime? updated_date { get; set; }

        #endregion

        public bool TinOfficeCodeExists(string TIN, string OfficeCode)
        {
            bool result = true;
            try
            {
                result = this._unitOfWork.TininfoRepository.Contains(x => x.tin == TIN && x.office_code_site_id==OfficeCode);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

    }
}
