using DatabseMastery.TransportMongoDb.Dtos.TestimonialDtos;
using DatabseMastery.TransportMongoDb.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Controllers
{
    public class TestimonialController : Controller
    {
        public readonly ITestimonialServices _testimonialService;

        //Constructor injection yaparak IBrandService'ı kullanabilir hale getiriyoruz. Bu sayede BrandController, IBrandService'ın implementasyonunu kullanarak Brand işlemlerini gerçekleştirebilir.
        //IBrandService enjekte ediliyor (Dependency Injection)
        //Controller artık servise erişebiliyor
        public TestimonialController(ITestimonialServices testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var values = await _testimonialService.GetAllTestimonialsAsync();
            return View(values);

        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            await _testimonialService.CreateTestimonialAsync(createTestimonialDto);
            return RedirectToAction("TestimonialList");
        }

        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("TestimonialList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)//güncellenecek değer id ye gore gelecek 
        {
            var values = await _testimonialService.GetTestimonialByIdAsync(id);
            return View(values);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _testimonialService.UpdateTestimonialAsync(updateTestimonialDto);
            return RedirectToAction("TestimonialList");
        }

    }
}
