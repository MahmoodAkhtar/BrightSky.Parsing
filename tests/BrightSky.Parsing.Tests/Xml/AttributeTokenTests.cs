using BrightSky.Parsing.Xml;
using Pidgin;

namespace BrightSky.Parsing.Tests.Xml;

public class AttributeTokenTests
{
    [Theory]
    [InlineData("abc=\"xyz\"", "abc")]
    [InlineData(" abc = \"xyz\" ", "abc")]
    public void Parser_ShouldBe_AsExpected(string input, string expected)
    {
        // Action
        var actual = AttributeToken.Parser.ParseOrThrow(input);

        // Assert
        actual.Should().BeOfType<AttributeToken>();
        actual.Value.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("#")]
    [InlineData("abc")]
    [InlineData(" abc")]
    [InlineData("abc ")]
    [InlineData(" abc ")]
    [InlineData("#abc")]
    [InlineData("abc#")]
    [InlineData("#abc#")]
    public void Parser_ShouldThrowExactly_ParseException(string input)
    {
        // Action
        Action action = () => AttributeToken.Parser.ParseOrThrow(input);

        // Assert
        action.Should().ThrowExactly<ParseException>();
    }}