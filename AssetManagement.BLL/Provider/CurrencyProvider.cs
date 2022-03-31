using AssetManagement.DTO.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.BLL.Provider
{
    public class CurrencyProvider
    {
        HttpClient _client;
        public CurrencyProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<CurrencyDTO>> GetCurrency(string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var getCurrency = await _client.GetAsync("currency");

            if (getCurrency.IsSuccessStatusCode)
            {
                var read = await getCurrency.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<CurrencyDTO>>(read);
                return result;

            }
            return null;
        }
    }
}
