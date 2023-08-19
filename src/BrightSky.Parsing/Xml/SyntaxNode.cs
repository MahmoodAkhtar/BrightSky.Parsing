namespace BrightSky.Parsing.Xml;

public class EmptySyntaxNode : SyntaxNode
{
    internal EmptySyntaxNode() : base(string.Empty, Array.Empty<SyntaxNode>())
    {
    }
}

public abstract class SyntaxNode : IEquatable<SyntaxNode>
{
    protected static SyntaxNode Empty => new EmptySyntaxNode();
    
    public string Value { get; }
    public IEnumerable<SyntaxNode> Children { get; }

    protected SyntaxNode(string value, IEnumerable<SyntaxNode> children)
    {
        Value = value;
        Children = children;
    }

    public bool Equals(SyntaxNode? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value && Children.Equals(other.Children);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((SyntaxNode)obj);
    }

    public override int GetHashCode() => HashCode.Combine(Value, Children);
}