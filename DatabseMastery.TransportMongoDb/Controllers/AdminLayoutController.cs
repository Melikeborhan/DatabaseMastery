using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
