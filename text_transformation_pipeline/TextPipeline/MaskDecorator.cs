namespace TextPipeline;

/// <summary>
/// A decorator that masks all non-whitespace characters in the output of the wrapped text processor with asterisks.
/// </summary>
public class MaskDecorator(ITextProcessor inner) : TextDecorator(inner)
{
    /// <summary>
    /// Overrides the Process method to mask all non-whitespace characters in the input string with asterisks.
    /// </summary>
    /// <param name="input">The input string to be processed.</param>
    /// <returns>The processed string with all non-whitespace characters replaced by asterisks.</returns>
    public override string Process(string input)
    {
        string processed = Inner.Process(input);

        for (int i = 0; i < processed.Length; i++)
        {
            if (!char.IsWhiteSpace(processed[i]))
            {
                processed = processed.Remove(i, 1).Insert(i, "*");
            }
        }

        return processed;
    }
}
