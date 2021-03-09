using System;
using System.Collections.Generic;
using System.Text;

namespace DataParser.Repository.Models
{

   
    public class rre_info
    {
        private IUnitOfWork _unitOfWork;
        public rre_info()
        {
            this._unitOfWork = _unitOfWork ?? new UnitOfWork();
        }


        #region Properties
        public string rre_id { get; set; }
        public string rre_name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip_code { get; set; }
        public string zip_ext { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public int? reporting_period { get; set; }
        public string authorized_rep_name { get; set; }
        public string authorized_rep_email { get; set; }
        public string authorized_rep_phone { get; set; }
        public string account_manager_name { get; set; }
        public string account_manager_email { get; set; }
        public string account_manager_phone { get; set; }
        public int? account_id { get; set; }
        public string edi_rep_name { get; set; }
        public string edi_rep_email { get; set; }
        public string edi_rep_phone { get; set; }
        public string reporting_agent { get; set; }
        public char ins_type { get; set; }
        public string line_of_business { get; set; }
        public byte? rre_status { get; set; }
        public int? created_by { get; set; }
        public DateTime? created_date { get; set; }
        public int? updated_by { get; set; }
        public DateTime? updated_date { get; set; }
        public string plan_tin { get; set; }
        #endregion


        public bool RREExists(string RREid)
        {
            bool result = true;
            try
            {
                result = this._unitOfWork.RREinfoRepository.Contains(x=>x.rre_id==RREid);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
  
}
