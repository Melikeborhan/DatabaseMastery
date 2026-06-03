using AutoMapper;
using DatabseMastery.TransportMongoDb.Dtos.ShipmentDtos;
using DatabseMastery.TransportMongoDb.Entities;
using DatabseMastery.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace DatabseMastery.TransportMongoDb.Services.ShipmentServices
{
    public class ShipmentService : IShipmentService
    {
        private readonly IMongoCollection<Shipment> _shipmentCollection;
        private readonly IMapper _mapper;



        //bunu hiyerarsık olarak dusunebılırız ılk katmanda connectıonstrıng->database->Table  olarak katmanlı dusunebılırız 
        public ShipmentService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _shipmentCollection = database.GetCollection<Shipment>(_databaseSettings.ShipmentCollectionName);
            _mapper = mapper;
        }

        //create ıslemınde once mapleme yapılır daha sonra ıslem yapılır 
        public async Task CreateShipmentAsync(CreateShipmentDto createShipmentDto)
        {
            var value = _mapper.Map<Shipment>(createShipmentDto);
            await _shipmentCollection.InsertOneAsync(value);

        }

        public async Task DeleteShipmentAsync(string id)
        {
            await _shipmentCollection.DeleteOneAsync(x => x.ShipmentId == id);
        }

        //listeleme işleminde önce işlem yapılır sonra maplenir
        public async Task<List<ResultShipmentDto>> GetAllShipmentAsync()
        {
            var values = await _shipmentCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultShipmentDto>>(values);
        }

        public async Task<GetShipmentByIdDto> GetShipmentByIdAsync(string id)
        {
            var value = await _shipmentCollection.Find(x => x.ShipmentId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetShipmentByIdDto>(value);
        }

        public async Task UpdateShipmentAsync(UpdateShipmentDto updateShipmentDto)
        {
            var values = _mapper.Map<Shipment>(updateShipmentDto);
            await _shipmentCollection.FindOneAndReplaceAsync(x => x.ShipmentId == updateShipmentDto.ShipmentId, values);
        }
        public async Task<GetShipmentByIdDto> GetShipmentByTrackingNumberAsync(string trackingNumber)
        {
            var value = await _shipmentCollection.Find(x => x.TrackingNumber == trackingNumber).FirstOrDefaultAsync();
            return _mapper.Map<GetShipmentByIdDto>(value);
        }

        public async Task<long> GetTotalShipmentCauntAsync()
        {
           return await _shipmentCollection.CountDocumentsAsync(FilterDefinition<Shipment>.Empty);
        }

        public async Task<long> GetDeliveryShipmentCauntAsync()
        {
           var filter = Builders<Shipment>.Filter.Eq(x => x.CurrentStatus, "Teslim Edildi");
            return await _shipmentCollection.CountDocumentsAsync(filter);
        }

        public async Task<int> GetDistinctDestinationCityCauntAsync()
        {
            var cities = await _shipmentCollection.DistinctAsync<string>("DestinationCity", FilterDefinition<Shipment>.Empty);
            return await cities.ToListAsync().ContinueWith(t => t.Result.Count);
        }

        public async Task<long> GetInDistributionShipmentCauntAsync()
        {
            var filter = Builders<Shipment>.Filter.Eq(x => x.CurrentStatus, "Dağıtımda");
            return await _shipmentCollection.CountDocumentsAsync(filter);
        }
    }
}
