using Pidgin;
using BrightSky.Parsing.Xml;

namespace BrightSky.Parsing.Tests;

public class ForwardSlashGtTokenTests
{
    [Fact]
    public void Parser_ShouldBe_AsExpected()
    {
        // Action
        var actual = ForwardSlashGtToken.Parser.ParseOrThrow("/>");
        
        // Assert
        actual.Should().BeOfType<ForwardSlashGtToken>();
        actual.Value.Should().Be("/>");
    }
    
    [Fact]
    public void Parser_ShouldThrowExactly_ParseException()
    {
        // Action
        Action action = () => ForwardSlashGtToken.Parser.ParseOrThrow("");
        
        // Assert
        action.Should().ThrowExactly<ParseException>();
    }
}