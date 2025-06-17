namespace Bankify.CQRS.Database.Entities
{
    public class BankAccount
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string OwnerName { get; set; }
        public decimal Balance { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
