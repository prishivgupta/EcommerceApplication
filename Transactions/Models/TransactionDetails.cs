using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Payment.Models
{
    public class TransactionDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }

        public int OrderId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string PaymentStatus { get; set; }

        public string ShipmentAddress { get; set; }

        public string PaymentMethod { get; set; }

    }
}
