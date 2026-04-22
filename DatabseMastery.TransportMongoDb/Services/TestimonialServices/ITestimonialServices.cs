using DatabseMastery.TransportMongoDb.Dtos.TestimonialDtos;

namespace DatabseMastery.TransportMongoDb.Services.TestimonialServices
{
    public interface ITestimonialServices
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync();
        Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
        Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id);
        Task DeleteTestimonialAsync(string id);
    }
}
