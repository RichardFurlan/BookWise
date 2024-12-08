using BookWise.Application.Commands.Rating.Insert;
using BookWise.Application.Queries.Rating.GetRatingById;
using BookWise.Application.Queries.Rating.GetRatingsByBookId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookWise.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RatingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RatingsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("{bookId}/add")]
    public async Task<IActionResult> AddRating(int bookId, InsertRatingCommand command)
    {
        if (bookId != command.BookId)
            return BadRequest("ID do livro inconsistente.");

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return NoContent();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRatingById(int id)
    {
        var result = await _mediator.Send(new GetRatingByIdQuery(id));

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpGet("book/{bookId}")]
    public async Task<IActionResult> GetRatingsByBookId(int bookId, int page = 1, int size = 10, string search = "")
    {
        var result = await _mediator.Send(new GetRatingsByBookIdQuery(bookId, search, page, size));
        
        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return Ok(result);
    }
}