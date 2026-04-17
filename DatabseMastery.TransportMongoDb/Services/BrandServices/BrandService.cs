using AutoMapper;
using DatabseMastery.TransportMongoDb.Dtos.BrandDtos;
using DatabseMastery.TransportMongoDb.Entities;
using DatabseMastery.TransportMongoDb.Settings;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MongoDB.Driver;

namespace DatabseMastery.TransportMongoDb.Services.BrandServices
{
    public class BrandService : IBrandService
    {
       

            private readonly IMongoCollection<Brand> _brandCollection;
            private readonly IMapper _mapper;



            //bunu hiyerarsık olarak dusunebılırız ılk katmanda connectıonstrıng->database->Table  olarak katmanlı dusunebılırız 
            public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
            {
                var client = new MongoClient(_databaseSettings.ConnectionString);
                var database = client.GetDatabase(_databaseSettings.DatabaseName);
                _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
                _mapper = mapper;
            }

            //create ıslemınde once mapleme yapılır daha sonra ıslem yapılır 
            public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
            {
                var value = _mapper.Map<Brand>(createBrandDto);
                await _brandCollection.InsertOneAsync(value);

            }

            public async Task DeleteBrandAsync(string id)
            {
                await _brandCollection.DeleteOneAsync(x => x.BrandId == id);
            }

            //listeleme işleminde önce işlem yapılır sonra maplenir
            public async Task<List<ResultBrandDto>> GetAllBrandAsync()
            {
                var values = await _brandCollection.Find(x => true).ToListAsync();
                return _mapper.Map<List<ResultBrandDto>>(values);
            }

            public async Task<GetBrandByIdDto> GetBrandByIdAsync(string id)
            {
                var value = await _brandCollection.Find(x => x.BrandId == id).FirstOrDefaultAsync();
                return _mapper.Map<GetBrandByIdDto>(value);
            }

            public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
            {
                var values = _mapper.Map<Brand>(updateBrandDto);
                await _brandCollection.FindOneAndReplaceAsync(x => x.BrandId == updateBrandDto.BrandId, values);
            }
        }
    }
