using Pidgin;
using BrightSky.Parsing.Xml;

namespace BrightSky.Parsing.Tests;

public class IdentifierTokenTests
{
    [Theory]
    [InlineData("a")]
    [InlineData("_")]
    [InlineData(":")]
    
    [InlineData("ab")]
    [InlineData("_b")]
    [InlineData(":b")]
    
    [InlineData("a1")]
    [InlineData("_1")]
    [InlineData(":1")]
    
    [InlineData("a.")]
    [InlineData("_.")]
    [InlineData(":.")]
    
    [InlineData("a-")]
    [InlineData("_-")]
    [InlineData(":-")]
    
    [InlineData("a_")]
    [InlineData("__")]
    [InlineData(":_")]
    
    [InlineData("a:")]
    [InlineData("_:")]
    [InlineData("::")]

    [InlineData("abxyz")]
    [InlineData("_bxyz")]
    [InlineData(":bxyz")]
    [InlineData("a1xyz")]
    [InlineData("_1xyz")]
    [InlineData(":1xyz")]
    [InlineData("a.xyz")]
    [InlineData("_.xyz")]
    [InlineData(":.xyz")]
    [InlineData("a-xyz")]
    [InlineData("_-xyz")]
    [InlineData(":-xyz")]
    [InlineData("a_xyz")]
    [InlineData("__xyz")]
    [InlineData(":_xyz")]
    [InlineData("a:xyz")]
    [InlineData("_:xyz")]
    [InlineData("::xyz")]
    public void Parser_ShouldBe_AsExpected(string input)
    {
        // Action
        var actual = IdentifierToken.Parser.ParseOrThrow(input);

        // Assert
        actual.Should().BeOfType<IdentifierToken>();
        actual.Value.Should().Be(input);
    }

    [Theory]
    [InlineData("#")]
    [InlineData("a#")]
    [InlineData("_#")]
    [InlineData(":#")]
    public void Parser_ShouldThrowExactly_ParseException(string input)
    {
        // Action
        Action action = () => IdentifierToken.Parser.ParseOrThrow(input);

        // Assert
        action.Should().ThrowExactly<ParseException>();
    }
}