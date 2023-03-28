using Payment.Models;

namespace Payment.Interface
{
    public interface ITransaction
    {

        List<TransactionDetails> GetAllTransactions();
        Task<string> RemoveAsync(string id);
        Task<string> UpdateAsync(string id,TransactionDetails updatedTransaction);
        TransactionDetails GetTransactionById(string id);
        Task<string> CreateAsync(TransactionDetails transaction);
    }

}
