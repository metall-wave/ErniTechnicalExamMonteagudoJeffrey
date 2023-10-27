using ErniTechnicalExamMonteagudoJeffrey.Interfaces;
using ErniTechnicalExamMonteagudoJeffrey.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErniTechnicalExamMonteagudoJeffrey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// Validates the user, then returns their remaining balance.
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns></returns>
        [HttpPost("BalanceInquiry")]
        public async Task<IActionResult> BalanceInquiry([FromBody] BalanceInquiryRequest request)
        {
            try
            {
                var result = await _transactionService.BalanceInquiry(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        /// <summary>
        /// Validates the user, then deducts their remaining balance by the specified amount.
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns></returns>
        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] TransactionRequest request)
        {
            try
            {
                var result = await _transactionService.Withdraw(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        /// <summary>
        /// Validates the user, then increases their balance by the specified amount.
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns></returns>
        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit([FromBody] TransactionRequest request)
        {
            try
            {
                var result = await _transactionService.Deposit(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }


        /// <summary>
        /// Validates the user, then transfers a specified amount from their balance to another user's account.
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns></returns>
        [HttpPost("Transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferRequest request)
        {
            try
            {
                var result = await _transactionService.Transfer(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }
    }
}
