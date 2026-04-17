using DatabseMastery.TransportMongoDb.Dtos.BrandDtos;
using DatabseMastery.TransportMongoDb.Services.BrandServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Controllers
{
    public class BrandController : Controller
    {
        public readonly IBrandService _brandService;

        //Constructor injection yaparak IBrandService'ı kullanabilir hale getiriyoruz. Bu sayede BrandController, IBrandService'ın implementasyonunu kullanarak Brand işlemlerini gerçekleştirebilir.
        //IBrandService enjekte ediliyor (Dependency Injection)
        //Controller artık servise erişebiliyor
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> BrandList()
        {
            var values = await _brandService.GetAllBrandAsync();
            return View(values);

        }

        [HttpGet]
        public IActionResult CreateBrand()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);
            return RedirectToAction("BrandList");
        }

        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return RedirectToAction("BrandList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateBrandAsync(string id)//güncellenecek değer id ye gore gelecek 
        {
            var values = await _brandService.GetBrandByIdAsync(id);
            return View(values);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _brandService.UpdateBrandAsync(updateBrandDto);
            return RedirectToAction("BrandList");
        }

    }
}
