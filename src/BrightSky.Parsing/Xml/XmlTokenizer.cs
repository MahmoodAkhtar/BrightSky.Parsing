using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

public static class XmlTokenizer
{
    public static SyntaxNode Tokenize(string input) =>
        Try(OpeningTagToken.Parser.Map(x => x as SyntaxNode))
            .Or(Try(LtForwardSlashToken.Parser.Map(x => x as SyntaxNode))
                .Or(LtToken.Parser.Map(x => x as SyntaxNode)))
            
            .Or(GtToken.Parser.Map(x => x as SyntaxNode))
            
            .Or(Try(ForwardSlashGtToken.Parser.Map(x => x as SyntaxNode))
                .Or(ForwardSlashToken.Parser.Map(x => x as SyntaxNode)))
            
            .Or(Try(AttributeToken.Parser.Map(x => x as SyntaxNode))
                .Or(IdentifierToken.Parser.Map(x => x as SyntaxNode))
                .Or(EqToken.Parser.Map(x => x as SyntaxNode))
                .Or(AttributeValueToken.Parser.Map(x => x as SyntaxNode)))
            
            .ParseOrThrow(input);
}