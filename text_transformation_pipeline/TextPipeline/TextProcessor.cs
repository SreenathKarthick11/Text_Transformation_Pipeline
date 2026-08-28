namespace TextPipeline;

/// <summary>
/// A basic implementation of the ITextProcessor interface that returns the input string without any modifications.
/// </summary>
public class TextProcessor : ITextProcessor
{
    /// <summary>
    /// Processes the input string and returns it without any modifications.
    /// </summary>
    /// <param name="input">The input string to be processed.</param>
    /// <returns>The processed string, which is the same as the input string.</returns>
    public string Process(string input)
    {
        return input;
    }
}
