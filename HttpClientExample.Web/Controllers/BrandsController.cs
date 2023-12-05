using HttpClientExample.Web.Models;
using HttpClientExample.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HttpClientExample.Web.Controllers
{
    public class BrandsController : Controller
    {

        private readonly BrandService _brandService;

        public BrandsController(BrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _brandService.GetAll();

            return View(result.Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BrandViewModel brandViewModel)
        {
            var result = _brandService.Add(brandViewModel);

            if (result)
            {
                return RedirectToAction("Index", "Brands");
            }
            
            return View();

        }
    }
}
