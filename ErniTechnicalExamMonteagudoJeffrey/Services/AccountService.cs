using AutoMapper;
using ErniTechnicalExamMonteagudoJeffrey.Interfaces;
using ErniTechnicalExamMonteagudoJeffrey.Models;
using ErniTechnicalExamMonteagudoJeffrey.Requests;

namespace ErniTechnicalExamMonteagudoJeffrey.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEncryptionService _encryptionService;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IEncryptionService encryptionService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _encryptionService = encryptionService;
        }

        public async Task<Account> AddAsync(CreateAccountRequest request)
        {
            var newAccount = _mapper.Map<Account>(request);

            newAccount.Password = _encryptionService.Encrypt(newAccount.Password);

            var result = await _unitOfWork.Accounts.AddAsync(newAccount);

            _unitOfWork.Save();

            return result.Entity;
        }

        public async Task<Account> GetAsync(int id)
        {
            return await _unitOfWork.Accounts.GetAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _unitOfWork.Accounts.GetAllAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var accountInDb = await GetAsync(id);

            if (accountInDb is null)
            {
                return false;
            }

            _unitOfWork.Accounts.Delete(accountInDb);
            _unitOfWork.Save();

            return true;
        }

        public async Task<bool> Update(int id, Account account)
        {
            var accountInDb = await GetAsync(id);

            if (accountInDb is null)
            {
                return false;
            }

            _mapper.Map(account, accountInDb);

            _unitOfWork.Accounts.Update(accountInDb);
            _unitOfWork.Save();

            return true;
        }

        public async Task<bool> IsValidAccount(int id, string password)
        {
            var accountInDb = await GetAsync(id);

            if(accountInDb == null)
            {
                return false;
            }

            string acctPassword = _encryptionService.Decrypt(accountInDb.Password);

            return acctPassword.Equals(password);
        }
    }
}
