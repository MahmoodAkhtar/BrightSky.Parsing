using BrightSky.Parsing.Xml;
using Pidgin;

namespace BrightSky.Parsing.Tests.Xml;

public class EqTokenTests
{
    [Fact]
    public void Parser_ShouldBe_AsExpected()
    {
        // Action
        var actual = EqToken.Parser.ParseOrThrow("=");

        // Assert
        actual.Should().BeOfType<EqToken>();
        actual.Value.Should().Be("=");
    }

    [Fact]
    public void Parser_ShouldThrowExactly_ParseException()
    {
        // Action
        Action action = () => EqToken.Parser.ParseOrThrow("");

        // Assert
        action.Should().ThrowExactly<ParseException>();
    }
}