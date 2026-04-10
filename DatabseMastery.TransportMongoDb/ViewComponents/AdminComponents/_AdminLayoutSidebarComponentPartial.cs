using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.ViewComponents.AdminComponents
{
    public class _AdminLayoutSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
