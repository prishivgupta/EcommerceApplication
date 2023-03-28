using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Payment.Interface;
using Payment.Models;

namespace Payment.Repository
{
    public class TransactionRepository : ITransaction
    {
        private readonly IMongoCollection<TransactionDetails> _paymentCollection;

        public TransactionRepository(
        IOptions<PaymentDatabaseSettings> PaymentDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                PaymentDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                PaymentDatabaseSettings.Value.DatabaseName);

            _paymentCollection = mongoDatabase.GetCollection<TransactionDetails>(
                PaymentDatabaseSettings.Value.PaymentDatabaseCollectionName);
        }



        public List<TransactionDetails> GetAllTransactions()
        {
            return _paymentCollection.Find(_ => true).ToList();

        }

        public async Task<string> UpdateAsync(string id,TransactionDetails updatedPayment)
        {
            await _paymentCollection.ReplaceOneAsync(x => x.id == id, updatedPayment);
            return "updated";
        }

        public async Task<string> RemoveAsync(string id)
        {
            await _paymentCollection.DeleteOneAsync(x => x.id == id);
            return "deleted";
        }

        public TransactionDetails GetTransactionById(string id)
        {
            return _paymentCollection.Find(x => x.id == id).FirstOrDefault();
        }

        public async Task<string> CreateAsync(TransactionDetails transaction)
        {
            await _paymentCollection.InsertOneAsync(transaction);
            return "added";
        }


    }
}
