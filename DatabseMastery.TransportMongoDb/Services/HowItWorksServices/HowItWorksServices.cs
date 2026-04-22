using AutoMapper;
using DatabseMastery.TransportMongoDb.Dtos.HowItWorksDtos;
using DatabseMastery.TransportMongoDb.Entities;
using DatabseMastery.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace DatabseMastery.TransportMongoDb.Services.HowItWorksServices
{
    public class HowItWorksServices : IHowItWorksServices
    {
        private readonly IMongoCollection<HowItWorks> _howItWorksServices;
        private readonly IMapper _mapper;

        public HowItWorksServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _howItWorksServices = database.GetCollection<HowItWorks>(_databaseSettings.HowItWorksCollectionName);
            _mapper = mapper;
        }

        public async Task CreateHowItWorksAsync(CreateHowItWorksDto createHowItWorksDto)
        {
            var value = _mapper.Map<HowItWorks>(createHowItWorksDto);
            await _howItWorksServices.InsertOneAsync(value);
        }

        public async Task DeleteHowItWorksAsync(string id)
        {
            await _howItWorksServices.DeleteOneAsync(x => x.HowItWorksId == id);
        }

        public async Task<List<ResultHowItWorksDto>> GetAllHowItWorksAsync()
        {
            var values = await _howItWorksServices.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultHowItWorksDto>>(values);
        }

        public async Task UpdateHowItWorksDtoAsync(UpdateHowItWorksDto updateHowItWorksDto)
        {
            var values = _mapper.Map<HowItWorks>(updateHowItWorksDto);
            await _howItWorksServices.FindOneAndReplaceAsync(x => x.HowItWorksId == updateHowItWorksDto.HowItWorksId, values);
        }
    }
}
