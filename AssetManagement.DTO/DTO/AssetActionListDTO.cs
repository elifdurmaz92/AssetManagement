using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.DTO
{
    public class AssetActionListDTO
    {
        public int StatusID { get; set; }
        public DateTime EntryDate { get; set; } = DateTime.Now.Date;
        public string RegisteringRerson { get; set; }
        public string Status { get; set; }
        public string LastStatus { get; set; }
        public DateTime LastOperationDate { get; set; }= DateTime.Now.Date;
        public string ActionPersonnel { get; set; }
        public string ActionTeam { get; set; }
        public string ActionCustomer { get; set; }
        public string Note { get; set; }
    }
}
