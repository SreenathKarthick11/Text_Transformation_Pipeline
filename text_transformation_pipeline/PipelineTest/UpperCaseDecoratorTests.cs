using TextPipeline;

namespace PipelineTest;

/// <summary>
/// Unit tests for the UpperCaseDecorator class.
/// </summary>
[TestClass]
public sealed class UpperCaseDecoratorTests
{
    /// <summary>
    /// Verifies that the UpperCaseDecorator correctly converts lowercase text to uppercase.
    /// </summary>
    [TestMethod]
    public void UpperCase_LowercaseText()
    {
        ITextProcessor processor = new UpperCaseDecorator(new TextProcessor());

        string result = processor.Process("hello world");

        Assert.AreEqual("HELLO WORLD", result);
    }

    /// <summary>
    /// Verifies that the UpperCaseDecorator correctly converts mixed case text to uppercase.
    /// </summary>
    [TestMethod]
    public void UpperCase_MixedCaseText()
    {
        ITextProcessor processor = new UpperCaseDecorator(new TextProcessor());

        string result = processor.Process("HeLLo WoRLd");

        Assert.AreEqual("HELLO WORLD", result);
    }

    /// <summary>
    /// Verifies that the UpperCaseDecorator does not change already uppercase text.
    /// </summary>
    [TestMethod]
    public void UpperCase_UppercaseTextUnchanged()
    {
        ITextProcessor processor = new UpperCaseDecorator(new TextProcessor());

        string result = processor.Process("HELLO WORLD");

        Assert.AreEqual("HELLO WORLD", result);
    }

    /// <summary>
    /// Verifies that the UpperCaseDecorator correctly handles text with numbers and symbols,
    /// converting only the alphabetic characters to uppercase.
    /// </summary>
    [TestMethod]
    public void UpperCase_NumbersAndSymbols()
    {
        ITextProcessor processor = new UpperCaseDecorator(new TextProcessor());

        string result = processor.Process("hello 123! @#$");

        Assert.AreEqual("HELLO 123! @#$", result);
    }

    /// <summary>
    /// Verifies that the UpperCaseDecorator correctly handles an empty string input.
    /// </summary>
    [TestMethod]
    public void UpperCase_EmptyString()
    {
        ITextProcessor processor = new UpperCaseDecorator(new TextProcessor());

        string result = processor.Process("");

        Assert.AreEqual("", result);
    }

    /// <summary>
    /// Verifies that the UpperCaseDecorator correctly handles text with whitespace.
    /// </summary>
    [TestMethod]
    public void UpperCase_Whitespace()
    {
        ITextProcessor processor = new UpperCaseDecorator(new TextProcessor());
        string result = processor.Process("   hello world   ");

        Assert.AreEqual("   HELLO WORLD   ", result);
    }

}
