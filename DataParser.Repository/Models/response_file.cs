using System;
using System.Collections.Generic;
using System.Text;

namespace DataParser.Repository.Models
{
     public class response_file
     {
         public int seq_id { get; set; }
         public string error_code { get; set; }
         public string field_name { get; set; }
        public string claim_control_num { get; set; }
        public int? account_id { get; set; }
        public string rre_id { get; set; }
        public string rectype { get; set; } 
        public string description { get; set; } 
        public string tin { get; set; } 
    }


}