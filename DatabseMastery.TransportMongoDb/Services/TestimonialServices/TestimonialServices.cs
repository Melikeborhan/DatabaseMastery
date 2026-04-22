using AutoMapper;
using DatabseMastery.TransportMongoDb.Dtos.TestimonialDtos;
using DatabseMastery.TransportMongoDb.Entities;
using DatabseMastery.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace DatabseMastery.TransportMongoDb.Services.TestimonialServices
{
    public class TestimonialServices : ITestimonialServices
    {

        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        private readonly IMapper _mapper;

        //bunu hiyerarsýk olarak dusunebýlýrýz ýlk katmanda connectýonstrýng->database->Table  olarak katmanlý dusunebýlýrýz 
        public TestimonialServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<Testimonial>(_databaseSettings.TestimonialCollectionName);
            _mapper = mapper;
        }

        //create ýslemýnde once mapleme yapýlýr daha sonra ýslem yapýlýr 
        public async Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(createTestimonialDto);
            await _testimonialCollection.InsertOneAsync(value);

        }

        public async Task DeleteTestimonialAsync(string id)
        {
            await _testimonialCollection.DeleteOneAsync(x => x.TestimonialId == id);
        }


        //listeleme iþleminde önce iþlem yapýlýr sonra maplenir
        public async Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync()
        {
            var values = await _testimonialCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(values);
        }

        public async Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id)
        {
            var value = await _testimonialCollection.Find(x => x.TestimonialId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetTestimonialByIdDto>(value);
        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            var values = _mapper.Map<Testimonial>(updateTestimonialDto);
            await _testimonialCollection.FindOneAndReplaceAsync(x => x.TestimonialId == updateTestimonialDto.TestimonialId, values);
        }
    }
}
