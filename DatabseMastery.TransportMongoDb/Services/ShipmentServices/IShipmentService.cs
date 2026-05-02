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
    }
}
