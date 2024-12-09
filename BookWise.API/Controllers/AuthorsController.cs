using BookWise.Application.Commands.Author.DeleteAuthor;
using BookWise.Application.Commands.Author.InsertAuthor;
using BookWise.Application.Commands.Author.UpdateAuthor;
using BookWise.Application.Queries.Author.GetAuthorById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookWise.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetAuthorByIdQuery(id));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertAuthorCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateAuthorCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteAuthorCommand(id));
        
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }
}