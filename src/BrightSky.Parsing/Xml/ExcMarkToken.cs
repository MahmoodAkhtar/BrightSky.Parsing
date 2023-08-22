using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal record ExcMarkToken : SyntaxNode
{
    internal ExcMarkToken() : base("!", Array.Empty<SyntaxNode>())
    {
    }
    
    internal static readonly Parser<char, ExcMarkToken> Parser = Char('!').ThenReturn(new ExcMarkToken());
}