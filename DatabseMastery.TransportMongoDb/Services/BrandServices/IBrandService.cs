using DatabseMastery.TransportMongoDb.Dtos.BrandDtos;

namespace DatabseMastery.TransportMongoDb.Services.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllSlidersAsync();
        Task CreateBrandAsync(CreateBrandDto createSliderDto);
        Task UpdateSliderAsync(UpdateBrandDto updateSliderDto);
        Task<GetBrandByIdDto> GetSliderByIdAsync(string id);
        Task DeleteBrandAsync(string id);
    }
}
