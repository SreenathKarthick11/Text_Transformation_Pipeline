namespace TextPipeline;

/// <summary>
/// A decorator that converts the output of the wrapped text processor to uppercase.
/// </summary>
public class UpperCaseDecorator(ITextProcessor inner) : TextDecorator(inner)
{
    /// <summary>
    /// Overrides the Process method to convert the input string to uppercase.
    /// </summary>
    /// <param name="input">The input string to be processed.</param>
    /// <returns>The processed string in uppercase.</returns>
    public override string Process(string input)
    {
        return Inner.Process(input).ToUpperInvariant();
    }
}
