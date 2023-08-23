using BrightSky.Parsing.Xml;

namespace BrightSky.Parsing.Tests.Xml;

public class XmlTokenizerTests
{
    [Theory]
    [InlineData("<")]
    public void Tokenize_LtToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new LtToken();
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);

        // Assert
        actual.Should().Be(expected);
    } 
    
    [Theory]
    [InlineData(">")]
    public void Tokenize_GtToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new GtToken();
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);

        // Assert
        actual.Should().Be(expected);
    } 
        
    [Theory]
    [InlineData("/")]
    public void Tokenize_ForwardSlashToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new ForwardSlashToken();
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);

        // Assert
        actual.Should().Be(expected);
    } 
    
    [Theory]
    [InlineData("</")]
    public void Tokenize_LtForwardSlashToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new LtForwardSlashToken();
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);

        // Assert
        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("/>")]
    public void Tokenize_ForwardSlashGtToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new ForwardSlashGtToken();
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);

        // Assert
        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("a")]
    [InlineData("_")]
    [InlineData(":")]
    [InlineData("abc")]
    [InlineData("_abc")]
    [InlineData(":abc")]
    [InlineData("abc_def")]
    [InlineData("abc:def")]
    public void Tokenize_IdentifierToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new IdentifierToken(input);
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);

        // Assert
        actual.Should().Be(expected);
    }
     
    [Theory]
    [InlineData("\"\"", "")]
    [InlineData("\" \"", " ")]
    [InlineData("\"abc\"", "abc")]
    [InlineData("\" a b c \"", " a b c ")]
    public void Tokenize_AttributeValueToken_ShouldBe_AsExpected(string input, string value)
    {
        // Arrange
        var expected = new AttributeValueToken(value);
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);

        // Assert
        actual.Should().Be(expected);
    }   
    
}