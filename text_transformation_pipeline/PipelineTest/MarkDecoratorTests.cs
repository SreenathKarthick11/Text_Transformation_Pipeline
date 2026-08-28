using TextPipeline;

namespace PipelineTest;

[TestClass]
public sealed class MaskDecoratorTests
{
    [TestMethod]
    public void Mask_ReplacesCharactersWithAsterisks()
    {
        ITextProcessor processor = new MaskDecorator(new TextProcessor());

        string result = processor.Process("Hello");

        Assert.AreEqual("*****", result);
    }

    [TestMethod]
    public void Mask_PreservesSpaces()
    {
        ITextProcessor processor = new MaskDecorator(new TextProcessor());

        string result = processor.Process("Hello  World");

        Assert.AreEqual("*****  *****", result);
    }


    [TestMethod]
    public void Mask_EmptyString()
    {
        ITextProcessor processor = new MaskDecorator(new TextProcessor());
        string result = processor.Process("");

        Assert.AreEqual("", result);
    }

    [TestMethod]
    public void Mask_OnlyWhitespace()
    {
        ITextProcessor processor = new MaskDecorator(new TextProcessor());

        string result = processor.Process("     ");

        Assert.AreEqual("     ", result);
    }

    [TestMethod]
    public void Mask_NumbersAndSymbols()
    {
        ITextProcessor processor = new MaskDecorator(new TextProcessor());

        string result = processor.Process("ABC123!@#");

        Assert.AreEqual("*********", result);
    }

    [TestMethod]
    public void Mask_NewlinesAndTabs()
    {
        ITextProcessor processor = new MaskDecorator(new TextProcessor());

        string result = processor.Process("Hello\nWorld\tTest");

        Assert.AreEqual("*****\n*****\t****", result);
    }
}
