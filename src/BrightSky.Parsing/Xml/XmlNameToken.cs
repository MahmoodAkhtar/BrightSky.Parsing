using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal class XmlNameToken : SyntaxNode
{
    private XmlNameToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
    
    internal static readonly Parser<char, XmlNameToken> Parser =  CIString("xml").Map(x => new XmlNameToken(x));
}