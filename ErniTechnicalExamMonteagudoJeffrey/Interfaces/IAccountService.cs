using ErniTechnicalExamMonteagudoJeffrey.Models;
using ErniTechnicalExamMonteagudoJeffrey.Requests;

namespace ErniTechnicalExamMonteagudoJeffrey.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account> GetAsync(int id);
        Task<Account> AddAsync(CreateAccountRequest request);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, Account account);
        Task<bool> IsValidAccount(int id, string password);
    }
}
