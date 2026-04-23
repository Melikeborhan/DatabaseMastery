using DatabseMastery.TransportMongoDb.Dtos.QuestionDtos;
using DatabseMastery.TransportMongoDb.Services.QuestionServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Controllers
{
    public class QuestionController : Controller
    {
        public readonly IQuestionService _questionService;

        //Constructor injection yaparak IQuestionService'ı kullanabilir hale getiriyoruz. Bu sayede QuestionController, IQuestionService'ın implementasyonunu kullanarak Question işlemlerini gerçekleştirebilir.
        //IQuestionService enjekte ediliyor (Dependency Injection)
        //Controller artık servise erişebiliyor
        public QuestionController(IQuestionService QuestionService)
        {
            _questionService = QuestionService;
        }

        public async Task<IActionResult> QuestionList()
        {
            var values = await _questionService.GetAllQuestionAsync();
            return View(values);

        }

        [HttpGet]
        public IActionResult CreateQuestion()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestionDto createQuestionDto)
        {
            await _questionService.CreateQuestionAsync(createQuestionDto);
            return RedirectToAction("QuestionList");
        }

        public async Task<IActionResult> DeleteQuestion(string id)
        {
            await _questionService.DeleteQuestionAsync(id);
            return RedirectToAction("QuestionList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateQuestionAsync(string id)//güncellenecek değer id ye gore gelecek 
        {
            var values = await _questionService.GetQuestionByIdAsync(id);
            return View(values);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            await _questionService.UpdateQuestionAsync(updateQuestionDto);
            return RedirectToAction("QuestionList");
        }

    }
}
