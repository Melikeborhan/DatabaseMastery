using DatabseMastery.TransportMongoDb.Services.OfferServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Views.ViewComponents.DefaultComponents
{
    public class _DefaultOfferComponentPartial: ViewComponent
    {
        public readonly IOfferService _offerService;

        //Constructor injection yaparak IOfferService'ı kullanabilir hale getiriyoruz. Bu sayede OfferController, IOfferService'ın implementasyonunu kullanarak Offer işlemlerini gerçekleştirebilir.
        //IOfferService enjekte ediliyor (Dependency Injection)
        //Controller artık servise erişebiliyor
        public _DefaultOfferComponentPartial(IOfferService OfferService)
        {
            _offerService = OfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _offerService.GetAllOfferAsync();
            return View(values);

        }
    }
}
