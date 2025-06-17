namespace Bankify.CQRS.Models.Requests
{
    public class WithdrawMoneyRequest
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
