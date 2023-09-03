using BrightSky.Parsing.Xml;
using Pidgin;

namespace BrightSky.Parsing.Tests.Xml;

public class EmptyTagTokenTests
{
    [Theory]
    [InlineData("<abc/>", "abc")]
    [InlineData("< abc/>", "abc")]
    [InlineData("<abc />", "abc")]
    [InlineData("< abc />", "abc")]

    [InlineData("<abc def=\"123\"/>", "abc")]
    [InlineData("<abc def = \"123\" />", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\"/>", "abc")]
    [InlineData("<abc def = \"123\" ghi=\"456\"/>", "abc")]
    [InlineData("<abc def = \"123\" ghi = \"456\" />", "abc")]
    public void Parser_ShouldBe_AsExpected(string input, string expected)
    {
        // Action
        var actual = EmptyTagToken.Parser.ParseOrThrow(input);

        // Assert
        actual.Should().BeOfType<EmptyTagToken>();
        actual.Value.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("#")]
    [InlineData("abc")]
    [InlineData("<abc>")]
    [InlineData("</abc>")]
    [InlineData("abc>")]
    [InlineData("<abc")]
    [InlineData("<#abc>")]
    
    [InlineData("<abc def=>")]
    [InlineData("<abc def=\">")]
    [InlineData("<abc def=\"123>")]
    [InlineData("<abc =\"123\">")]
    
    [InlineData("<abc def=/>")]
    [InlineData("<abc def=\"/>")]
    [InlineData("<abc def=\"123/>")]
    [InlineData("<abc =\"123\"/>")]
    public void Parser_ShouldThrowExactly_ParseException(string input)
    {
        // Action
        Action action = () => EmptyTagToken.Parser.ParseOrThrow(input);

        // Assert
        action.Should().ThrowExactly<ParseException>();
    } 
}