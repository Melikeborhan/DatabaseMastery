using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Controllers
{
    public class SliderController : Controller
    {
        public IActionResult SliderList()
        {
            return View();
        }
    }
}
