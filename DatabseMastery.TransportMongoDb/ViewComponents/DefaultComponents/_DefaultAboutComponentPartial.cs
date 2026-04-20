using DatabseMastery.TransportMongoDb.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Views.ViewComponents.DefaultComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        public readonly IAboutService _aboutService;

        //Constructor injection yaparak IBrandService'ı kullanabilir hale getiriyoruz. Bu sayede BrandController, IBrandService'ın implementasyonunu kullanarak Brand işlemlerini gerçekleştirebilir.
        //IBrandService enjekte ediliyor (Dependency Injection)
        //Controller artık servise erişebiliyor
        public _DefaultAboutComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);

        }
    }
}
