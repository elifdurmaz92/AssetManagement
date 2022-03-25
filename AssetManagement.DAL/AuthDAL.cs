using AssetManagement.Core.Entity;
using AssetManagement.Data.Repository.AuthRepo;
using AssetManagement.DTO.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DAL
{
    public class AuthDAL : IAuthDAL
    {
        IAuthRepo _repo;
        IConfiguration _conf;
        public AuthDAL(IAuthRepo repo, IConfiguration conf)
        {
            _repo = repo;
            _conf = conf;
        }

        public async Task<string> LoginAction(LoginDTO dto)
        {
            var UserFound = await _repo.Login(dto.UserName, dto.Password);
            if (UserFound == null)
            {
                return null;
            }
            else
            {
                var key = Encoding.ASCII.GetBytes(_conf.GetSection("AppSettings:Token").Value);

                var description = new SecurityTokenDescriptor()
                {
                    Expires = DateTime.Now.AddDays(1),
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, UserFound.ID.ToString()),
                        new Claim(ClaimTypes.Name, UserFound.UserName)

                    }),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)

                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(description);
                var tokenValue = tokenHandler.WriteToken(token);
                return tokenValue;
            }
        }

        public async Task<bool> RegisterAction(RegisterDTO dto)
        {
            try
            {
                if (await _repo.UserExist(dto.UserName))
                {
                    return false;
                }
                else
                {
                    var username = new LoginInfo() { UserName = dto.UserName };
                    await _repo.Register(username, dto.Password);
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
