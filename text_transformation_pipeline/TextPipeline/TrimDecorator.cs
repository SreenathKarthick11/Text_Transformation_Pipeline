
// The TrimDecorator class.
// It inherits from the TextDecorator class and overrides the Process method to trim whitespace from the input string.

namespace TextPipeline;
public class TrimDecorator(ITextProcessor inner) : TextDecorator(inner)
{
    public override string Process(string input)
    {
        return Inner.Process(input).Trim();
    }
}
