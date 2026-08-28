using TextPipeline;

namespace PipelineTest;

[TestClass]
public sealed class TextProcessorBasicTests
{
    [TestMethod]
    public void Process_ReturnsInputUnchanged()
    {
        ITextProcessor processor = new TextProcessor();

        string result = processor.Process("Hello World");

        Assert.AreEqual("Hello World", result);
    }

    [TestMethod]
    public void Process_PreservesLeadingAndTrailingWhitespace()
    {
        ITextProcessor processor = new TextProcessor();

        string result = processor.Process("   Hello World   ");

        Assert.AreEqual("   Hello World   ", result);
    }

    [TestMethod]
    public void Process_HandlesEmptyString()
    {
        ITextProcessor processor = new TextProcessor();

        string result = processor.Process("");

        Assert.AreEqual("", result);
    }

    [TestMethod]
    public void Process_PreservesSpecialCharacters()
    {
        ITextProcessor processor = new TextProcessor();

        string result = processor.Process("Hello, World! 123.");

        Assert.AreEqual("Hello, World! 123.", result);
    }
}
