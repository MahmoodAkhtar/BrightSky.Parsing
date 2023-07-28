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

    [Theory]
    [InlineData(" ", 1)]
    [InlineData("  ", 1)]
    [InlineData("   ", 1)]
    public void Tokenize_WithOneOrMoreSpacesOnly_Should_Be_NonEscapedValueTokens(string input, int count)
    {
        // Action
        var actual = new CsvTokenizer().Tokenize(input);

        // Assert
        actual.Should().HaveCount(count);
        actual.First().Should().BeOfType<NonEscapedValueToken>();
        actual.First().Value.Should().Be(input);
    }
}