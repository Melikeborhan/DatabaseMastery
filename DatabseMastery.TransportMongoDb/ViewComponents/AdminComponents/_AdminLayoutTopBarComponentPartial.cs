using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.ViewComponents.AdminComponents
{
    public class _AdminLayoutTopBarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
