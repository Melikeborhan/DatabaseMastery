using AutoMapper;
using DatabseMastery.TransportMongoDb.Dtos.OfferDtos;
using DatabseMastery.TransportMongoDb.Entities;
using DatabseMastery.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace DatabseMastery.TransportMongoDb.Services.OfferServices
{
    public class OfferService : IOfferService
    {
        private readonly IMongoCollection<Offer> _offerCollection;
        private readonly IMapper _mapper;



        //bunu hiyerarsık olarak dusunebılırız ılk katmanda connectıonstrıng->database->Table  olarak katmanlı dusunebılırız 
        public OfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _offerCollection = database.GetCollection<Offer>(_databaseSettings.OfferCollectionName);
            _mapper = mapper;
        }

        //create ıslemınde once mapleme yapılır daha sonra ıslem yapılır 
        public async Task CreateOfferAsync(CreateOfferDto createOfferDto)
        {
            var value = _mapper.Map<Offer>(createOfferDto);
            await _offerCollection.InsertOneAsync(value);

        }

        public async Task DeleteOfferAsync(string id)
        {
            await _offerCollection.DeleteOneAsync(x => x.OfferId == id);
        }

        //listeleme işleminde önce işlem yapılır sonra maplenir
        public async Task<List<ResultOfferDto>> GetAllOfferAsync()
        {
            var values = await _offerCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDto>>(values);
        }

        public async Task<GetOfferByIdDto> GetOfferByIdAsync(string id)
        {
            var value = await _offerCollection.Find(x => x.OfferId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetOfferByIdDto>(value);
        }

        public async Task UpdateOfferAsync(UpdateOfferDto updateOfferDto)
        {
            var values = _mapper.Map<Offer>(updateOfferDto);
            await _offerCollection.FindOneAndReplaceAsync(x => x.OfferId == updateOfferDto.OfferId, values);
        }
    }

}