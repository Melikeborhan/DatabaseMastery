using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Views.ViewComponents.DefaultComponents
{
    public class _DefaultStatisticComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
