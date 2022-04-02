using AssetManagement.DTO.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.BLL.Provider
{
    public class SystemListsProvider
    {
        private readonly HttpClient _client;
        public SystemListsProvider(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<SystemListsDTO>> GetSystemList(string token=null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var getGroup = await _client.GetAsync("systemlists");
            if (getGroup.IsSuccessStatusCode)
            {
                var read = await getGroup.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<SystemListsDTO>>(read);
                return result;
            }
            return null;
        }
    }
}
