using BrightSky.Parsing.Internal;
using Pidgin;
using static Pidgin.Parser<char>;

namespace BrightSky.Parsing.Xml;

internal record AttributeValueToken : SyntaxNode
{
    internal AttributeValueToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }

    internal static readonly Parser<char, AttributeValueToken> Parser =
        from opening in DqToken.Parser
        from value in new UntilFirstOfAnyString(new DqToken().Value)
        from closing in DqToken.Parser
        select new AttributeValueToken(value, new SyntaxNode[] { opening, new ValueToken(value), closing });
}