using DatabseMastery.TransportMongoDb.Services.HowItWorksServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Views.ViewComponents.DefaultComponents
{
    public class _DefaultHowItWorksComponentPartial :ViewComponent
    {
        public readonly IHowItWorksServices _howItWorksService;

        //Constructor injection yaparak IHowItWorksService'ý kullanabilir hale getiriyoruz. Bu sayede HowItWorksController, IHowItWorksService'ýn implementasyonunu kullanarak HowItWorks iþlemlerini gerçekleþtirebilir.
        //IHowItWorksService enjekte ediliyor (Dependency Injection)
        //Controller artýk servise eriþebiliyor
        public _DefaultHowItWorksComponentPartial(IHowItWorksServices HowItWorksService)
        {
            _howItWorksService = HowItWorksService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _howItWorksService.GetAllHowItWorksAsync();
            return View(values);

        }
    }
}
