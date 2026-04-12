using DatabseMastery.TransportMongoDb.Dtos.SliderDtos;

namespace DatabseMastery.TransportMongoDb.Services.SliderServices
{
    public interface ISliderService
    {
        Task<List<ResultSliderDto>> GetSlidersAsync();
        Task CreateSliderAsync(CreateSliderDto createSliderDto);
        Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
        Task<GetSliderByIdDto>GetSliderByIdAsync(string id);
        Task DeleteSliderAsync(string id);
    }
}
