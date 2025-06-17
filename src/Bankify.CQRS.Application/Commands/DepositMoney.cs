using Bankify.CQRS.DataAccess.IRepositories;
using MediatR;

namespace Bankify.CQRS.Application.Commands
{
    // Komut nesnesi: Belirtilen hesaba para yatırmak için kullanılır
    // This command is used to deposit money into the specified account
    public record DepositMoneyCommand(Guid AccountId, decimal Amount) : IRequest;

    // Bu handler, DepositMoneyCommand komutunu işler: hesaba para ekler
    // This handler processes the DepositMoneyCommand: adds money to the account
    public class DepositMoneyHandler : IRequestHandler<DepositMoneyCommand>
    {
        private readonly IBankAccountRepository _repo;
        public DepositMoneyHandler(IBankAccountRepository repo) => _repo = repo;

        public async Task<Unit> Handle(DepositMoneyCommand request, CancellationToken cancellationToken)
        {
            var account = await _repo.GetByIdAsync(request.AccountId);
            if (account == null) throw new Exception("Account not found");
            account.Balance += request.Amount;
            await _repo.UpdateAsync(account);
            return Unit.Value;
        }

        Task IRequestHandler<DepositMoneyCommand>.Handle(DepositMoneyCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}
