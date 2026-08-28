using TextPipeline;

namespace PipelineTest;

/// <summary>
/// Unit tests for the LowerCaseDecorator class.
/// </summary>
[TestClass]
public sealed class LowerCaseDecoratorTests
{
    /// <summary>
    /// Verifies that the LowerCaseDecorator correctly converts uppercase text to lowercase.
    /// </summary>
    [TestMethod]
    public void LowerCase_UppercaseText()
    {
        ITextProcessor processor = new LowerCaseDecorator(new TextProcessor());

        string result = processor.Process("HELLO WORLD");

        Assert.AreEqual("hello world", result);
    }

    /// <summary>
    /// Verifies that the LowerCaseDecorator correctly converts mixed case text to lowercase.
    /// </summary>
    [TestMethod]
    public void LowerCase_MixedCaseText()
    {
        ITextProcessor processor = new LowerCaseDecorator(new TextProcessor());

        string result = processor.Process("HeLLo WoRLd");

        Assert.AreEqual("hello world", result);
    }

    /// <summary>
    /// Verifies that the LowerCaseDecorator does not change already lowercase text.
    /// </summary>
    [TestMethod]
    public void LowerCase_LowercaseTextUnchanged()
    {
        ITextProcessor processor = new LowerCaseDecorator(new TextProcessor());

        string result = processor.Process("hello world");

        Assert.AreEqual("hello world", result);
    }

    /// <summary>
    /// Verifies that the LowerCaseDecorator correctly handles text with numbers and symbols,
    /// converting only the letters to lowercase.
    /// </summary>
    [TestMethod]
    public void LowerCase_NumbersAndSymbols()
    {
        ITextProcessor processor = new LowerCaseDecorator(new TextProcessor());

        string result = processor.Process("HELLO 123! @#$");

        Assert.AreEqual("hello 123! @#$", result);
    }

    /// <summary>
    /// Verifies that the LowerCaseDecorator correctly handles an empty string input.
    /// </summary>
    [TestMethod]
    public void LowerCase_EmptyString()
    {
        ITextProcessor processor = new LowerCaseDecorator(new TextProcessor());

        string result = processor.Process("");

        Assert.AreEqual("", result);
    }

    /// <summary>
    /// Verifies that the LowerCaseDecorator correctly handles text with whitespace.
    /// </summary>
    [TestMethod]
    public void LowerCase_Whitespace()
    {
        ITextProcessor processor = new LowerCaseDecorator(new TextProcessor());

        string result = processor.Process("   HELLO WORLD   ");

        Assert.AreEqual("   hello world   ", result);
    }

}
