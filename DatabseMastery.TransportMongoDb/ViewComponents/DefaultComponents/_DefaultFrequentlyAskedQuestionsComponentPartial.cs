using DatabseMastery.TransportMongoDb.Services.QuestionServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Views.ViewComponents.DefaultComponents
{
    public class _DefaultFrequentlyAskedQuestionsComponentPartial:ViewComponent
    {
        public readonly IQuestionService _questionService;

        //Constructor injection yaparak IQuestionService'ı kullanabilir hale getiriyoruz. Bu sayede QuestionController, IQuestionService'ın implementasyonunu kullanarak Question işlemlerini gerçekleştirebilir.
        //IQuestionService enjekte ediliyor (Dependency Injection)
        //Controller artık servise erişebiliyor
        public _DefaultFrequentlyAskedQuestionsComponentPartial(IQuestionService QuestionService)
        {
            _questionService = QuestionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _questionService.GetAllQuestionAsync();
            return View(values);

        }
    }
}
