namespace TextPipeline;

/// <summary>
/// An abstract base class for text decorators that implement the ITextProcessor interface.
/// </summary>
public abstract class TextDecorator(ITextProcessor inner) : ITextProcessor
{
    protected ITextProcessor Inner { get; } = inner;

    public abstract string Process(string input);
}
