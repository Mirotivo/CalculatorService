using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    [HttpGet("add/{a}/{b}")]
    public IActionResult Add(int a, int b)
    {
        return Ok(a + b);
    }

    [HttpGet("subtract/{a}/{b}")]
    public IActionResult Subtract(int a, int b)
    {
        return Ok(a - b);
    }

    [HttpGet("multiply/{a}/{b}")]
    public IActionResult Multiply(int a, int b)
    {
        return Ok(a * b);
    }

    [HttpGet("divide/{a}/{b}")]
    public IActionResult Divide(int a, int b)
    {
        if (b == 0)
        {
            return BadRequest("Cannot divide by zero.");
        }

        return Ok(a / b);
    }
}
