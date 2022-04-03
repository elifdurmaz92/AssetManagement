using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.DTO
{
    public class ActionStatusDTO
    {
        public int ID { get; set; }
        public int StatusID { get; set; }
        public int StatusActionID { get; set; }
        public string StatusController { get; set; }
        public string StatusActionMetod { get; set; }
        public string ActionText { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
