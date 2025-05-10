using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class OfferDiscount
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string OfferDiscountID { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string ImageURL { get; set; }

        public string ButtonTitle { get; set; }
    }
}
