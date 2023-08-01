using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

public static class XmlTokenizer
{
    public static TagToken Tokenize(string input) => Try(DocumentToken.Parser).Or(NodeToken.Parser).ParseOrThrow(input);
}