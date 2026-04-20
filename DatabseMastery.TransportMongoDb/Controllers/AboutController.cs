using DatabseMastery.TransportMongoDb.Dtos.AboutDtos;
using DatabseMastery.TransportMongoDb.Services.AboutServices;

using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Controllers
{
    public class AboutController : Controller
    {
        public readonly IAboutService _aboutService;

        //Constructor injection yaparak IBrandService'ı kullanabilir hale getiriyoruz. Bu sayede BrandController, IBrandService'ın implementasyonunu kullanarak Brand işlemlerini gerçekleştirebilir.
        //IBrandService enjekte ediliyor (Dependency Injection)
        //Controller artık servise erişebiliyor
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> AboutList()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);

        }

        [HttpGet]
        public IActionResult CreateAbout()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("AboutList");
        }

        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("AboutList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)//güncellenecek değer id ye gore gelecek 
        {
            var values = await _aboutService.GetAboutByIdAsync(id);
            return View(values);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("AboutList");
        }

    }
}
