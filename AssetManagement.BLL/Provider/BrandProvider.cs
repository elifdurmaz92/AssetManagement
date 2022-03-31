using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Linq;
using AssetManagement.DTO.VM;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AssetManagement.DTO.DTO;

namespace AssetManagement.BLL.Provider
{
    public class BrandProvider
    {
        HttpClient _client;
        AssetTypeProvider _assetTypepro;
        public BrandProvider(HttpClient client, AssetTypeProvider assetTypepro)
        {
            _client = client;
            _assetTypepro = assetTypepro;
        }

        /// <summary>
        /// Asset type göre markaları getir
        /// </summary>
        /// <param name="assetTypeID"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AssetBrandDTO>> GetBrandByType(int assetTypeID, string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var getBrand = await _client.GetAsync("getBrandByAssetType/" + assetTypeID);
            if (getBrand.IsSuccessStatusCode)
            {
                var read = await getBrand.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<AssetBrandDTO>>(read);
                return result;
            }
            return null;
        }

        /// <summary>
        /// Marka listesini getirir
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AssetBrandVM>> GetBrandList(string token = null)
        {
            try
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var getbrand = await _client.GetAsync("assetbrand");

                if (getbrand.IsSuccessStatusCode)
                {
                    var assetType = await _assetTypepro.GetAssetType();
                    var brandtrans = await getbrand.Content.ReadAsStringAsync();
                    var brand = JsonConvert.DeserializeObject<IEnumerable<AssetBrandDTO>>(brandtrans);


                    var list = (from b in brand
                                join at in assetType on b.AssetTypeID equals at.ID
                                select new AssetBrandVM()
                                {
                                    ID = b.ID,
                                    Description = b.Description,
                                    IsActive = b.IsActive,
                                    AssetType = at.Description
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

        public async Task<string> AddBrand(AssetBrandDTO dto)
        {
            dto.CreatedBy = 1;
            dto.CreatedDate = DateTime.Now;
            dto.ModifiedBy = 1;
            dto.ModifiedDate = DateTime.Now;
            dto.IsActive = true;
            var brand = new StringContent(JsonConvert.SerializeObject(dto));
            brand.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            string veri = "";
            try
            {
                var brandPost = await _client.PostAsync("addassetbrand", brand);

                if (brandPost.IsSuccessStatusCode)
                {
                    veri = await brandPost.Content.ReadAsStringAsync();
                }
                veri = "başarılı";
            }
            catch (Exception)
            {

                throw;
            }

            return veri;
        }



        public async Task<AssetBrandDTO> GetBrandByID(int id,string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var getBrand = await _client.GetAsync("getbrandbyid/" + id);

            if (getBrand.IsSuccessStatusCode)
            {
                var brandTrans = await getBrand.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AssetBrandDTO>(brandTrans);
                return result;
            }
            else { }

            return null;
        }


        public async Task<string> Delete(int id, string token = null)
        {
            try
            {
                string veri = "";
                var brand = await GetBrandByID(id);
                //sonra geri al unutma
                //_client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var brandTrans = new StringContent(JsonConvert.SerializeObject(brand));
                brandTrans.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var deleteBrand = await _client.PutAsync("deleteassetbrand", brandTrans);
                if (deleteBrand.IsSuccessStatusCode)
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

        //public async Task<string> Update(AssetBrandDTO dto)
        //{
        //    var deger = new StringContent(JsonConvert.SerializeObject(dto));
        //    deger.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //    string veri = "";
        //    try
        //    {
        //        var donenPostDegeri = await _client.PutAsync("assetbrand/update", deger);

        //        if (donenPostDegeri.IsSuccessStatusCode)
        //        {
        //            veri = await donenPostDegeri.Content.ReadAsStringAsync();
        //        }
        //        veri = "başarılı";
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return veri;
        //}


    }
}
