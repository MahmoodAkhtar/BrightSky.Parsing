using System.Text;

namespace BrightSky.Parsing.Xml;

public static class XmlWriter
{
    public static string Write(SyntaxNode node) => WriteSyntaxNode(node);
        
    private static string WriteTokenChildren(SyntaxNode token)
    {
        var sb = new StringBuilder();

        foreach (var child in token.Children)
            sb.Append(WriteSyntaxNode(child));

        return sb.ToString();
    }

    private static string WriteSyntaxNode(SyntaxNode node) => node switch
    {
        WhitespacesToken => node.Value,
        LtToken => node.Value,
        GtToken => node.Value,
        DqToken => node.Value,
        EqToken => node.Value,
        IdentifierToken => node.Value,
        AttributeValueToken => node.Value,
        ForwardSlashGtToken => node.Value,
        LtForwardSlashToken => node.Value,
        TagContentToken => node.Value,
        XmlNameToken => node.Value,
        QMarkToken => node.Value,
        LtQMarkToken => node.Value,
        QMarkGtToken => node.Value,
        AttributeToken token => WriteTokenChildren(token),
        EmptyTagToken token => WriteTokenChildren(token),
        OpeningTagToken token => WriteTokenChildren(token),
        ClosingTagToken token => WriteTokenChildren(token),
        TagToken token => WriteTokenChildren(token),
        XmlDeclToken token => WriteTokenChildren(token),
        _ => string.Empty
    };
}