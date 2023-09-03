using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal static class NodeToken
{
    internal static readonly Parser<char, SyntaxNode> Parser =
        Try(TagToken.Parser.Map(x => x as SyntaxNode))
            .Or(Try(EmptyTagToken.Parser.Map(x => x as SyntaxNode))
                .Or(CommentTagToken.Parser.Map(x => x as SyntaxNode)))
            .Or(TagContentToken.Parser.Map(x => x as SyntaxNode));
}