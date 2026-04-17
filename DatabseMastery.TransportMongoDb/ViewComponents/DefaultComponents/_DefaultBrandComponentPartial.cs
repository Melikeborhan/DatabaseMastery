using DatabseMastery.TransportMongoDb.Services.BrandServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Views.ViewComponents.DefaultComponents
{
    public class _DefaultBrandComponentPartial : ViewComponent
    {
        public readonly IBrandService _brandService;

        //Constructor injection yaparak IBrandService'ı kullanabilir hale getiriyoruz. Bu sayede BrandController, IBrandService'ın implementasyonunu kullanarak Brand işlemlerini gerçekleştirebilir.
        //IBrandService enjekte ediliyor (Dependency Injection)
        //Controller artık servise erişebiliyor
        public _DefaultBrandComponentPartial(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _brandService.GetAllBrandAsync();
            return View(values);

        }
    }
}