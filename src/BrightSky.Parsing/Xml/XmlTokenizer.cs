using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;

namespace BrightSky.Parsing.Xml;

public static class XmlTokenizer
{
    private static readonly Parser<char, LtToken> Lt = Char('<').ThenReturn(new LtToken());
    private static readonly Parser<char, GtToken> Gt = Char('>').ThenReturn(new GtToken());
    private static readonly Parser<char, EqToken> Eq = Char('=').ThenReturn(new EqToken());
    private static readonly Parser<char, DqToken> Dq = Char('"').ThenReturn(new DqToken());
    private static readonly Parser<char, HyphenToken> Hyphen = Char('-').ThenReturn(new HyphenToken());
    private static readonly Parser<char, ExcMarkToken> ExcMark = Char('!').ThenReturn(new ExcMarkToken());
    private static readonly Parser<char, XmlNameToken> XmlName = CIString("xml").Map(x => new XmlNameToken(x));
    private static readonly Parser<char, LtQMarkToken> LtQMark = String("<?").Map(_ => new LtQMarkToken());
    private static readonly Parser<char, QMarkGtToken> QMarkGt = String("?>").Map(_ => new QMarkGtToken());
 
    private static readonly Parser<char, ForwardSlashGtToken> ForwardSlashGt = String("/>")
        .Map(_ => new ForwardSlashGtToken());

    private static readonly Parser<char, LtForwardSlashToken> LtForwardSlash = String("</")
        .Map(_ => new LtForwardSlashToken());

    private static readonly Parser<char, AttributeValueToken> AttributeValue = 
        Token(c => c != '"').ManyString().Map(x => new AttributeValueToken(x));
        
    private static readonly Parser<char, TagToken> TagContent =
        Token(c => c != '<').ManyString().Map(x => new TagToken(x, Array.Empty<SyntaxNode>()));

    private static readonly Parser<char, IdentifierToken> Identifier =
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
        
    private static readonly Parser<char, AttributeToken> Attribute =
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
            AttributeToken.OrganiseChildren(
                before as char[] ?? before.ToArray(),
                name,
                middle as char[] ?? middle.ToArray(),
                eq,
                after as char[] ?? after.ToArray(),
                new DqToken(),
                value,
                new DqToken()));
        
    private static readonly Parser<char, TagToken> EmptyTag =
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
            EmptyTagToken.OrganiseChildren(
                opening, 
                before as char[] ?? before.ToArray(),
                name,
                middle as char[] ?? middle.ToArray(),
                attributes as AttributeToken[] ?? attributes.ToArray(), 
                after as char[] ?? after.ToArray(),
                closing));
    
    private static readonly Parser<char, OpeningCommentTagToken> OpeningCommentTag = 
        from opening in Lt
        from excMark in ExcMark
        from first in Hyphen
        from second in Hyphen
        select new OpeningCommentTagToken();
    
    private static readonly Parser<char, ClosingCommentTagToken> ClosingCommentTag = 
        from first in Hyphen
        from second in Hyphen
        from excMark in ExcMark
        from closing in Gt
        select new ClosingCommentTagToken();
          
    private static readonly Parser<char, CommentTagContentToken> CommentTagContent =
        Any.Between(OpeningCommentTag, ClosingCommentTag).ManyString().Map(x => new CommentTagContentToken(x));

    private static readonly Parser<char, TagToken> CommentTag =
        from comment in CommentTagContent
        select new TagToken(
            comment.Value,
            CommentTagToken.OrganiseChildren(
                new OpeningCommentTagToken(),
                comment,
                new ClosingCommentTagToken()));
    
    private static readonly Parser<char, OpeningTagToken> OpeningTag =
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
            OpeningTagToken.OrganiseChildren(
                opening,
                before as char[] ?? before.ToArray(),
                name,
                middle as char[] ?? middle.ToArray(),
                attributes as AttributeToken[] ?? attributes.ToArray(),
                after as char[] ?? after.ToArray(),
                closing));

    private static readonly Parser<char, ClosingTagToken> ClosingTag = 
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
            ClosingTagToken.OrganiseChildren(
                opening,
                before as char[] ?? before.ToArray(),
                name,
                after as char[] ?? after.ToArray(),
                closing));

    private static readonly Parser<char, TagToken> Tag =
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
            TagToken.OrganiseChildren(
                opening, 
                before as char[] ?? before.ToArray(),
                children as TagToken[] ?? children.ToArray(), 
                after as char[] ?? after.ToArray(),
                closing));
    
    private static readonly Parser<char, XmlDeclToken> XmlDecl =
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
            XmlDeclToken.OrganiseChildren(
                opening,
                before as char[] ?? before.ToArray(),
                name,
                middle as char[] ?? middle.ToArray(),
                attributes as AttributeToken[] ?? attributes.ToArray(),
                after as char[] ?? after.ToArray(),
                closing
                ));

    private static readonly Parser<char, TagToken> Node = Try(Tag).Or(EmptyTag).Or(TagContent).Or(CommentTag);
        
    public static TagToken Tokenize(string input) => Node.ParseOrThrow(input);
}