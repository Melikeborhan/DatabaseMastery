using DatabseMastery.TransportMongoDb.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Views.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialComponentPartial:ViewComponent
    {
        public readonly ITestimonialServices _testimonialService;

        //Constructor injection yaparak IBrandService'ý kullanabilir hale getiriyoruz. Bu sayede BrandController, IBrandService'ýn implementasyonunu kullanarak Brand iþlemlerini gerçekleþtirebilir.
        //IBrandService enjekte ediliyor (Dependency Injection)
        //Controller artýk servise eriþebiliyor
        public _DefaultTestimonialComponentPartial(ITestimonialServices testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _testimonialService.GetAllTestimonialsAsync();
            return View(values);

        }
    }
}
