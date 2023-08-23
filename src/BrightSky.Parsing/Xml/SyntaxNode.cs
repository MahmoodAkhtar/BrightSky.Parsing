using BrightSky.Parsing.Internal;

namespace BrightSky.Parsing.Xml;

public record EmptySyntaxNode : SyntaxNode
{
    internal EmptySyntaxNode() : base(string.Empty, Array.Empty<SyntaxNode>())
    {
    }
}

public abstract record SyntaxNode
{
    public static SyntaxNode Empty => new EmptySyntaxNode();
    
    public string Value { get; }
    public IEquatableEnumeration<SyntaxNode> Children { get; }

    protected SyntaxNode(string value, IEnumerable<SyntaxNode> children)
    {
        Value = value;
        Children = new EquatableEnumeration<SyntaxNode>(children);
    }
}