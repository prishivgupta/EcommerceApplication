using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Payment.Models
{
    public class TransactionDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public int? OrderId;

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string? PaymentStatus;

        public string? ShipmentAddress;

        public string? PaymentMethod;

    }
}
