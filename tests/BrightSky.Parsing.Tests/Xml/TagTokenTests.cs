using BrightSky.Parsing.Xml;
using Pidgin;

namespace BrightSky.Parsing.Tests.Xml;

public class TagTokenTests
{
    [Theory]
    [InlineData("<abc></abc>", "abc")]
    [InlineData("<abc> </abc>", "abc")]
    [InlineData("<abc>\t</abc>", "abc")]
    [InlineData("<abc>\r</abc>", "abc")]
    [InlineData("<abc>\n</abc>", "abc")]
    [InlineData("<abc>\r\n</abc>", "abc")]
    [InlineData("<abc> \t\r\n</abc>", "abc")]
    [InlineData("<abc>xyz</abc>", "abc")]
    [InlineData("<abc><xyx/></abc>", "abc")]
    [InlineData("<abc><xyx></xyz></abc>", "abc")]
    [InlineData("<abc><!----></abc>", "abc")]
    [InlineData("<abc><!-- xyz --></abc>", "abc")]
    [InlineData("<abc>\r\n<!--\r\n\txyz \r\n-->\r\n</abc>", "abc")]
    public void Parser_ShouldBe_AsExpected(string input, string expected)
    {
        // Action
        var actual = TagToken.Parser.ParseOrThrow(input);

        // Assert
        actual.Should().BeOfType<TagToken>();
        actual.Value.Should().Be(expected);
    } 
}