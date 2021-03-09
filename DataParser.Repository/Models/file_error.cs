using System;
using System.Collections.Generic;
using System.Text;

namespace DataParser.Repository.Models
{
    public class file_error
    {
        private IUnitOfWork _unitOfWork;
        public file_error()
        {
            this._unitOfWork = _unitOfWork ?? new UnitOfWork();
        }

        #region Properties
       public int id { get; set; }
        public int? file_id { get; set; }
        public string error_code { get; set; }
        public string field_name { get; set; }
        public string value { get; set; }
        public int? seq_id { get; set; }
        public string claim_control_number { get; set; }
        public string account_id { get; set; }
        public string rre_info_id { get; set; }
        public DateTime? error_date { get; set; }
        public int? created_by { get; set; }
        public DateTime? created_date { get; set; }
        public int? updated_by { get; set; }
        public DateTime? updated_date { get; set; }


        #endregion

        public string Create()
        {
            string result = "true";
            try
            {
                this._unitOfWork.FileerrorRepository.Create(this);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}
