using Pidgin;

namespace BrightSky.Parsing.Xml;

internal record ClosingCommentTagToken : SyntaxNode
{
    internal ClosingCommentTagToken() : base("-->", 
        new SyntaxNode[] { new HyphenToken(), new HyphenToken(), new GtToken() })
    {
    }    
    
    internal static readonly Parser<char, ClosingCommentTagToken> Parser =
        HyphenToken.Parser.Then(HyphenToken.Parser).Then(GtToken.Parser).Map(_ => new ClosingCommentTagToken());
}