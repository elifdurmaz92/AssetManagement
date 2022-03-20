using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Core.Entity
{
    public class LoginInfo:IEntity
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

    }
}
