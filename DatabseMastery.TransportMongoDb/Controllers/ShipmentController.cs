using DatabseMastery.TransportMongoDb.Dtos.ShipmentDtos;
using DatabseMastery.TransportMongoDb.Services.ShipmentServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Controllers
{
    public class ShipmentController : Controller
    {
        public readonly IShipmentService _shipmentService;

        //Constructor injection yaparak IShipmentService'ı kullanabilir hale getiriyoruz. Bu sayede ShipmentController, IShipmentService'ın implementasyonunu kullanarak Shipment işlemlerini gerçekleştirebilir.
        //IShipmentService enjekte ediliyor (Dependency Injection)
        //Controller artık servise erişebiliyor
        public ShipmentController(IShipmentService ShipmentService)
        {
            _shipmentService = ShipmentService;
        }

        public async Task<IActionResult> ShipmentList()
        {
            var values = await _shipmentService.GetAllShipmentAsync();
            return View(values);

        }

        [HttpGet]
        public IActionResult CreateShipment()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateShipment(CreateShipmentDto createShipmentDto)
        {
            await _shipmentService.CreateShipmentAsync(createShipmentDto);
            return RedirectToAction("ShipmentList");
        }

        public async Task<IActionResult> DeleteShipment(string id)
        {
            await _shipmentService.DeleteShipmentAsync(id);
            return RedirectToAction("ShipmentList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateShipmentAsync(string id)//güncellenecek değer id ye gore gelecek 
        {
            var values = await _shipmentService.GetShipmentByIdAsync(id);
            return View(values);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateShipment(UpdateShipmentDto updateShipmentDto)
        {
            await _shipmentService.UpdateShipmentAsync(updateShipmentDto);
            return RedirectToAction("ShipmentList");
        }

    }
}
