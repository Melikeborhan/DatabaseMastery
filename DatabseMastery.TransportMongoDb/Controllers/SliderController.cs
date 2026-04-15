using DatabseMastery.TransportMongoDb.Dtos.SliderDtos;
using DatabseMastery.TransportMongoDb.Services.SliderServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Controllers
{
    public class SliderController : Controller
    {
        public readonly ISliderService _sliderService;

        //Constructor injection yaparak ISliderService'ı kullanabilir hale getiriyoruz. Bu sayede SliderController, ISliderService'ın implementasyonunu kullanarak slider işlemlerini gerçekleştirebilir.
        //ISliderService enjekte ediliyor (Dependency Injection)
        //Controller artık servise erişebiliyor
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IActionResult> SliderList()
        {
            var values = await _sliderService.GetAllSlidersAsync();
            return View(values);
           
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            await _sliderService.CreateSliderAsync(createSliderDto);
            return RedirectToAction("SliderList");
        }

        public async Task<IActionResult> DeleteSlider(string id)
        {
            await _sliderService.DeleteSliderAsync(id);
            return RedirectToAction("SliderList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateSliderAsync(string id)//güncellenecek değer id ye gore gelecek 
        {
            var values = await _sliderService.GetSliderByIdAsync(id);
            return View(values);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            await _sliderService.UpdateSliderAsync(updateSliderDto);
            return RedirectToAction("SliderList");
        }


    }
}
