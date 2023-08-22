using BrightSky.Parsing.Internal;
using Pidgin;

namespace BrightSky.Parsing.Xml;

internal record CommentTagContentToken :SyntaxNode
{
    private CommentTagContentToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }

    internal static readonly Parser<char, CommentTagContentToken> Parser = OpeningCommentTagToken.Parser
        .Then(new UntilLastOfAnyString(new ClosingCommentTagToken().Value))
        .Map(x => new CommentTagContentToken(x));
}