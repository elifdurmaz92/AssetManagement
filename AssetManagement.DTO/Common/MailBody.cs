using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.Common
{
    public class MailBody
    {
        public string Message { get; set; }
        public List<string> MailList { get; set; }
    }
}
