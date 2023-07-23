using BrightSky.Parsing.Csv;

namespace BrightSky.Parsing.Tests.Csv;

public class CsvTokenizerTests
{
    [Theory]
    [InlineData("")]
    public void Tokenize_WithEmptyString_Should_BeEmpty(string input)
    {
        // Action
        var actual = new CsvTokenizer().Tokenize(input);

        // Assert
        actual.Should().BeEmpty();
    }
}