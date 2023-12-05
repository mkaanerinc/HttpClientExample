using HttpClientExample.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HttpClientExample.Web.Controllers
{
    public class BrandsController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5131/api");
        private readonly HttpClient _httpClient;

        public BrandsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/brands/getall").Result;
            BrandListResponseModel brandListResponseModel = new BrandListResponseModel(); 

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                brandListResponseModel = JsonConvert.DeserializeObject<BrandListResponseModel>(data);
            }

            return View(brandListResponseModel.Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BrandViewModel brandViewModel)
        {
            try
            {
                string data = JsonConvert.SerializeObject(brandViewModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/brands/add", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Brands");
                }
            }
            catch (Exception)
            {
                return View();
            }
            return View();
        }
    }
}
