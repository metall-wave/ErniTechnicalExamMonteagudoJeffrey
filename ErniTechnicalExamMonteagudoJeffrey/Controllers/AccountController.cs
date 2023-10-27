using ErniTechnicalExamMonteagudoJeffrey.Interfaces;
using ErniTechnicalExamMonteagudoJeffrey.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErniTechnicalExamMonteagudoJeffrey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Returns a list of all existing user accounts in the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            try
            {
                return Ok(await _accountService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        /// <summary>
        /// Returns a user's account using it's id as reference.
        /// </summary>
        /// <param name="id">Id of the account to retrieve.</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetAccount")]
        public async Task<IActionResult> GetAccount(int id)
        {
            try
            {
                return Ok(await _accountService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        /// <summary>
        /// Creates a new user account and adds it to the database.
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest request)
        {
            try
            {
                if (request is null)
                {
                    return BadRequest("account object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var createdAccount = await _accountService.AddAsync(request);

                return CreatedAtRoute("GetAccount", new { id = createdAccount.Id }, createdAccount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        /// <summary>
        /// Deletes an existing account using it's id as reference.
        /// </summary>
        /// <param name="id">Id of the account to be deleted.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                var result = await _accountService.Delete(id);

                return result ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        
    }
}
