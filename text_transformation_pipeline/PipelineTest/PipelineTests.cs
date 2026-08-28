using TextPipeline;

namespace PipelineTest;

[TestClass]
public sealed class PipelineTests
{
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


    [TestMethod]
    public void Pipeline_TrimMaskAndUpperCase()
    {
        ITextProcessor processor =
            new UpperCaseDecorator(
                new MaskDecorator(
                    new TrimDecorator(
                        new TextProcessor())));

        string result = processor.Process("   Hello World   ");

        Assert.AreEqual("***** *****", result);
    }


    [TestMethod]
    public void Pipeline_TrimMaskAndLowerCase()
    {
        ITextProcessor processor =
            new LowerCaseDecorator(
                new MaskDecorator(
                    new TrimDecorator(
                        new TextProcessor())));

        string result = processor.Process("   Hello World   ");

        Assert.AreEqual("***** *****", result);
    }


    [TestMethod]
    public void Pipeline_UseAllDecorators()
    {
        ITextProcessor processor =
            new LowerCaseDecorator(
                new UpperCaseDecorator(
                    new MaskDecorator(
                        new TrimDecorator(
                            new TextProcessor()))));

        string result = processor.Process("   Hello World   ");

        Assert.AreEqual("***** *****", result);
    }


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
