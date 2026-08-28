using TextPipeline;

namespace PipelineTest;

[TestClass]
public sealed class TrimDecoratorTests
{
    [TestMethod]
    public void Trim_LeadingAndTrailingSpaces()
    {
        ITextProcessor processor = new TrimDecorator(new TextProcessor());

        string result = processor.Process("   Hello World   ");

        Assert.AreEqual("Hello World", result);
    }

    [TestMethod]
    public void Trim_InternalSpaces()
    {
        ITextProcessor processor = new TrimDecorator(new TextProcessor());

        string result = processor.Process("   Hello   World   ");

        Assert.AreEqual("Hello   World", result);
    }

    [TestMethod]
    public void Trim_EmptyString()
    {
        ITextProcessor processor = new TrimDecorator(new TextProcessor());

        string result = processor.Process("");

        Assert.AreEqual("", result);
    }

    [TestMethod]
    public void Trim_OnlyWhitespace()
    {
        ITextProcessor processor = new TrimDecorator(new TextProcessor());

        string result = processor.Process("     ");

        Assert.AreEqual("", result);
    }

    [TestMethod]
    public void Trim_TabsAndNewlines()
    {
        ITextProcessor processor = new TrimDecorator(new TextProcessor());

        string result = processor.Process("\n\tHello World\t\n");

        Assert.AreEqual("Hello World", result);
    }

    [TestMethod]
    public void Trim_NoOuterWhitespace()
    {
        ITextProcessor processor = new TrimDecorator(new TextProcessor());

        string result = processor.Process("Hello World");

        Assert.AreEqual("Hello World", result);
    }
}
