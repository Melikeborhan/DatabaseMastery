using DatabseMastery.TransportMongoDb.Services.ShipmentServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Views.ViewComponents.DefaultComponents
{
    public class _DefaultStatisticComponentPartial:ViewComponent
    {
        private readonly IShipmentService _shipmentService;

        public _DefaultStatisticComponentPartial(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.v1 = await _shipmentService.GetTotalShipmentCauntAsync();

            ViewBag.v2 = await _shipmentService.GetDeliveryShipmentCauntAsync();
            ViewBag.v3 = await _shipmentService.GetDistinctDestinationCityCauntAsync();
            ViewBag.v4 = await _shipmentService.GetInDistributionShipmentCauntAsync();
            return View();
        }

    }
}
