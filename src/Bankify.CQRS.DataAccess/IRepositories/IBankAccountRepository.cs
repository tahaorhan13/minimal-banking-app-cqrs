using Bankify.CQRS.Database.Entities;

namespace Bankify.CQRS.DataAccess.IRepositories
{
    public interface IBankAccountRepository
    {
        Task AddAsync(BankAccount account);
        Task<BankAccount> GetByIdAsync(Guid id);
        Task<List<BankAccount>> GetAllAsync();
        Task UpdateAsync(BankAccount account);
    }
}
