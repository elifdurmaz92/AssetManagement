using AssetManagement.DTO.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.BLL.Provider
{
    public class AssetProvider
    {
        HttpClient _client;
        public AssetProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> AddNewAsset(AddNewAssetDTO dto)
        {
            #region Login giriş Bilgileri gelecek
            dto.CompanyID = 1;
            dto.PersonnelID = 1;
            dto.StatusID = 1;
            dto.IsActive = true;
            dto.CreatedBy = 1;
            dto.Date = DateTime.Now;
            dto.StatusNote = "Yeni varlık eklendi";
            dto.CreatedDate = DateTime.Now;
            dto.ModifiedDate = DateTime.Now;
            dto.ModifiedBy = 1;
            #endregion

            if (dto.IsBarcode==true)
            {
                dto.Quantity = 0;
                dto.UnitID = 0;
            }

            var asset = new StringContent(JsonConvert.SerializeObject(dto));
            asset.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            string veri = "";
            try
            {
                var result = await _client.PostAsync("addasset", asset);
                if (result.IsSuccessStatusCode)
                {
                    await result.Content.ReadAsStringAsync();
                }
                veri = "Asset tablosuna veri eklendi";
            }
            catch (Exception ex)
            {
                veri = "Hata: " + ex + "";
            }

            return veri;
        }


        public async Task<NewAssetDTO> NewAssetGET(string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var getNewAsset = await _client.GetAsync("asset/newasset");
            if (getNewAsset.IsSuccessStatusCode)
            {
                var read = await getNewAsset.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<NewAssetDTO>(read);
                return result;
            }
            return null;
        }
    }
}
