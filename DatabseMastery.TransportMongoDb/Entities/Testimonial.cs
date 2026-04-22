using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DatabseMastery.TransportMongoDb.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialId { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Imageurl { get; set; }
        public string RewiewDetail { get; set; }
        public int RewiewScore { get; set; }
        public bool Status { get; set; }
    }
}
