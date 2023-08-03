using BrightSky.Parsing.Xml;
using Pidgin;

namespace BrightSky.Parsing.Tests.Xml;

public class OpeningCommentTagTokenTests
{
    [Theory]
    [InlineData("<!--", "<!--")]
    public void Parser_ShouldBe_AsExpected(string input, string expected)
    {
        // Action
        var actual = OpeningCommentTagToken.Parser.ParseOrThrow(input);

        // Assert
        actual.Should().BeOfType<OpeningCommentTagToken>();
        actual.Value.Should().Be(expected);
    }  
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("#")]
    [InlineData("<!-")]
    [InlineData("<!")]
    [InlineData("<")]
    [InlineData("<#--")]
    public void Parser_ShouldThrowExactly_ParseException(string input)
    {
        // Action
        Action action = () => OpeningCommentTagToken.Parser.ParseOrThrow(input);

        // Assert
        action.Should().ThrowExactly<ParseException>();
    }
}