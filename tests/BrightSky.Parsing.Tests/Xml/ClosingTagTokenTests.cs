using BrightSky.Parsing.Xml;
using Pidgin;

namespace BrightSky.Parsing.Tests.Xml;

public class ClosingTagTokenTests
{
    [Theory]
    [InlineData("</abc>", "abc")]
    [InlineData("</ abc>", "abc")]
    [InlineData("</abc >", "abc")]
    [InlineData("</ abc >", "abc")]
    public void Parser_ShouldBe_AsExpected(string input, string expected)
    {
        // Action
        var actual = ClosingTagToken.Parser.ParseOrThrow(input);

        // Assert
        actual.Should().BeOfType<ClosingTagToken>();
        actual.Value.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("#")]
    [InlineData("abc")]
    [InlineData("<abc>")]
    [InlineData("/abc>")]
    [InlineData("</abc")]
    [InlineData("<#abc>")]
    public void Parser_ShouldThrowExactly_ParseException(string input)
    {
        // Action
        Action action = () => ClosingTagToken.Parser.ParseOrThrow(input);

        // Assert
        action.Should().ThrowExactly<ParseException>();
    }    
}