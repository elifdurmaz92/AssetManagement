using AssetManagement.DTO.DTO;
using AssetManagement.DTO.VM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace AssetManagement.BLL.Provider
{
    public class AssetModelProvider
    {
        HttpClient _client;
        BrandProvider _brandpro;
        public AssetModelProvider(HttpClient client,BrandProvider brandpro)
        {
            _client = client;
            _brandpro = brandpro;
        }
        public async Task<IEnumerable<AssetModelDTO>> GetModelByBrand(int assetBrandID, string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var getBrand = await _client.GetAsync("getModelByBrand/" + assetBrandID);
            if (getBrand.IsSuccessStatusCode)
            {
                var read = await getBrand.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<AssetModelDTO>>(read);
                return result;
            }
            return null;
        }

        /// <summary>
        /// Model listesini getirir
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AssetModelVM>> GetModelList(string token = null)
        {
            try
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var getmodel = await _client.GetAsync("assetmodel");

                if (getmodel.IsSuccessStatusCode)
                {
                    var assetBrand = await _brandpro.GetBrand();
                    var modeltrans = await getmodel.Content.ReadAsStringAsync();
                    var assetmodel = JsonConvert.DeserializeObject<IEnumerable<AssetModelDTO>>(modeltrans);


                    var list = (from m in assetmodel
                                join b in assetBrand on m.AssetBrandID equals b.ID
                                select new AssetModelVM()
                                {
                                    ID = m.ID,
                                    Description = m.Description,
                                    IsActive = m.IsActive,
                                    AssetBrand = b.Description
                                }).ToList();

                    return list;

                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> AddModel(AssetModelDTO dto, string token = null)
        {
            //static tabloya çıkarburayı
            dto.CreatedBy = 1;
            dto.CreatedDate = DateTime.Now;
            dto.ModifiedBy = 1;
            dto.ModifiedDate = DateTime.Now;
            dto.IsActive = true;
            var model = new StringContent(JsonConvert.SerializeObject(dto));
            model.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            string veri = "";
            try
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var modelPost = await _client.PostAsync("addassetmodel", model);

                if (modelPost.IsSuccessStatusCode)
                {
                    veri = await modelPost.Content.ReadAsStringAsync();
                }
                veri = "başarılı";
            }
            catch (Exception)
            {

                throw;
            }

            return veri;
        }

        public async Task<AssetModelDTO> GetModelByID(int id, string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var getModel = await _client.GetAsync("getmodelbyid/" + id);

            if (getModel.IsSuccessStatusCode)
            {
                var modelTrans = await getModel.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AssetModelDTO>(modelTrans);
                return result;
            }
            else { }

            return null;
        }
        public async Task<string> UpdateModel(AssetModelDTO dto, string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var modelTrans = new StringContent(JsonConvert.SerializeObject(dto));
            modelTrans.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            string veri = "";
            try
            {
                var updateModel = await _client.PutAsync("updateassetmodel", modelTrans);

                if (updateModel.IsSuccessStatusCode)
                {
                    veri = await updateModel.Content.ReadAsStringAsync();
                }
                veri = "başarılı";
            }
            catch (Exception)
            {

                throw;
            }

            return veri;
        }

        public async Task<string> Delete(int id, string token = null)
        {
            try
            {
                string veri = "";
                var model = await GetModelByID(id);
                //sonra geri al unutma
                //_client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var modelTrans = new StringContent(JsonConvert.SerializeObject(model));
                modelTrans.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var deleteModel = await _client.PutAsync("deleteassetmodel", modelTrans);
                if (deleteModel.IsSuccessStatusCode)
                {
                    veri = "silindi..";
                }
                return veri;
            }
            catch (Exception exc)
            {
                var hata = "hata" + exc;
                throw;
            }
        }
    }
}
