using System;
using System.Collections.Generic;
using System.Text;

namespace DataParser
{
    [CustomClassValidation.CheckLengthType()]
    public class TinInput
    {
        #region properties
        public int id { get; set; }
        public string tin { get; set; }
        public string office_code_site_id { get; set; }
        public string file_id { get; set; }
        public string seq_id { get; set; }
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
        public string account_id { get; set; }
        public string submission_date { get; set; }
        public string created_by { get; set; }
        public string created_date { get; set; }
        public string updated_by { get; set; }
        public string updated_date { get; set; }
        #endregion
    }
}
