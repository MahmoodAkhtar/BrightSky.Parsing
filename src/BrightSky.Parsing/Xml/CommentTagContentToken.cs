using Pidgin;
using static Pidgin.Parser<char>;

namespace BrightSky.Parsing.Xml;

internal class CommentTagContentToken :SyntaxNode
{
    private CommentTagContentToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
 
    internal static readonly Parser<char, CommentTagContentToken> Parser = 
        Any.Between(OpeningCommentTagToken.Parser, ClosingCommentTagToken.Parser)
            .ManyString()
            .Map(x => new CommentTagContentToken(x));

}