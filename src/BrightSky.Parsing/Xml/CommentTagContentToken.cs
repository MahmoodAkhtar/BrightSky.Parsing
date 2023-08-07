using BrightSky.Parsing.Internal;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;

namespace BrightSky.Parsing.Xml;

internal class CommentTagContentToken :SyntaxNode
{
    private CommentTagContentToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }

    internal static readonly Parser<char, CommentTagContentToken> Parser =
        OpeningCommentTagToken.Parser.Then(
            Try(new AnyStringExcept(new ClosingCommentTagToken().Value))
            .Or(Any.Until(ClosingCommentTagToken.Parser).Map(x => string.Join("", x)))
            .Map(x => new CommentTagContentToken(x)));
}