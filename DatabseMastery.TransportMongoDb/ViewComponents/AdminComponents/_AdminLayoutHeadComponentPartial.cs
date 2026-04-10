using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.ViewComponents.AdminComponents
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
