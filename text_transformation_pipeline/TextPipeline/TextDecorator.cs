
namespace TextPipeline;

public abstract class TextDecorator(ITextProcessor inner) : ITextProcessor
{
    protected ITextProcessor Inner { get; } = inner;

    public abstract string Process(string input);
}