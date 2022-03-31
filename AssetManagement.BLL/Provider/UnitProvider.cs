using AssetManagement.DTO.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.BLL.Provider
{
    public class UnitProvider
    {

        HttpClient _client;
        public UnitProvider(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<UnitDTO>> GetUnit(string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var getUnit = await _client.GetAsync("unit");

            if (getUnit.IsSuccessStatusCode)
            {
                var read = await getUnit.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<UnitDTO>>(read);
                return result;

            }
            return null;
        }
    }
}
