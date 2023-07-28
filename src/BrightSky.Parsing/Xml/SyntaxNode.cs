namespace BrightSky.Parsing.Xml;

public abstract class SyntaxNode : IEquatable<SyntaxNode>
{
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

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, Children);
    }
}