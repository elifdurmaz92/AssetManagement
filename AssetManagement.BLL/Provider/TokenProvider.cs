using AssetManagement.DTO.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.BLL.Provider
{
    public class TokenProvider
    {
        HttpClient _client;
        public TokenProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetToken(string userName, string password)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(new LoginDTO()
            {
                Password = password,
                UserName = userName
            }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var value = await _client.PostAsync("auth/login", content);
            string token = "";
            if (value.IsSuccessStatusCode)
            {
                token = value.Content.ReadAsStringAsync().Result;
            }
            else
            {
                token = "";
            }
            return token;
        }
    }
}
