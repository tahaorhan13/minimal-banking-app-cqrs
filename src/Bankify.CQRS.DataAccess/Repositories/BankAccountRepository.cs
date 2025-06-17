using Bankify.CQRS.DataAccess.IRepositories;
using Bankify.CQRS.Database.Entities;


namespace Bankify.CQRS.DataAccess.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private static readonly List<BankAccount> _accounts = new();

        public Task AddAsync(BankAccount account)
        {
            _accounts.Add(account);
            return Task.CompletedTask;
        }

        public Task<BankAccount> GetByIdAsync(Guid id) =>
            Task.FromResult(_accounts.FirstOrDefault(x => x.Id == id));

        public Task<List<BankAccount>> GetAllAsync() => Task.FromResult(_accounts);

        public Task UpdateAsync(BankAccount account)
        {
            return Task.CompletedTask;
        }
    }
}
