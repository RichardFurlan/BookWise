using BookWise.Application.Commands.Publisher.DeletePublisher;
using BookWise.Application.Commands.Publisher.InsertPublisher;
using BookWise.Application.Commands.Publisher.UpdatePublisher;
using BookWise.Application.Queries.Publisher.GetPublisherById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookWise.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PublishersController : ControllerBase
{
    private readonly IMediator _mediator;

    public PublishersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetPublisherByIdQuery(id));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertPublisherCommand command)
    {
        var result = await _mediator.Send(command);
        
        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdatePublisherCommand command)
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
        var result = await _mediator.Send(new DeletePublisherCommand(id));
        
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }
}