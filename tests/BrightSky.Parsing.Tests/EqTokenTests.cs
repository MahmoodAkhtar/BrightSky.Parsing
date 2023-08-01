using Pidgin;
using BrightSky.Parsing.Xml;

namespace BrightSky.Parsing.Tests;

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