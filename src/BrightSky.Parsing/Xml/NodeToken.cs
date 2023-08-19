using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal static class NodeToken
{
    internal static readonly Parser<char, TagToken> Parser = 
        Try(TagToken.Parser)
            .Or(Try(EmptyTagToken.Parser).Or(CommentTagToken.Parser))
            .Or(TagContentToken.Parser);
}