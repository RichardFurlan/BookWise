using BookWise.Application.Commands.Loan.CancelLoan;
using BookWise.Application.Commands.Loan.ExtendLoan;
using BookWise.Application.Commands.Loan.InsertLoan;
using BookWise.Application.Commands.Loan.ReturnLoan;
using BookWise.Application.Queries.Loan.GetLoanById;
using BookWise.Application.Queries.Loan.GetLoansByBook;
using BookWise.Application.Queries.Loan.GetLoansByUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookWise.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoansController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoansController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLoanById(int id)
    {
        var result = await _mediator.Send(new GetLoanByIdQuery(id));

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateLoan(InsertLoanCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return CreatedAtAction(nameof(GetLoanById), new { id = result.Data }, result.Data);
    }
    
    [HttpPost("{id}/cancel")]
    public async Task<IActionResult> CancelLoan(int id)
    {
        var result = await _mediator.Send(new CancelLoanCommand(id));

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return NoContent();
    }

    [HttpPost("{id}/extend")]
    public async Task<IActionResult> ExtendLoan(int id, ExtendLoanCommand command)
    {
        if (id != command.LoanId)
            return BadRequest("ID do empréstimo inconsistente.");

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return NoContent();
    }

    [HttpPost("{id}/return")]
    public async Task<IActionResult> ReturnLoan(int id)
    {
        var result = await _mediator.Send(new ReturnLoanCommand(id));

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return NoContent();
    }
    
    
    [HttpGet("book/{bookId}")]
    public async Task<IActionResult> GetLoansByBook(int bookId)
    {
        var result = await _mediator.Send(new GetLoansByBookQuery(bookId));

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetLoansByUser(int userId)
    {
        var result = await _mediator.Send(new GetLoansByUserQuery(userId));

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return Ok(result);
    }
}