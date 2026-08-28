using TextPipeline;

namespace PipelineTest;

/// <summary>
/// Unit tests for the TrimDecorator class.
/// </summary>
[TestClass]
public sealed class TrimDecoratorTests
{
    /// <summary>
    /// Verifies that the TrimDecorator correctly trims leading and trailing whitespace from the input string.
    /// </summary>
    [TestMethod]
    public void Trim_LeadingAndTrailingSpaces()
    {
        ITextProcessor processor = new TrimDecorator(new TextProcessor());

        string result = processor.Process("   Hello World   ");

        Assert.AreEqual("Hello World", result);
    }

    /// <summary>
    /// Verifies that the TrimDecorator does not remove internal spaces from the input string.
    /// </summary>
    [TestMethod]
    public void Trim_InternalSpaces()
    {
        ITextProcessor processor = new TrimDecorator(new TextProcessor());

        string result = processor.Process("   Hello   World   ");

        Assert.AreEqual("Hello   World", result);
    }

    /// <summary>
    /// Verifies that the TrimDecorator correctly handles an empty string input.
    /// </summary>
    [TestMethod]
    public void Trim_EmptyString()
    {
        ITextProcessor processor = new TrimDecorator(new TextProcessor());

        string result = processor.Process("");

        Assert.AreEqual("", result);
    }

    /// <summary>
    /// Verifies that the TrimDecorator correctly handles a string that consists only of whitespace characters.
    /// </summary>
    [TestMethod]
    public void Trim_OnlyWhitespace()
    {
        ITextProcessor processor = new TrimDecorator(new TextProcessor());

        string result = processor.Process("     ");

        Assert.AreEqual("", result);
    }

    /// <summary>
    /// Verifies that the TrimDecorator correctly trims tabs and newlines from the input string.
    /// </summary>
    [TestMethod]
    public void Trim_TabsAndNewlines()
    {
        ITextProcessor processor = new TrimDecorator(new TextProcessor());

        string result = processor.Process("\n\tHello World\t\n");

        Assert.AreEqual("Hello World", result);
    }

    /// <summary>
    /// Verifies that the TrimDecorator does not modify a string that has no leading or trailing whitespace.
    /// </summary>
    [TestMethod]
    public void Trim_NoOuterWhitespace()
    {
        ITextProcessor processor = new TrimDecorator(new TextProcessor());

        string result = processor.Process("Hello World");

        Assert.AreEqual("Hello World", result);
    }
}
