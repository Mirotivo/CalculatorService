using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{operation}")]
    public IActionResult Calculate(string operation, [FromQuery] Dictionary<string, string> parameters)
    {
        try
        {
            var calculator = GetCalculator(operation);

            if (calculator == null)
            {
                return BadRequest($"Invalid operation '{operation}'.");
            }

            var validationErrors = calculator.Validate(parameters);

            if (validationErrors.Any())
            {
                return BadRequest(validationErrors);
            }

            var result = calculator.Calculate(parameters);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while performing a calculation.");
            return StatusCode(500, "An error occurred while performing the calculation.");
        }
    }

    private ICalculator GetCalculator(string operation)
    {
        switch (operation)
        {
            case "add":
                return new AddCalculator();
            case "subtract":
                return new SubtractCalculator();
            case "multiply":
                return new MultiplyCalculator();
            case "divide":
                return new DivideCalculator();
            case "power":
                return new PowerCalculator();
            case "root":
                return new RootCalculator();
            default:
                return null;
        }
    }
}
