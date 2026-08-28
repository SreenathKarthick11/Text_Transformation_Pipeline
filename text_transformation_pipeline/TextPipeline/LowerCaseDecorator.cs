namespace TextPipeline;

/// <summary>
/// A decorator that converts the output of the wrapped text processor to lowercase.
/// </summary>
public class LowerCaseDecorator(ITextProcessor inner) : TextDecorator(inner)
{
    /// <summary>
    /// Overrides the Process method to convert the input string to lowercase.
    /// </summary>
    /// <param name="input">The input string to be processed.</param>
    /// <returns>The processed string converted to lowercase.</returns>
    public override string Process(string input)
    {
        return Inner.Process(input).ToLowerInvariant();
    }
}
