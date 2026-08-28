
// The MaskDecorator class.
// It inherits from the TextDecorator class and overrides the Process method to mask all letters and digits in the input string with asterisks.

namespace TextPipeline;
public class MaskDecorator(ITextProcessor inner) : TextDecorator(inner)
{
    public override string Process(string input)
    {
        string processed = Inner.Process(input);

        for (int i = 0; i < processed.Length; i++)
        {
            if (char.IsLetterOrDigit(processed[i]))
            {
                processed = processed.Remove(i, 1).Insert(i, "*");
            }
        }

        return processed;
    }
}
