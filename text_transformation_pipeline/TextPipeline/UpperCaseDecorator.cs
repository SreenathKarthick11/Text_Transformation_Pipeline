
// The UpperCaseDecorator class.
// It inherits from the TextDecorator class and overrides the Process method to convert the input string to uppercase.

namespace TextPipeline;

public class UpperCaseDecorator(ITextProcessor inner) : TextDecorator(inner)
{
    public override string Process(string input)
    {
        return Inner.Process(input).ToUpperInvariant();
    }
}