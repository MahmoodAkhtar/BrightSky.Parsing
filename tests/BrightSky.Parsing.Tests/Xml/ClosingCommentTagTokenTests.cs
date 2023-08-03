using BrightSky.Parsing.Xml;
using Pidgin;

namespace BrightSky.Parsing.Tests.Xml;

public class ClosingCommentTagTokenTests
{
    [Theory]
    [InlineData("-->", "-->")]
    public void Parser_ShouldBe_AsExpected(string input, string expected)
    {
        // Action
        var actual = ClosingCommentTagToken.Parser.ParseOrThrow(input);

        // Assert
        actual.Should().BeOfType<ClosingCommentTagToken>();
        actual.Value.Should().Be(expected);
    }  
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("#")]
    [InlineData("->")]
    [InlineData(">")]
    [InlineData("-#>")]
    public void Parser_ShouldThrowExactly_ParseException(string input)
    {
        // Action
        Action action = () => ClosingCommentTagToken.Parser.ParseOrThrow(input);

        // Assert
        action.Should().ThrowExactly<ParseException>();
    }   
}