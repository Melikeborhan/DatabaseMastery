using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Views.ViewComponents.DefaultComponents
{
    public class _DefaultFrequentlyAskedQuestionsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View();
        }
    }
}
