using DatabseMastery.TransportMongoDb.Dtos.HowItWorksDtos;
using DatabseMastery.TransportMongoDb.Services.HowItWorksServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Controllers
{
    public class HowItWorksController : Controller
    {
        public readonly IHowItWorksServices _howItWorksService;

        //Constructor injection yaparak IHowItWorksService'ı kullanabilir hale getiriyoruz. Bu sayede HowItWorksController, IHowItWorksService'ın implementasyonunu kullanarak HowItWorks işlemlerini gerçekleştirebilir.
        //IHowItWorksService enjekte ediliyor (Dependency Injection)
        //Controller artık servise erişebiliyor
        public HowItWorksController(IHowItWorksServices HowItWorksService)
        {
            _howItWorksService = HowItWorksService;
        }

        public async Task<IActionResult> HowItWorksList()
        {
            var values = await _howItWorksService.GetAllHowItWorksAsync();
            return View(values);

        }

        [HttpGet]
        public IActionResult CreateHowItWorks()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHowItWorks(CreateHowItWorksDto createHowItWorksDto)
        {
            await _howItWorksService.CreateHowItWorksAsync(createHowItWorksDto);
            return RedirectToAction("HowItWorksList");
        }

        public async Task<IActionResult> DeleteHowItWorks(string id)
        {
            await _howItWorksService.DeleteHowItWorksAsync(id);
            return RedirectToAction("HowItWorksList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateHowItWorksAsync(string id)//güncellenecek değer id ye gore gelecek 
        {
            var values = await _howItWorksService.GetHowItWorksByIdDtoAsync(id);
            return View(values);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateHowItWorks(UpdateHowItWorksDto updateHowItWorksDto)
        {
            await _howItWorksService.UpdateHowItWorksAsync(updateHowItWorksDto);
            return RedirectToAction("HowItWorksList");
        }
    }
}
