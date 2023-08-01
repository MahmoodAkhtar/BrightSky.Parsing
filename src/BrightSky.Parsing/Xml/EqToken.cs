﻿using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal class EqToken : SyntaxNode
{
    internal EqToken() : base("=", Array.Empty<SyntaxNode>())
    {
    }
    
    internal static readonly Parser<char, EqToken> Parser = Char('=').ThenReturn(new EqToken());
}