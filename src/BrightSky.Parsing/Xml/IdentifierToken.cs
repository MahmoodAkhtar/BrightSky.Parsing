using Pidgin;
using static Pidgin.Parser<char>;

namespace BrightSky.Parsing.Xml;

internal record IdentifierToken : SyntaxNode
{
    private IdentifierToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
    
    internal static readonly Parser<char, IdentifierToken> Parser = 
        from first in Token(CharIsAllowableFirst)
        from rest in Token(CharIsAllowableRest).ManyString()
        select new IdentifierToken(first + rest);

    private static bool CharIsAllowableFirst(char c) =>
        new[] { '_', ':' }.Contains(c) || char.IsLetter(c);

    private static bool CharIsAllowableRest(char c) =>
        new[] { '.', '-', '_', ':' }.Contains(c) || char.IsLetterOrDigit(c);
}