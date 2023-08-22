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
    [InlineData("<abc>\r\n<!--\r\n\txyz \r\n-->\r\nxyz</abc>", "abc")]
    [InlineData("<abc>\r\n<!--\r\n\txyz \r\n-->\r\n<xyx/></abc>", "abc")]
    [InlineData("<abc>\r\n<!--\r\n\txyz \r\n-->\r\n<xyx></xyz></abc>", "abc")]
    
    [InlineData("<abc def=\"123\"></abc>", "abc")]
    [InlineData("<abc def=\"123\"> </abc>", "abc")]
    [InlineData("<abc def=\"123\">\t</abc>", "abc")]
    [InlineData("<abc def=\"123\">\r</abc>", "abc")]
    [InlineData("<abc def=\"123\">\n</abc>", "abc")]
    [InlineData("<abc def=\"123\">\r\n</abc>", "abc")]
    [InlineData("<abc def=\"123\"> \t\r\n</abc>", "abc")]
    [InlineData("<abc def=\"123\">xyz</abc>", "abc")]
    [InlineData("<abc def=\"123\"><xyx/></abc>", "abc")]
    [InlineData("<abc def=\"123\"><xyx></xyz></abc>", "abc")]
    [InlineData("<abc def=\"123\"><!----></abc>", "abc")]
    [InlineData("<abc def=\"123\"><!-- xyz --></abc>", "abc")]
    [InlineData("<abc def=\"123\">\r\n<!--\r\n\txyz \r\n-->\r\n</abc>", "abc")]
    [InlineData("<abc def=\"123\">\r\n<!--\r\n\txyz \r\n-->\r\nxyz</abc>", "abc")]
    [InlineData("<abc def=\"123\">\r\n<!--\r\n\txyz \r\n-->\r\n<xyx/></abc>", "abc")]
    [InlineData("<abc def=\"123\">\r\n<!--\r\n\txyz \r\n-->\r\n<xyx></xyz></abc>", "abc")]
    
    [InlineData("<abc def=\"123\" ghi=\"456\"></abc>", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\"> </abc>", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\">\t</abc>", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\">\r</abc>", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\">\n</abc>", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\">\r\n</abc>", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\"> \t\r\n</abc>", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\">xyz</abc>", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\"><xyx/></abc>", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\"><xyx></xyz></abc>", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\"><!----></abc>", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\"><!-- xyz --></abc>", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\">\r\n<!--\r\n\txyz \r\n-->\r\n</abc>", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\">\r\n<!--\r\n\txyz \r\n-->\r\nxyz</abc>", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\">\r\n<!--\r\n\txyz \r\n-->\r\n<xyx/></abc>", "abc")]
    [InlineData("<abc def=\"123\" ghi=\"456\">\r\n<!--\r\n\txyz \r\n-->\r\n<xyx></xyz></abc>", "abc")]
    public void Parser_ShouldBe_AsExpected(string input, string expected)
    {
        // Action
        var actual = TagToken.Parser.ParseOrThrow(input);

        // Assert
        actual.Should().BeOfType<TagToken>();
        actual.Value.Should().Be(expected);
    } 
}