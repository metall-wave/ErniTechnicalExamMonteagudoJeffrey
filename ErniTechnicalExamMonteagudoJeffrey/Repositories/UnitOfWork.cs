using ErniTechnicalExamMonteagudoJeffrey.Interfaces;
using ErniTechnicalExamMonteagudoJeffrey.Models;

namespace ErniTechnicalExamMonteagudoJeffrey.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AccountDbContext _context;
        private IAccountRepository _accounts;

        public IAccountRepository Accounts {
            get
            {
                if (_accounts == null)
                {
                    _accounts = new AccountRepository(_context);
                }
                return _accounts;
            }
        }

        public UnitOfWork(AccountDbContext context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
