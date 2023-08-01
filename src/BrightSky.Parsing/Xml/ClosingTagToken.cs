using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal class ClosingTagToken : SyntaxNode
{
    internal ClosingTagToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
    
    internal static readonly Parser<char, ClosingTagToken> Parser = 
        from opening in LtForwardSlashToken.Parser
        from before in (
            from ws in Whitespace
            select ws).Many()
        from name in IdentifierToken.Parser
        from after in (
            from ws in Whitespace
            select ws).Many()
        from closing in GtToken.Parser
        select new ClosingTagToken(
            name.Value,
            OrganiseChildren(
                opening,
                before as char[] ?? before.ToArray(),
                name,
                after as char[] ?? after.ToArray(),
                closing));
    
    private static IEnumerable<SyntaxNode> OrganiseChildren (
        SyntaxNode opening,
        char[] before,
        SyntaxNode name,
        char[] after,
        SyntaxNode closing)
    {
        var list = new List<SyntaxNode>
        {
            opening
        };
            
        if (before.Any())
            list.Add(new WhitespacesToken(new string(before)));

        list.Add(name);
            
        if (after.Any())
            list.Add(new WhitespacesToken(new string(after)));

        list.Add(closing);

        return list;
    }
}