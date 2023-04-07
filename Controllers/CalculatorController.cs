using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Runtime.Serialization;

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
    public IActionResult Calculate(
        [FromRoute, DefaultValue("add")] string operation,
        [FromQuery, DefaultValue("5")] int? a = null,
        [FromQuery, DefaultValue("3")] int? b = null)
    {
        try
        {
            var calculator = GetCalculator(operation);

            if (calculator == null)
            {
                return BadRequest($"Invalid operation '{operation}'.");
            }

            // Create a new dictionary with default values
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (a.HasValue)
            {
                parameters["a"] = a.Value.ToString();
            }
            if (b.HasValue)
            {
                parameters["b"] = b.Value.ToString();
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
