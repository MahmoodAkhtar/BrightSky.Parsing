using BrightSky.Parsing.Xml;
using Pidgin;

namespace BrightSky.Parsing.Tests;

public class GtTokenTests
{
    [Fact]
    public void Parser_ShouldBe_AsExpected()
    {
        // Action
        var actual = GtToken.Parser.ParseOrThrow(">");
        
        // Assert
        actual.Should().BeOfType<GtToken>();
        actual.Value.Should().Be(">");
    }
    
    [Fact]
    public void Parser_ShouldThrowExactly_ParseException()
    {
        // Action
        Action action = () => GtToken.Parser.ParseOrThrow("");
        
        // Assert
        action.Should().ThrowExactly<ParseException>();
    }
}