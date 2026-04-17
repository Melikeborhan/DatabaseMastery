using DatabseMastery.TransportMongoDb.Dtos.OfferDtos;
using DatabseMastery.TransportMongoDb.Services.OfferServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Controllers
{
    public class OfferController : Controller
    {
        public readonly IOfferService _offerService;

        //Constructor injection yaparak IOfferService'ı kullanabilir hale getiriyoruz. Bu sayede OfferController, IOfferService'ın implementasyonunu kullanarak Offer işlemlerini gerçekleştirebilir.
        //IOfferService enjekte ediliyor (Dependency Injection)
        //Controller artık servise erişebiliyor
        public OfferController(IOfferService OfferService)
        {
            _offerService = OfferService;
        }

        public async Task<IActionResult> OfferList()
        {
            var values = await _offerService.GetAllOfferAsync();
            return View(values);

        }

        [HttpGet]
        public IActionResult CreateOffer()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffer(CreateOfferDto createOfferDto)
        {
            await _offerService.CreateOfferAsync(createOfferDto);
            return RedirectToAction("OfferList");
        }

        public async Task<IActionResult> DeleteOffer(string id)
        {
            await _offerService.DeleteOfferAsync(id);
            return RedirectToAction("OfferList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateOfferAsync(string id)//güncellenecek değer id ye gore gelecek 
        {
            var values = await _offerService.GetOfferByIdAsync(id);
            return View(values);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateOffer(UpdateOfferDto updateOfferDto)
        {
            await _offerService.UpdateOfferAsync(updateOfferDto);
            return RedirectToAction("OfferList");
        }

    }
}
