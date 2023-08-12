using BrightSky.Parsing.Xml;
using Pidgin;

namespace BrightSky.Parsing.Tests.Xml;

public class CommentTagContentTokenTests
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
    public void Parser_ShouldBe_AsExpected(string input, string expected)
    {
        // Action
        var actual = CommentTagContentToken.Parser.ParseOrThrow(input);

        // Assert
        actual.Should().BeOfType<CommentTagContentToken>();
        actual.Value.Should().Be(expected);
    }
}