public interface ICalculator
{
    string Name { get; }
    IEnumerable<string> Validate(Dictionary<string, string> parameters);
    double Calculate(Dictionary<string, string> parameters);
}

public abstract class CalculatorBase : ICalculator
{
    public abstract string Name { get; }

    public virtual IEnumerable<string> Validate(Dictionary<string, string> parameters)
    {
        return Enumerable.Empty<string>();
    }

    public abstract double Calculate(Dictionary<string, string> parameters);
}