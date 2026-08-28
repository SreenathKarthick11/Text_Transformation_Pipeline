
// The LowerCaseDecorator class.
// It inherits from the TextDecorator class and overrides the Process method to convert the input string to lowercase.

namespace TextPipeline;
public class LowerCaseDecorator(ITextProcessor inner) : TextDecorator(inner)
{
    public override string Process(string input)
    {
        return Inner.Process(input).ToLowerInvariant();
    }
}