using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DatabseMastery.TransportMongoDb.Entities
{
    public class HowItWorks
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string HowItWorksId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public bool Status { get; set; }

    }
}
