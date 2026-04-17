using DatabseMastery.TransportMongoDb.Dtos.OfferDtos;

namespace DatabseMastery.TransportMongoDb.Services.OfferServices
{
    public interface IOfferServise
    {
        Task<List<ResultOfferDto>> GetAllOfferAsync();
        Task CreateOfferAsync(CreateOfferDto createOfferDto);
        Task UpdateOfferAsync(UpdateOfferDto updateOfferDto);
        Task<GetOfferByIdDto> GetOfferByIdAsync(string id);
        Task DeleteOfferAsync(string id);
    }
}
