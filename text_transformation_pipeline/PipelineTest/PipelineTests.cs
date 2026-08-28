using TextPipeline;

namespace PipelineTest;

/// <summary>
/// Unit tests for the text processing pipeline,
/// demonstrating the use of decorators to modify text processing behavior.
/// </summary>
[TestClass]
public sealed class PipelineTests
{
    /// <summary>
    /// Tests the pipeline with a TrimDecortor followed by an UpperCaseDecorator.
    /// </summary>
    [TestMethod]
    public void Pipeline_TrimThenUpperCase()
    {
        ITextProcessor processor =
            new UpperCaseDecorator(
                new TrimDecorator(
                    new TextProcessor()));

        string result = processor.Process("   Hello World   ");

        Assert.AreEqual("HELLO WORLD", result);
    }

    /// <summary>
    /// Tests the pipeline with a TrimDecorator followed by a LowerCaseDecorator.
    /// </summary>
    [TestMethod]
    public void Pipeline_TrimThenLowerCase()
    {
        ITextProcessor processor =
            new LowerCaseDecorator(
                new TrimDecorator(
                    new TextProcessor()));

        string result = processor.Process("   HeLLo WoRLd   ");

        Assert.AreEqual("hello world", result);
    }

    /// <summary>
    /// Tests the pipeline with a TrimDecorator followed by a MaskDecorator.
    /// </summary>
    [TestMethod]
    public void Pipeline_TrimThenMask()
    {
        ITextProcessor processor =
            new MaskDecorator(
                new TrimDecorator(
                    new TextProcessor()));

        string result = processor.Process("   Hello World   ");

        Assert.AreEqual("***** *****", result);
    }

    /// <summary>
    /// Tests the pipeline with a TrimDecorator followed by a MaskDecorator and then an UpperCaseDecorator.
    /// </summary>
    [TestMethod]
    public void Pipeline_TrimMaskUpperCase()
    {
        ITextProcessor processor =
            new UpperCaseDecorator(
                new MaskDecorator(
                    new TrimDecorator(
                        new TextProcessor())));

        string result = processor.Process("   Hello World   ");

        Assert.AreEqual("***** *****", result);
    }

    /// <summary>
    /// Tests the pipeline with all decorators applied:
    /// TrimDecorator, MaskDecorator, UpperCaseDecorator, and LowerCaseDecorator.
    /// </summary>
    [TestMethod]
    public void Pipeline_UseAllDecorators()
    {
        ITextProcessor processor =
            new LowerCaseDecorator(
                new UpperCaseDecorator(
                    new MaskDecorator(
                        new TrimDecorator(
                            new TextProcessor()))));

        string result = processor.Process("   Hello World 12#@5  ");

        Assert.AreEqual("***** ***** *****", result);
    }

    /// <summary>
    /// Tests building the pipeline incrementally by wrapping the processor with decorators one by one.
    /// </summary>
    [TestMethod]
    public void Pipeline_BuiltIncrementally()
    {
        ITextProcessor processor = new TextProcessor();

        processor = new TrimDecorator(processor);
        processor = new UpperCaseDecorator(processor);
        processor = new MaskDecorator(processor);

        string result = processor.Process("   Hello World   ");

        Assert.AreEqual("***** *****", result);
    }

    /// <summary>
    /// Tests the pipeline with different orderings of UpperCaseDecorator and LowerCaseDecorator 
    /// to demonstrate the effect of decorator order.
    /// </summary>
    [TestMethod]
    public void Pipeline_CaseTransformation()
    {
        ITextProcessor upperThenLower =
            new LowerCaseDecorator(
                new UpperCaseDecorator(
                    new TextProcessor()));

        ITextProcessor lowerThenUpper =
            new UpperCaseDecorator(
                new LowerCaseDecorator(
                    new TextProcessor()));

        Assert.AreEqual("hello world",upperThenLower.Process("Hello World"));

        Assert.AreEqual("HELLO WORLD",lowerThenUpper.Process("Hello World"));
    }

    /// <summary>
    /// Tests the pipeline with an empty input string.
    /// </summary>
    [TestMethod]
    public void Pipeline_EmptyInput()
    {
        ITextProcessor processor =
            new UpperCaseDecorator(
                new MaskDecorator(
                    new TrimDecorator(
                        new TextProcessor())));

        string result = processor.Process("");

        Assert.AreEqual("", result);
    }

    /// <summary>
    /// Tests the pipeline with an input string that contains only whitespace characters.
    /// </summary>
    [TestMethod]
    public void Pipeline_WhitespaceInput()
    {
        ITextProcessor processor =
            new MaskDecorator(
                new TrimDecorator(
                    new TextProcessor()));

        string result = processor.Process("     ");

        Assert.AreEqual("", result);
    }

}
