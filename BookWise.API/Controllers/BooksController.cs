using BookWise.Application.Commands.Book.DeleteBook;
using BookWise.Application.Commands.Book.InsertBook;
using BookWise.Application.Commands.Book.UpdateBook;
using BookWise.Application.Queries.Book.GetAllBooks;
using BookWise.Application.Queries.Book.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookWise.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    // Todo: Manter page no valor padrão 1 
    public async Task<IActionResult> GetAll(int page = 1, int size = 10, string search = "")
    {
        var result = await _mediator.Send(new GetAllBooksQuery(search, page, size));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetBookByIdQuery(id));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
         
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertBookCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateBookCommand command)
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
        var result = await _mediator.Send(new DeleteBookCommand(id));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }
}