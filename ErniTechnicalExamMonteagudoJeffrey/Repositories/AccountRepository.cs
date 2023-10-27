using ErniTechnicalExamMonteagudoJeffrey.Interfaces;
using ErniTechnicalExamMonteagudoJeffrey.Models;

namespace ErniTechnicalExamMonteagudoJeffrey.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(AccountDbContext context) : base(context)
        {
        }
    }
}
