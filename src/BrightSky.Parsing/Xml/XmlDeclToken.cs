using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal record XmlDeclToken : SyntaxNode
{
    internal XmlDeclToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
    
    internal static readonly Parser<char, XmlDeclToken> Parser = 
        from opening in LtQMarkToken.Parser
        from before in (
            from ws in Whitespace
            select ws).Many()
        from name in XmlNameToken.Parser
        from middle in (
            from ws in Whitespace
            select ws).Many()
        from attributes in (
            from attribute in Try(AttributeToken.Parser)
            select attribute).Many()
        from after in (
            from ws in Whitespace
            select ws).Many()
        from closing in QMarkGtToken.Parser
        select new XmlDeclToken(
            name.Value,
            OrganiseChildren(
                opening,
                before as char[] ?? before.ToArray(),
                name,
                middle as char[] ?? middle.ToArray(),
                attributes as AttributeToken[] ?? attributes.ToArray(),
                after as char[] ?? after.ToArray(),
                closing
            ));
    
    private static IEnumerable<SyntaxNode> OrganiseChildren (
        SyntaxNode opening,
        char[] before,
        SyntaxNode name,
        char[]  middle,
        AttributeToken[] attributes,
        char[]  after,
        SyntaxNode closing)
    {
        var list = new List<SyntaxNode>
        {
            opening
        };

        if (before.Any())
            list.Add(new WhitespacesToken(new string(before)));

        list.Add(name);
            
        if (middle.Any())
            list.Add(new WhitespacesToken(new string(middle)));
            
        if (attributes.Any())
            list.AddRange(attributes);
            
        if (after.Any())
            list.Add(new WhitespacesToken(new string(after)));
            
        list.Add(closing);
            
        return list;
    }
}