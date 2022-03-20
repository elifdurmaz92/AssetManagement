using AssetManagement.Core.Context;
using AssetManagement.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Data.Repository.AuthRepo
{
    public class AuthRepo : IAuthRepo
    {
        AssetManagementContext _context;
        public AuthRepo(AssetManagementContext context)
        {
            _context = context;

        }
        public async Task<LoginInfo> Login(string username, string password)
        {
            var user = await _context.LoginInfo.FirstOrDefaultAsync(a => a.UserName == username);

            if (user == null)
            {
                return null;
            }
            if (!UserControl(password, user.PasswordSalt, user.PasswordHash))
            {
                return null;
            }

            return user;

        }
        private bool UserControl(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < password.Length; i++)
                {
                    if (passHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }

        }

        public async Task<LoginInfo> Register(LoginInfo user, string password)
        {
            byte[] passHash, passSalt;
            UserPasswordSave(password, out passHash, out passSalt);
            user.PasswordSalt = passSalt;
            user.PasswordHash = passHash;
            await _context.LoginInfo.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        private void UserPasswordSave(string password, out byte[] passHash, out byte[] passSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                passSalt = hmac.Key;
            }
        }

        public async Task<bool> UserExist(string username)
        {
            if (!await _context.LoginInfo.AnyAsync(a => a.UserName == username))
            {
                return false;
            }
            return true;
        }
    }
}
