namespace Bankify.CQRS.Models.Requests
{
    public class DepositMoneyRequest
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
