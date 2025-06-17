using Bankify.CQRS.DataAccess.IRepositories;
using MediatR;

namespace Bankify.CQRS.Application.Commands
{
    // Komut nesnesi: Belirtilen hesaptan para çekmek için kullanılır
    // This command is used to withdraw money from the specified account
    public record WithdrawMoneyCommand(Guid AccountId, decimal Amount) : IRequest;

    // Bu handler, WithdrawMoneyCommand komutunu işler: hesaptan para çeker
    // This handler processes the WithdrawMoneyCommand: withdraws money from the account
    public class WithdrawMoneyHandler : IRequestHandler<WithdrawMoneyCommand>
    {
        private readonly IBankAccountRepository _repo;
        public WithdrawMoneyHandler(IBankAccountRepository repo) => _repo = repo;

        public async Task<Unit> Handle(WithdrawMoneyCommand request, CancellationToken cancellationToken)
        {
            var account = await _repo.GetByIdAsync(request.AccountId);
            if (account == null) throw new Exception("Account not found");
            if (account.Balance < request.Amount) throw new Exception("Insufficient balance");
            account.Balance -= request.Amount;
            await _repo.UpdateAsync(account);
            return Unit.Value;
        }

        Task IRequestHandler<WithdrawMoneyCommand>.Handle(WithdrawMoneyCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}
