using DatabseMastery.TransportMongoDb.Dtos.GetInTouchDtos;
using DatabseMastery.TransportMongoDb.Services.GetInTouchServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Controllers
{
    public class GetInTouchController : Controller
    {
        public readonly IGetInTouchService _getInTouchService;

        //Constructor injection yaparak IGetInTouchService'ı kullanabilir hale getiriyoruz. Bu sayede GetInTouchController, IGetInTouchService'ın implementasyonunu kullanarak GetInTouch işlemlerini gerçekleştirebilir.
        //IGetInTouchService enjekte ediliyor (Dependency Injection)
        //Controller artık servise erişebiliyor
        public GetInTouchController(IGetInTouchService getInTouchService)
        {
            _getInTouchService = getInTouchService;
        }

        public async Task<IActionResult> GetInTouchList()
        {
            var values = await _getInTouchService.GetAllGetInTouchAsync();
            return View(values);

        }

        [HttpGet]
        public IActionResult CreateGetInTouch()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGetInTouch(CreateGetInTouchDto createGetInTouchDto)
        {
            await _getInTouchService.CreateGetInTouchAsync(createGetInTouchDto);
            return RedirectToAction("GetInTouchList");
        }

        public async Task<IActionResult> DeleteGetInTouch(string id)
        {
            await _getInTouchService.DeleteGetInTouchAsync(id);
            return RedirectToAction("GetInTouchList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateGetInTouchAsync(string id)//güncellenecek değer id ye gore gelecek 
        {
            var values = await _getInTouchService.GetGetInTouchByIdAsync(id);
            return View(values);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateGetInTouch(UpdateGetInTouchDto updateGetInTouchDto)
        {
            await _getInTouchService.UpdateGetInTouchAsync(updateGetInTouchDto);
            return RedirectToAction("GetInTouchList");
        }
    }
}
