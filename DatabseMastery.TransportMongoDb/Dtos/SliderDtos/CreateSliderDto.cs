using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DatabseMastery.TransportMongoDb.Dtos.SliderDtos
{
    public class CreateSliderDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }



    }
}
