using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public class SaleEndpoint : ISaleEndpoint
    {
        private IAPIHelper _apiHelper;
        public SaleEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task PostSale(SaleModel sale)
        {
            string serializedSale = JsonConvert.SerializeObject(sale);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(serializedSale);
            ByteArrayContent byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsync("/api/Sale", byteContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    // log successful cal?
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        //public async Task<List<ProductModel>> GetAll()
        //{
        //    using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Product"))
        //    {
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = JsonConvert.DeserializeObject<List<ProductModel>>(
        //                await response.Content.ReadAsStringAsync());

        //            return result;
        //        }
        //        else
        //        {
        //            throw new Exception(response.ReasonPhrase);
        //        }
        //    }
        //}
    }
}
