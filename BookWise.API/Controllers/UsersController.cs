using BookWise.Application.Commands.User.InsertProfilePicture;
using BookWise.Application.Commands.User.InsertUser;
using BookWise.Application.Commands.User.LoginUser;
using BookWise.Application.Commands.User.UpdateUser;
using BookWise.Application.Queries.User.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookWise.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(id));
        
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Post(InsertUserCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Post(LoginUserCommand command)
    {
        var result = await _mediator.Send(command);
        
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        
        return Ok(result);
    }

    [HttpPost("{id}/profile-picture")]
    public async Task<IActionResult> PostProfilePicture(int id, IFormFile file)
    {
        var command = new InserProfilePictureCommand(id, file);
        
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateUserCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        
        return NoContent();
    }
}