using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssetManagement.DTO.VM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Kullanıcı adı giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre giriniz")]
        public string Password { get; set; }
    }
}
