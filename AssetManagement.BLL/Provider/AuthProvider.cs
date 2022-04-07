using AssetManagement.DTO.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.BLL.Provider
{
    public class AuthProvider
    {
        HttpClient _client;
        public AuthProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetToken(LoginDTO loginDTO)
        {
    
            var login = new StringContent(JsonConvert.SerializeObject(loginDTO));
            login.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            string veri = "";
            try
            {
                var gettoken = await _client.PostAsync("auth/login", login);

                if (gettoken.IsSuccessStatusCode)
                {
                    veri = await gettoken.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return veri;

        }



    }
}
