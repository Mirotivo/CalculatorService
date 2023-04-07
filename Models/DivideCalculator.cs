public class DivideCalculator : CalculatorBase
{
    public override string Name => "Divide";

    public override double Calculate(Dictionary<string, string> parameters)
    {
        var a = int.Parse(parameters["a"]);
        var b = int.Parse(parameters["b"]);

        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }

        return (double)a / b;
    }

    public override IEnumerable<string> Validate(Dictionary<string, string> parameters)
    {
        if (!parameters.ContainsKey("a"))
        {
            yield return "Missing parameter 'a'.";
        }

        if (!parameters.ContainsKey("b"))
        {
            yield return "Missing parameter 'b'.";
        }

        if (!int.TryParse(parameters["a"], out _))
        {
            yield return "Invalid value for parameter 'a'.";
        }

        if (!int.TryParse(parameters["b"], out _))
        {
            yield return "Invalid value for parameter 'b'.";
        }

        if (int.Parse(parameters["b"]) == 0)
        {
            yield return "Value of parameter 'b' must be non-zero.";
        }
    }
}
