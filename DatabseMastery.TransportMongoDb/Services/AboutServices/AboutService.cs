using AutoMapper;
using DatabseMastery.TransportMongoDb.Dtos.AboutDtos;
using DatabseMastery.TransportMongoDb.Entities;
using DatabseMastery.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace DatabseMastery.TransportMongoDb.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;


        //bunu hiyerarsık olarak dusunebılırız ılk katmanda connectıonstrıng->database->Table  olarak katmanlı dusunebılırız 
        public AboutService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        //create ıslemınde once mapleme yapılır daha sonra ıslem yapılır 
        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            await _aboutCollection.InsertOneAsync(value);

        }
        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(x => x.AboutId == id);
        }
        //listeleme işleminde önce işlem yapılır sonra maplenir
        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var values = await _aboutCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }

        public async Task<GetAboutByIdDto> GetAboutByIdAsync(string id)
        {
            var value = await _aboutCollection.Find(x => x.AboutId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetAboutByIdDto>(value);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var values = _mapper.Map<About>(updateAboutDto);
            await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutId == updateAboutDto.AboutId, values);
        }
    }
}
