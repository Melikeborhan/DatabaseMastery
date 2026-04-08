using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Views.ViewComponents.DefaultComponents
{
    public class _DefaultBrandComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}