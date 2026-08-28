using TextPipeline;

namespace PipelineTest;

[TestClass]
public sealed class UpperCaseDecoratorTests
{
    [TestMethod]
    public void UpperCase_LowercaseText()
    {
        ITextProcessor processor = new UpperCaseDecorator(new TextProcessor());

        string result = processor.Process("hello world");

        Assert.AreEqual("HELLO WORLD", result);
    }

    [TestMethod]
    public void UpperCase_MixedCaseText()
    {
        ITextProcessor processor = new UpperCaseDecorator(new TextProcessor());

        string result = processor.Process("HeLLo WoRLd");

        Assert.AreEqual("HELLO WORLD", result);
    }

    [TestMethod]
    public void UpperCase_UppercaseTextUnchanged()
    {
        ITextProcessor processor = new UpperCaseDecorator(new TextProcessor());

        string result = processor.Process("HELLO WORLD");

        Assert.AreEqual("HELLO WORLD", result);
    }

    [TestMethod]
    public void UpperCase_NumbersAndSymbols()
    {
        ITextProcessor processor = new UpperCaseDecorator(new TextProcessor());

        string result = processor.Process("hello 123! @#$");

        Assert.AreEqual("HELLO 123! @#$", result);
    }

    [TestMethod]
    public void UpperCase_EmptyString()
    {
        ITextProcessor processor = new UpperCaseDecorator(new TextProcessor());

        string result = processor.Process("");

        Assert.AreEqual("", result);
    }

    [TestMethod]
    public void UpperCase_PreservesWhitespace()
    {
        ITextProcessor processor = new UpperCaseDecorator(new TextProcessor());
        string result = processor.Process("   hello world   ");

        Assert.AreEqual("   HELLO WORLD   ", result);
    }

}
