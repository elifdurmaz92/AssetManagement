using AssetManagement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Data.Repository.AuthRepo
{
    public interface IAuthRepo
    {
        Task<LoginInfo> Register(LoginInfo user, string password);
        Task<LoginInfo> Login(string username, string password);
        Task<bool> UserExist(string username);
    }
}
