using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

public static class XmlTokenizer
{
    public static IEnumerable<SyntaxNode> Tokenize(string input) =>
        Try(GtToken.Parser.Map(x => x as SyntaxNode))
            
            .Or(Whitespace.Map(x => new WhitespacesToken(x.ToString()) as SyntaxNode))
            
            .Or(Try(ForwardSlashGtToken.Parser.Map(x => x as SyntaxNode))
                .Or(ForwardSlashToken.Parser.Map(x => x as SyntaxNode)))
            
            .Or(Try(OpeningTagToken.Parser.Map(x => x as SyntaxNode))
                .Or(Try(ClosingTagToken.Parser.Map(x => x as SyntaxNode))
                    .Or(Try(CommentTagToken.Parser.Map(x => x as SyntaxNode))
                        .Or(Try(OpeningCommentTagToken.Parser.Map(x => x as SyntaxNode))
                            .Or(Try(ClosingCommentTagToken.Parser.Map(x => x as SyntaxNode))
                                .Or(Try(LtForwardSlashToken.Parser.Map(x => x as SyntaxNode))
                                    .Or(LtToken.Parser.Map(x => x as SyntaxNode))))))))
            
            .Or(Try(AttributeToken.Parser.Map(x => x as SyntaxNode))
                .Or(IdentifierToken.Parser.Map(x => x as SyntaxNode)))
            
            .Or(AttributeValueToken.Parser.Map(x => x as SyntaxNode))
            
            .Or(EqToken.Parser.Map(x => x as SyntaxNode))

            .Or(ExcMarkToken.Parser.Map(x => x as SyntaxNode))
            
            .Or(HyphenToken.Parser.Map(x => x as SyntaxNode))
            
            .Many()
            
            .ParseOrThrow(input);
}