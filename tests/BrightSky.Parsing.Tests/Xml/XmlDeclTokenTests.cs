using BrightSky.Parsing.Xml;
using Pidgin;

namespace BrightSky.Parsing.Tests.Xml;

public class XmlDeclTokenTests
{
    [Theory]
    [InlineData("<?xml?>", "xml")]
    [InlineData("<?xml ?>", "xml")]
    [InlineData("<? xml ?>", "xml")]
    [InlineData("<?xml abd=\"123\" ?>", "xml")]
    [InlineData("<?xml abd=\"123\" efg=\"546\" ?>", "xml")]
    [InlineData("<?xml abd = \"123\" ?>", "xml")]
    [InlineData("<?xml abd = \"123\" efg = \"546\" ?>", "xml")]
    [InlineData("<? xml abd=\"123\" ?>", "xml")]
    [InlineData("<? xml abd=\"123\" efg=\"546\" ?>", "xml")]
    [InlineData("<? xml abd = \"123\" ?>", "xml")]
    [InlineData("<? xml abd = \"123\" efg = \"546\" ?>", "xml")]
    public void Parser_ShouldBe_AsExpected(string input, string expected)
    {
        // Action
        var actual = XmlDeclToken.Parser.ParseOrThrow(input);

        // Assert
        actual.Should().BeOfType<XmlDeclToken>();
        actual.Value.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("#")]
    [InlineData("xml")]
    [InlineData("<?xml#>")]
    [InlineData("<#xml?>")]
    [InlineData("?xml?>")]
    [InlineData("<?xml?")]
    [InlineData("<xml?>")]
    [InlineData("<?xml>")]
    
    [InlineData("<?xml def=?>")]
    [InlineData("<?xml def=\"?>")]
    [InlineData("<?xml def=\"123?>")]
    [InlineData("<?xml =\"123\"?>")]
    public void Parser_ShouldThrowExactly_ParseException(string input)
    {
        // Action
        Action action = () => XmlDeclToken.Parser.ParseOrThrow(input);

        // Assert
        action.Should().ThrowExactly<ParseException>();
    } 
}