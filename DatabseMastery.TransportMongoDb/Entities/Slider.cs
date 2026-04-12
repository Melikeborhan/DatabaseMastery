using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DatabseMastery.TransportMongoDb.Entities
{
    public class Slider
    {
        [BsonId]//primary key özelliği taşır MongoDB'de her belge (document) benzersiz bir kimliğe sahip olmalıdır. [BsonId] özniteliği, bu özelliğin MongoDB'deki belge kimliği olduğunu belirtir.
        [BsonRepresentation(BsonType.ObjectId)]//iki dünya arasındaki çevirmen gibidir.MongoDB'deki belge kimliği genellikle ObjectId türünde olur. [BsonRepresentation(BsonType.ObjectId)] özniteliği, bu özelliğin MongoDB'deki ObjectId türünde temsil edileceğini belirtir. Bu sayede, C# tarafında string olarak tanımlanan SliderId özelliği, MongoDB'de ObjectId olarak saklanır ve gerektiğinde otomatik olarak dönüştürülür.
        public string SliderId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }


    }
}
