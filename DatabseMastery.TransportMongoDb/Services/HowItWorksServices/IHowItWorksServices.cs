using DatabseMastery.TransportMongoDb.Dtos.HowItWorksDtos;

namespace DatabseMastery.TransportMongoDb.Services.HowItWorksServices
{
    public interface IHowItWorksServices
    {
        Task<List<ResultHowItWorksDto>> GetAllHowItWorksAsync();
        Task CreateHowItWorksAsync(CreateHowItWorksDto createHowItWorksDto);
        Task UpdateHowItWorksAsync(UpdateHowItWorksDto updateHowItWorksDto);
        Task<GetHowItWorksByIdDto> GetHowItWorksByIdDtoAsync(string id);
        Task DeleteHowItWorksAsync(string id);
    }
}
