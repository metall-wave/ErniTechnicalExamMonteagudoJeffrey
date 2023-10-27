using ErniTechnicalExamMonteagudoJeffrey.Requests;
using ErniTechnicalExamMonteagudoJeffrey.Responses;

namespace ErniTechnicalExamMonteagudoJeffrey.Interfaces
{
    public interface ITransactionService
    {
        Task<BalanceInquiryResponse> BalanceInquiry(BalanceInquiryRequest request);
        Task<WithdrawResponse> Withdraw(TransactionRequest request);
        Task<DepositResponse> Deposit(TransactionRequest request);
        Task<TransferResponse> Transfer(TransferRequest request);
    }
}
