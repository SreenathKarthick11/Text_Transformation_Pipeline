
// The TextDecorator class.
// It implements the ITextProcessor interface and takes an inner ITextProcessor as a parameter.

namespace TextPipeline;

public abstract class TextDecorator(ITextProcessor inner) : ITextProcessor
{
    protected ITextProcessor Inner { get; } = inner;

    public abstract string Process(string input);
}