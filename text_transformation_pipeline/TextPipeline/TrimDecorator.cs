namespace TextPipeline;

/// <summary>
/// A decorator that trims whitespace from the output of the wrapped text processor.
/// </summary>
public class TrimDecorator(ITextProcessor inner) : TextDecorator(inner)
{
    /// <summary>
    /// Overrides the Process method to trim whitespace from the input string.
    /// </summary>
    /// <param name="input">The input string to be processed.</param>
    /// <returns>The processed string with leading and trailing whitespace removed.</returns>
    public override string Process(string input)
    {
        return Inner.Process(input).Trim();
    }
}
