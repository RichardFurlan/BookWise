using Microsoft.AspNetCore.Mvc;

namespace BookWise.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById()
    {
        return Ok();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Post()
    {
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Post()
    {
        return Ok();
    }

    [HttpPost("{id}/profile-picture")]
    public async Task<IActionResult> PostProfilePicture()
    {
        return NoContent();
    }
}