using TextPipeline;

namespace PipelineTest;

[TestClass]
public sealed class LowerCaseDecoratorTests
{
    [TestMethod]
    public void LowerCase_UppercaseText()
    {
        ITextProcessor processor = new LowerCaseDecorator(new TextProcessor());

        string result = processor.Process("HELLO WORLD");

        Assert.AreEqual("hello world", result);
    }

    [TestMethod]
    public void LowerCase_MixedCaseText()
    {
        ITextProcessor processor = new LowerCaseDecorator(new TextProcessor());

        string result = processor.Process("HeLLo WoRLd");

        Assert.AreEqual("hello world", result);
    }

    [TestMethod]
    public void LowerCase_LowercaseTextUnchanged()
    {
        ITextProcessor processor = new LowerCaseDecorator(new TextProcessor());

        string result = processor.Process("hello world");

        Assert.AreEqual("hello world", result);
    }

    [TestMethod]
    public void LowerCase_NumbersAndSymbols()
    {
        ITextProcessor processor = new LowerCaseDecorator(new TextProcessor());

        string result = processor.Process("HELLO 123! @#$");

        Assert.AreEqual("hello 123! @#$", result);
    }

    [TestMethod]
    public void LowerCase_EmptyString()
    {
        ITextProcessor processor = new LowerCaseDecorator(new TextProcessor());

        string result = processor.Process("");

        Assert.AreEqual("", result);
    }

    [TestMethod]
    public void LowerCase_PreservesWhitespace()
    {
        ITextProcessor processor = new LowerCaseDecorator(new TextProcessor());

        string result = processor.Process("   HELLO WORLD   ");

        Assert.AreEqual("   hello world   ", result);
    }

}
