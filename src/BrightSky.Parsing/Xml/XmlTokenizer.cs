using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;

namespace BrightSky.Parsing.Xml;

public static class XmlTokenizer
{
    public static readonly Parser<char, LtToken> Lt = Char('<').ThenReturn(new LtToken());
    public static readonly Parser<char, GtToken> Gt = Char('>').ThenReturn(new GtToken());
    public static readonly Parser<char, EqToken> Eq = Char('=').ThenReturn(new EqToken());
    public static readonly Parser<char, DqToken> Dq = Char('"').ThenReturn(new DqToken());
    private static readonly Parser<char, XmlNameToken> XmlName = CIString("xml").Map(x => new XmlNameToken(x));
    private static readonly Parser<char, LtQMarkToken> LtQMark = String("<?").Map(_ => new LtQMarkToken());
    private static readonly Parser<char, QMarkGtToken> QMarkGt = String("?>").Map(_ => new QMarkGtToken());
 
    public static readonly Parser<char, ForwardSlashGtToken> ForwardSlashGt = String("/>")
        .Map(_ => new ForwardSlashGtToken());

    public static readonly Parser<char, LtForwardSlashToken> LtForwardSlash = String("</")
        .Map(_ => new LtForwardSlashToken());

    public static readonly Parser<char, AttributeValueToken> AttributeValue = 
        Token(c => c != '"').ManyString().Map(x => new AttributeValueToken(x));
        
    public static readonly Parser<char, TagToken> TagContent =
        Token(c => c != '<').ManyString().Map(x => new TagToken(x, Array.Empty<SyntaxNode>()));

    public static readonly Parser<char, IdentifierToken> Identifier =
        from first in Token(char.IsLetter)
            .Or(Char('_'))
            .Or(Char(':'))
        from rest in Token(char.IsLetterOrDigit)
            .Or(Char('.'))
            .Or(Char('-'))
            .Or(Char('_'))
            .Or(Char(':'))
            .ManyString()
        select new IdentifierToken(first + rest);
        
    public static readonly Parser<char, AttributeToken> Attribute =
        from before in (
            from ws in Whitespace
            select ws).Many()
        from name in Identifier
        from middle in (
            from ws in Whitespace 
            select ws).Many()
        from eq in Eq
        from after in (
            from ws in Whitespace 
            select ws).Many()
        from value in AttributeValue.Between(Dq)
        select new AttributeToken(
            name.Value, 
            AttributeTokenChildren(
                before as char[] ?? before.ToArray(),
                name,
                middle as char[] ?? middle.ToArray(),
                eq,
                after as char[] ?? after.ToArray(),
                new DqToken(),
                value,
                new DqToken()));

    private static IEnumerable<SyntaxNode> AttributeTokenChildren (
        char[] before,
        IdentifierToken name,
        char[] middle,
        EqToken eq,
        char[] after,
        DqToken first,
        AttributeValueToken value,
        DqToken second)
    {
        var list = new List<SyntaxNode>();

        if (before.Any())
            list.Add(new WhitespacesToken(new string(before)));

        list.Add(name);

        if (middle.Any())
            list.Add(new WhitespacesToken(new string(middle)));

        list.Add(eq);
            
        if (after.Any())
            list.Add(new WhitespacesToken(new string(after)));

        list.Add(first);
        list.Add(value);
        list.Add(second);
            
        return list;
    }
        
    public static readonly Parser<char, TagToken> EmptyTag =
        from opening in Lt
        from before in (
            from ws in Whitespace
            select ws).Many()
        from name in Identifier
        from middle in (
            from ws in Whitespace
            select ws).Many()
        from attributes in (
            from attribute in Try(Attribute)
            select attribute).Many()
        from after in (
            from ws in Whitespace 
            select ws).Many()
        from closing in ForwardSlashGt
        select new TagToken(
            name.Value,
            EmptyTagTokenChildren(
                opening, 
                before as char[] ?? before.ToArray(),
                name,
                middle as char[] ?? middle.ToArray(),
                attributes as AttributeToken[] ?? attributes.ToArray(), 
                after as char[] ?? after.ToArray(),
                closing));

    private static IEnumerable<SyntaxNode> EmptyTagTokenChildren (
        LtToken opening,
        char[] before,
        IdentifierToken name,
        char[] middle,
        AttributeToken[] attributes,
        char[] after,
        ForwardSlashGtToken closing)
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

