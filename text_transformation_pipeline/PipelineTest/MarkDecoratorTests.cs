using TextPipeline;

namespace PipelineTest;

/// <summary>
/// Unit tests for the MaskDecorator class.
/// </summary>
[TestClass]
public sealed class MaskDecoratorTests
{
    /// <summary>
    /// Verifies that the MaskDecorator correctly replaces characters with asterisks.
    /// </summary>
    [TestMethod]
    public void Mask_ReplacesCharactersWithAsterisks()
    {
        ITextProcessor processor = new MaskDecorator(new TextProcessor());

        string result = processor.Process("Hello");

        Assert.AreEqual("*****", result);
    }

    /// <summary>
    /// Verifies that the MaskDecorator preserves spaces in the input string.
    /// </summary>
    [TestMethod]
    public void Mask_PreservesSpaces()
    {
        ITextProcessor processor = new MaskDecorator(new TextProcessor());

        string result = processor.Process("Hello  World");

        Assert.AreEqual("*****  *****", result);
    }

    /// <summary>
    /// Verifies that the MaskDecorator handles an empty string input correctly.
    /// </summary>
    [TestMethod]
    public void Mask_EmptyString()
    {
        ITextProcessor processor = new MaskDecorator(new TextProcessor());
        string result = processor.Process("");

        Assert.AreEqual("", result);
    }

    /// <summary>
    /// Verifies that the MaskDecorator handles a string with only whitespace correctly.
    /// </summary>
    [TestMethod]
    public void Mask_OnlyWhitespace()
    {
        ITextProcessor processor = new MaskDecorator(new TextProcessor());

        string result = processor.Process("     ");

        Assert.AreEqual("     ", result);
    }

    /// <summary>
    /// Verifies that the MaskDecorator correctly masks numbers and symbols in the input string.
    /// </summary>
    [TestMethod]
    public void Mask_NumbersAndSymbols()
    {
        ITextProcessor processor = new MaskDecorator(new TextProcessor());

        string result = processor.Process("ABC123!@#");

        Assert.AreEqual("*********", result);
    }

    /// <summary>
    /// Verifies that the MaskDecorator correctly handles newlines and tabs in the input string.
    /// </summary>
    [TestMethod]
    public void Mask_NewlinesAndTabs()
    {
        ITextProcessor processor = new MaskDecorator(new TextProcessor());

        string result = processor.Process("Hello\nWorld\tTest");

        Assert.AreEqual("*****\n*****\t****", result);
    }
}
