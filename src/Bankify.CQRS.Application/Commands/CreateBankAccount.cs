using Bankify.CQRS.DataAccess.IRepositories;
using Bankify.CQRS.Database.Entities;
using MediatR;

namespace Bankify.CQRS.Application.Commands
{
    // Komut nesnesi: Kullanıcıdan gelen OwnerName bilgisini içeriyor
    // This command contains the OwnerName from the request to create a new account
    public record CreateBankAccountCommand(string OwnerName) : IRequest<Guid>;
    // Bu handler, CreateBankAccountCommand işini yapar: yeni hesap oluşturur ve ID döner
    // This handler processes CreateBankAccountCommand: creates a new account and returns its ID
    public class CreateBankAccountHandler : IRequestHandler<CreateBankAccountCommand, Guid>
    {
        private readonly IBankAccountRepository _repo;
        public CreateBankAccountHandler(IBankAccountRepository repo) => _repo = repo;

        public async Task<Guid> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = new BankAccount { OwnerName = request.OwnerName };
            await _repo.AddAsync(entity);
            return entity.Id;
        }
    }
}
