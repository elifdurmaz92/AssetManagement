using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.DTO
{
    public class SystemListsDTO
    {
        public int ID { get; set; }
        public string Project { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string OperationController { get; set; }
        public string OperationAction { get; set; }
        public bool IsActive { get; set; }
    }
}
