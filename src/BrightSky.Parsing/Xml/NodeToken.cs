﻿using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal static class NodeToken
{
    internal static readonly Parser<char, TagToken> Parser =
        Try(TagToken.Parser)
            .Or(Try(CommentTagToken.Parser).Or(EmptyTagToken.Parser))
            .Or(TagContentToken.Parser);
}