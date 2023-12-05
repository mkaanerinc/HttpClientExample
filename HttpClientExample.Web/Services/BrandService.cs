using HttpClientExample.Web.Models;
using Newtonsoft.Json;
using System.Text;

namespace HttpClientExample.Web.Services
{
    public class BrandService
    {
        Uri baseAddress = new Uri("http://localhost:5131/api");
        private readonly HttpClient _httpClient;

        public BrandService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public ListResponseModel<BrandViewModel> GetAll()
        {
            string url = "/brands/getall";
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + url).Result;
            ListResponseModel<BrandViewModel> brandListResponseModel = new ListResponseModel<BrandViewModel>();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                brandListResponseModel = JsonConvert.DeserializeObject<ListResponseModel<BrandViewModel>>(data);
            }

            return brandListResponseModel;
        }

        public bool Add(BrandViewModel brandViewModel)
        {
            string url = "/brands/add";
            string data = JsonConvert.SerializeObject(brandViewModel);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + url, content).Result;

            return response.IsSuccessStatusCode ? true : false;
        }
    }
}
