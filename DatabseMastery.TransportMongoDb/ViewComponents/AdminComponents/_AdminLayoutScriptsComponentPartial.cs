using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.ViewComponents.AdminComponents
{
    public class _AdminLayoutScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
