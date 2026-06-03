using DatabseMastery.TransportMongoDb.Dtos.ShipmentDtos;

namespace DatabseMastery.TransportMongoDb.Services.ShipmentServices
{
    public interface IShipmentService
    {
        Task<List<ResultShipmentDto>> GetAllShipmentAsync();
        Task CreateShipmentAsync(CreateShipmentDto createShipmentDto);
        Task UpdateShipmentAsync(UpdateShipmentDto updateShipmentDto);
        Task<GetShipmentByIdDto> GetShipmentByIdAsync(string id);
        Task DeleteShipmentAsync(string id);
        Task<GetShipmentByIdDto> GetShipmentByTrackingNumberAsync(string trackingNumber);

        public Task<long> GetTotalShipmentCauntAsync();
        public Task<long> GetDeliveryShipmentCauntAsync();
        public Task<int> GetDistinctDestinationCityCauntAsync();
        public Task<long> GetInDistributionShipmentCauntAsync();
    }
}
