using ErniTechnicalExamMonteagudoJeffrey.Interfaces;
using ErniTechnicalExamMonteagudoJeffrey.Requests;
using ErniTechnicalExamMonteagudoJeffrey.Responses;

namespace ErniTechnicalExamMonteagudoJeffrey.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IAccountService _accountService;

        public TransactionService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<BalanceInquiryResponse> BalanceInquiry(BalanceInquiryRequest request)
        {
            if(! await _accountService.IsValidAccount(request.AccountNumber, request.Password))
            {
                throw new Exception("Invalid credentials");
            }

            var account = await _accountService.GetAsync(request.AccountNumber);
            
            return new BalanceInquiryResponse
            {
                AccountNumber = account.Id,
                Balance = account.Balance
            };
        }

        public async Task<DepositResponse> Deposit(TransactionRequest request)
        {
            if (!await _accountService.IsValidAccount(request.AccountNumber, request.Password))
            {
                throw new Exception("Invalid credentials");
            }

            var account = await _accountService.GetAsync(request.AccountNumber);

            account.Balance += request.Amount;

            await _accountService.Update(account.Id, account);

            return new DepositResponse
            {
                AccountNumber = account.Id,
                Balance = account.Balance,
                AmountDeposited = request.Amount
            };
        }

        public async Task<TransferResponse> Transfer(TransferRequest request)
        {
            if (!await _accountService.IsValidAccount(request.AccountNumber, request.Password))
            {
                throw new Exception("Invalid credentials");
            }

            var senderAccount = await _accountService.GetAsync(request.AccountNumber);

            var recieverAccount = await _accountService.GetAsync(request.RecieverAccountNumber);

            if(recieverAccount == null)
            {
                throw new Exception("Recepient's account number does not exist in the database.");
            }

            if(senderAccount.Balance < request.Amount)
            {
                throw new Exception("Not enough balance in your account.");
            }

            senderAccount.Balance -= request.Amount;
            recieverAccount.Balance += request.Amount;

            await _accountService.Update(senderAccount.Id, senderAccount);
            await _accountService.Update(recieverAccount.Id, recieverAccount);

            return new TransferResponse
            {
                AccountNumber = senderAccount.Id,
                AmountTransferred = request.Amount,
                Balance = senderAccount.Balance,
                RecieverAccountNumber = recieverAccount.Id
            };
        }

        public async Task<WithdrawResponse> Withdraw(TransactionRequest request)
        {
            if (!await _accountService.IsValidAccount(request.AccountNumber, request.Password))
            {
                throw new Exception("Invalid credentials");
            }

            var account = await _accountService.GetAsync(request.AccountNumber);

            if(account.Balance < request.Amount)
            {
                throw new Exception("Not enough balance in your account.");
            }

            account.Balance -= request.Amount;

            await _accountService.Update(account.Id, account);

            return new WithdrawResponse
            {
                AccountNumber = account.Id,
                AmountWithdrawn = request.Amount,
                Balance = account.Balance
            };
        }
    }
}
