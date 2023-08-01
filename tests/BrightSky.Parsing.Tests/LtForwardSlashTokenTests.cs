using Pidgin;
using BrightSky.Parsing.Xml;

namespace BrightSky.Parsing.Tests;

public class LtForwardSlashTokenTests
{
    [Fact]
    public void Parser_ShouldBe_AsExpected()
    {
        // Action
        var actual = LtForwardSlashToken.Parser.ParseOrThrow("</");
        
        // Assert
        actual.Should().BeOfType<LtForwardSlashToken>();
        actual.Value.Should().Be("</");
    }
    
    [Fact]
    public void Parser_ShouldThrowExactly_ParseException()
    {
        // Action
        Action action = () => LtForwardSlashToken.Parser.ParseOrThrow("");
        
        // Assert
        action.Should().ThrowExactly<ParseException>();
    }
}