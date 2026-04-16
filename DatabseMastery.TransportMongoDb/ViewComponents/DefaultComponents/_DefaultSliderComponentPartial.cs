using DatabseMastery.TransportMongoDb.Services.SliderServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Views.ViewComponents.DefaultComponents
{
    public class _DefaultSliderComponentPartial : ViewComponent
    {
        public readonly ISliderService _sliderService;

        //Constructor injection yaparak ISliderService'ı kullanabilir hale getiriyoruz. Bu sayede SliderController, ISliderService'ın implementasyonunu kullanarak slider işlemlerini gerçekleştirebilir.
        //ISliderService enjekte ediliyor (Dependency Injection)
        //Controller artık servise erişebiliyor
        public _DefaultSliderComponentPartial(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _sliderService.GetAllSlidersAsync();
            return View(values);

        }

    }
}

