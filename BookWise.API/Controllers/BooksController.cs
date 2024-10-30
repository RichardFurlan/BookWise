using Microsoft.AspNetCore.Mvc;

namespace BookWise.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(int page, int size = 10, string search = "")
    {
        return Ok();
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetById(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post(int id)
    {

        return CreatedAtAction(nameof(GetById), new { id = id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return NoContent();
    }

    [HttpPut("{id}/loan")]
    public async Task<IActionResult> Loan(int id)
    {
        return Ok();
    }

    [HttpPut("{id}/return")]
    public async Task<IActionResult> Return(int id)
    {
        return Ok();
    }

    [HttpPost("{id}/rating")]
    public async Task<IActionResult> PostRating()
    {
        return NoContent();
    }
}