    public static readonly Parser<char, OpeningTagToken> OpeningTag =
        from opening in Lt
        from before in (
            from ws in Whitespace
            select ws).Many()
        from name in Identifier
        from middle in (
            from ws in Whitespace
            select ws).Many()
        from attributes in (
            from attribute in Try(Attribute)
            select attribute).Many()
        from after in (
            from ws in Whitespace
            select ws).Many()
        from closing in Gt
        select new OpeningTagToken(
            name.Value,
            OpeningTagTokenChildren(
                opening,
                before as char[] ?? before.ToArray(),
                name,
                middle as char[] ?? middle.ToArray(),
                attributes as AttributeToken[] ?? attributes.ToArray(),
                after as char[] ?? after.ToArray(),
                closing));

    private static IEnumerable<SyntaxNode> OpeningTagTokenChildren (
        LtToken opening,
        char[] before,
        IdentifierToken name,
        char[]  middle,
        AttributeToken[] attributes,
        char[]  after,
        GtToken closing)
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

    public static readonly Parser<char, ClosingTagToken> ClosingTag = 
        from opening in LtForwardSlash
        from before in (
            from ws in Whitespace
            select ws).Many()            
        from name in Identifier
        from after in (
            from ws in Whitespace
            select ws).Many()
        from closing in Gt
        select new ClosingTagToken(
            name.Value,
            ClosingTagTokenChildren(
                opening,
                before as char[] ?? before.ToArray(),
                name,
                after as char[] ?? after.ToArray(),
                closing));

    private static IEnumerable<SyntaxNode> ClosingTagTokenChildren (
        LtForwardSlashToken opening,
        char[] before,
        IdentifierToken name,
        char[] after,
        GtToken closing)
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

    public static readonly Parser<char, TagToken> Tag =
        from opening in OpeningTag
        from before in (
            from ws in Whitespace
            select ws).Many()            
        from children in (
            from child in Try(Node)
            select child).Many()
        from after in (
            from ws in Whitespace
            select ws).Many()            
        from closing in ClosingTag
        select new TagToken(
            opening.Value,
            TagTokenChildren(
                opening, 
                before as char[] ?? before.ToArray(),
                children as TagToken[] ?? children.ToArray(), 
                after as char[] ?? after.ToArray(),
                closing));

    private static IEnumerable<SyntaxNode> TagTokenChildren (
        OpeningTagToken opening,
        char[] before,
        TagToken[] children,
        char[] after,
        ClosingTagToken closing)
    {
        var list = new List<SyntaxNode>
        {
            opening,
        };

        if (before.Any())
            list.Add(new WhitespacesToken(new string(before)));

        if (children.Any())
            list.AddRange(TypeTheTagTokens(children));
            
        if (after.Any())
            list.Add(new WhitespacesToken(new string(after)));
            
        list.Add(closing);
            
        return list;
    }

    private static IEnumerable<SyntaxNode> TypeTheTagTokens(IEnumerable<TagToken> tokens)
    {
        var list = new List<SyntaxNode>();

        foreach (var token in tokens)
        {
            if (token.Children.Any())
            {
                var last = token.Children.Last();
                switch (last)
                {
                    case ForwardSlashGtToken:
                        list.Add(new EmptyTagToken(token.Value, token.Children));
                        break;
                    case ClosingTagToken:
                        list.Add(token);
                        break;
                }
            }
            else
            {
                list.Add(new TagContentToken(token.Value));
            }
        }
            
        return list;
    }

    public static readonly Parser<char, XmlDeclToken> XmlDecl =
        from opening in LtQMark
        from before in (
            from ws in Whitespace
            select ws).Many()
        from name in XmlName
        from middle in (
            from ws in Whitespace
            select ws).Many()
        from attributes in (
            from attribute in Try(Attribute)
            select attribute).Many()
        from after in (
            from ws in Whitespace
            select ws).Many()
        from closing in QMarkGt
        select new XmlDeclToken(
            name.Value,
            XmlDeclTokenChildren(
                opening,
                before as char[] ?? before.ToArray(),
                name,
                middle as char[] ?? middle.ToArray(),
                attributes as AttributeToken[] ?? attributes.ToArray(),
                after as char[] ?? after.ToArray(),
                closing
                ));

    private static IEnumerable<SyntaxNode> XmlDeclTokenChildren (
        LtQMarkToken opening,
        char[] before,
        XmlNameToken name,
        char[]  middle,
        AttributeToken[] attributes,
        char[]  after,
        QMarkGtToken closing)
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

    private static readonly Parser<char, TagToken> Node = Try(Tag).Or(EmptyTag).Or(TagContent);
        
    public static TagToken Tokenize(string input) => Node.ParseOrThrow(input);
}