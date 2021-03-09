using System;
using System.Collections.Generic;
using System.Linq;

namespace DataParser.Repository.Models
{
    public class file_info
    {
        
        private IUnitOfWork _unitOfWork;
        public file_info()
        {
            this._unitOfWork = _unitOfWork ?? new UnitOfWork();
        }
        #region  properties
        public int id {get; set;}

		public string rre_id { get; set;}

		public string file_name { get; set;}

		public string file_type { get; set;}

		public DateTime? transaction_date { get; set;}

		public int? rec_count { get; set;}

		public int? claim_count { get; set;}

		public string file_status { get; set;}

		public string env { get; set;}
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public DateTime? received_date { get; set; }

        #endregion


        public string Create()
        {
            string result = "true";
            try
            {
                this._unitOfWork.FileinfoRepository.Create(this);
                result = (this._unitOfWork.FileinfoRepository.All().Select(x => x.id)).Max().ToString();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public bool UpdateFileInfo()
        {
            bool result = true;
            file_info file_Info = this._unitOfWork.FileinfoRepository.All().Single(a => a.id == this.id);
            try
            {
                #region 
                // file_Info.rec_count
                file_Info.claim_count = this.claim_count;
                file_Info.rre_id = this.rre_id;
                file_Info.end_date = this.end_date;
                #endregion

                  this._unitOfWork.FileinfoRepository.Update(file_Info);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

    }
}
