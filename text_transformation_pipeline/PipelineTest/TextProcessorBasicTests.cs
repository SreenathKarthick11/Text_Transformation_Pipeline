using TextPipeline;

namespace PipelineTest;

/// <summary>
/// Unit tests for the TextProcessor class.
/// </summary>
[TestClass]
public sealed class TextProcessorBasicTests
{
    /// <summary>
    /// Verify that Process returns the input string unchanged.
    /// </summary>
    [TestMethod]
    public void Process_InputUnchanged()
    {
        ITextProcessor processor = new TextProcessor();

        string result = processor.Process("Hello World");

        Assert.AreEqual("Hello World", result);
    }


    /// <summary>
    /// Verify that Process handles leading and trailing whitespace correctly.
    /// </summary>
    [TestMethod]
    public void Process_LeadingAndTrailingWhitespace()
    {
        ITextProcessor processor = new TextProcessor();

        string result = processor.Process("   Hello World   ");

        Assert.AreEqual("   Hello World   ", result);
    }

    /// <summary>
    /// Verify that Process handles an empty string correctly.
    /// </summary>  
    [TestMethod]
    public void Process_EmptyString()
    {
        ITextProcessor processor = new TextProcessor();

        string result = processor.Process("");

        Assert.AreEqual("", result);
    }


    /// <summary>
    /// Verify that Process handles special characters correctly.
    /// </summary>
    [TestMethod]
    public void Process_SpecialCharacters()
    {
        ITextProcessor processor = new TextProcessor();

        string result = processor.Process("Hello, World! 123.");

        Assert.AreEqual("Hello, World! 123.", result);
    }
}
