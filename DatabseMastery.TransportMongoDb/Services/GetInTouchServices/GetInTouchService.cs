using AutoMapper;
using DatabseMastery.TransportMongoDb.Dtos.BrandDtos;
using DatabseMastery.TransportMongoDb.Dtos.GetInTouchDtos;
using DatabseMastery.TransportMongoDb.Entities;
using DatabseMastery.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace DatabseMastery.TransportMongoDb.Services.GetInTouchServices
{
    public class GetInTouchService : IGetInTouchService
    {

        private readonly IMongoCollection<GetInTouchSection> _getInTouchCollection;
        private readonly IMapper _mapper;



        //bunu hiyerarsık olarak dusunebılırız ılk katmanda connectıonstrıng->database->Table  olarak katmanlı dusunebılırız 
        public GetInTouchService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _getInTouchCollection = database.GetCollection<GetInTouchSection>(_databaseSettings.GetInTouchCollectionName);
            _mapper = mapper;
        }

        //create ıslemınde once mapleme yapılır daha sonra ıslem yapılır 
        public async Task CreateGetInTouchAsync(CreateGetInTouchDto createGetInTouchDto)
        {
            var value = _mapper.Map<GetInTouchSection>(createGetInTouchDto);
            await _getInTouchCollection.InsertOneAsync(value);

        }

        public async Task DeleteGetInTouchAsync(string id)
        {
            await _getInTouchCollection.DeleteOneAsync(x => x.GetTouchSectionId == id);
        }

        //listeleme işleminde önce işlem yapılır sonra maplenir
        public async Task<List<ResultGetInTouchDto>> GetAllGetInTouchAsync()
        {
            var values = await _getInTouchCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultGetInTouchDto>>(values);
        }

        public async Task<GetGetInTouchByIdDto> GetGetInTouchByIdAsync(string id)
        {
            var value = await _getInTouchCollection.Find(x => x.GetTouchSectionId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetGetInTouchByIdDto>(value);
        }

        public async Task UpdateGetInTouchAsync(UpdateGetInTouchDto updateGetInTouchDto)
        {
            var values = _mapper.Map<GetInTouchSection>(updateGetInTouchDto);
            await _getInTouchCollection.FindOneAndReplaceAsync(x => x.GetTouchSectionId == updateGetInTouchDto.GetTouchSectionId, values);
        }
    }
}
