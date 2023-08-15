using BrightSky.Parsing.Xml;
using Pidgin;

namespace BrightSky.Parsing.Tests.Xml;

public class CommentTagTokenTests
{
    [Theory]
    [InlineData("<!---->", "")]
    [InlineData("<!-- -->", " ")]
    [InlineData("<!--x-->", "x")]
    [InlineData("<!-- x -->", " x ")]
    [InlineData("<!--xyz-->", "xyz")]
    [InlineData("<!-- xyz -->", " xyz ")]
    [InlineData("<!-- <> -->", " <> ")]
    [InlineData("<!-- x-y -->", " x-y ")]
    [InlineData("<!-- -- -->", " -- ")]
    [InlineData("<!-- <!-- -->", " <!-- ")]
    [InlineData("<!-- --> -->", " --> ")]
    [InlineData("<!-- <abc/> -->", " <abc/> ")]
    [InlineData("<!-- <abc></abc> -->", " <abc></abc> ")]
    [InlineData("<!-- <abc>xyz</abc> -->", " <abc>xyz</abc> ")]
    [InlineData("<!-- <abc><!----></abc> -->", " <abc><!----></abc> ")]
    [InlineData("<!-- <abc><!-- xyz --></abc> -->", " <abc><!-- xyz --></abc> ")]
    [InlineData("<!--\r\n\txyz \r\n-->", "\r\n\txyz \r\n")]
    public void Parser_ShouldBe_AsExpected(string input, string expected)
    {
        // Action
        var actual = CommentTagToken.Parser.ParseOrThrow(input);

        // Assert
        actual.Should().BeOfType<TagToken>();
        actual.Value.Should().Be(expected);
    }
}