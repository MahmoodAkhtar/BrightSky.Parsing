using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

public static class XmlTokenizer
{
    public static SyntaxNode Tokenize(string input) => 
        Try(DocumentToken.Parser.Map(x => x as SyntaxNode))
            .Or(NodeToken.Parser.Map(x => x as SyntaxNode))
            .ParseOrThrow(input);
}