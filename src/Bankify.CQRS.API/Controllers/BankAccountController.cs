using Bankify.CQRS.Application.Commands;
using Bankify.CQRS.Application.Queries;
using Bankify.CQRS.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bankify.CQRS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BankAccountController(IMediator mediator) => _mediator = mediator;

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateBankAccountRequest req)
        {
            var id = await _mediator.Send(new CreateBankAccountCommand(req.OwnerName));
            return Ok(id);
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositMoneyRequest req)
        {
            await _mediator.Send(new DepositMoneyCommand(req.AccountId, req.Amount));
            return Ok("Deposit successful");
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawMoneyRequest req)
        {
            await _mediator.Send(new WithdrawMoneyCommand(req.AccountId, req.Amount));
            return Ok("Withdraw successful");
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetById(Guid accountId)
        {
            var result = await _mediator.Send(new GetBankAccountByIdQuery(accountId));
            return Ok(result);
        }
    }
}
