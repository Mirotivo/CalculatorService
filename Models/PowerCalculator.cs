public class PowerCalculator : CalculatorBase
{
    public override string Name => "Power";

    public override object Calculate(Dictionary<string, string> parameters)
    {
        var a = int.Parse(parameters["a"]);

        return a * a;
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
    }
}
