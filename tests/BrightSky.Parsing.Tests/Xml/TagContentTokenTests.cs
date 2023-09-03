using BrightSky.Parsing.Xml;
using Pidgin;

namespace BrightSky.Parsing.Tests.Xml;

public class TagContentTokenTests
{
    [Theory]
    [InlineData("", "")]
    [InlineData(" ", " ")]
    [InlineData("abc", "abc")]
    [InlineData("abc<", "abc")]
    [InlineData("abc<def", "abc")]
    [InlineData("<def", "")]
    public void Parser_ShouldBe_AsExpected(string input, string expected)
    {
        // Action
        var actual = TagContentToken.Parser.ParseOrThrow(input);

        // Assert
        actual.Should().BeOfType<TagContentToken>();
        actual.Value.Should().Be(expected);
    }
}