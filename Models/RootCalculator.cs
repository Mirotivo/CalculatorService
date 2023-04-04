public class RootCalculator : CalculatorBase
{
    public override string Name => "Root";

    public override object Calculate(Dictionary<string, string> parameters)
    {
        var a = int.Parse(parameters["a"]);

        if (a < 0)
        {
            throw new ArgumentException("Value of parameter 'a' must be non-negative.");
        }

        return Math.Sqrt(a);
    }

    public override IEnumerable<string> Validate(Dictionary<string, string> parameters)
    {
        if (!parameters.ContainsKey("a"))
        {
            yield return "Missing parameter 'a'.";
        }

        if (!int.TryParse(parameters["a"], out _))
        {
            yield return "Invalid value for parameter 'a'.";
        }

        if (int.Parse(parameters["a"]) < 0)
        {
            yield return "Value of parameter 'a' must be non-negative.";
        }
    }
}
