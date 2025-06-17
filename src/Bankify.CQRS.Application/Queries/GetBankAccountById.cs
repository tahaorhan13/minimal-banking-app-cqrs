using Bankify.CQRS.DataAccess.IRepositories;
using Bankify.CQRS.Database.Entities;
using MediatR;

namespace Bankify.CQRS.Application.Queries
{
    // Sorgu nesnesi: Belirli bir hesabın detaylarını almak için kullanılır
    // This query is used to retrieve the details of a specific bank account
    public record GetBankAccountByIdQuery(Guid AccountId) : IRequest<BankAccount>;

    // Bu handler, GetBankAccountByIdQuery sorgusunu işler: hesabın detaylarını döner
    // This handler processes the GetBankAccountByIdQuery: returns account details
    public class GetBankAccountByIdHandler : IRequestHandler<GetBankAccountByIdQuery, BankAccount>
    {
        private readonly IBankAccountRepository _repo;
        public GetBankAccountByIdHandler(IBankAccountRepository repo) => _repo = repo;

        public async Task<BankAccount> Handle(GetBankAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _repo.GetByIdAsync(request.AccountId);
            if (account == null) throw new Exception("Account not found");
            return account;
        }
    }
}
