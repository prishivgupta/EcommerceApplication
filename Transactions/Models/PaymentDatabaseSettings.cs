namespace Payment.Models
{
    public class PaymentDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PaymentDatabaseCollectionName { get;  set; }=null!;
    }
}
