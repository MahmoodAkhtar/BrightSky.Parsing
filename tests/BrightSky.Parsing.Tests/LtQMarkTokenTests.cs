using Pidgin;
using BrightSky.Parsing.Xml;

namespace BrightSky.Parsing.Tests;

public class LtQMarkTokenTests
{
    [Fact]
    public void Parser_ShouldBe_AsExpected()
    {
        // Action
        var actual = LtQMarkToken.Parser.ParseOrThrow("<?");
        
        // Assert
        actual.Should().BeOfType<LtQMarkToken>();
        actual.Value.Should().Be("<?");
    }
    
    [Fact]
    public void Parser_ShouldThrowExactly_ParseException()
    {
        // Action
        Action action = () => LtQMarkToken.Parser.ParseOrThrow("");
        
        // Assert
        action.Should().ThrowExactly<ParseException>();
    }
}