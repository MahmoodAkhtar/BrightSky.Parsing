using BrightSky.Parsing.Xml;

namespace BrightSky.Parsing.Tests.Xml;


public class SyntaxNodeTests
{
    private record MockSyntaxNode : SyntaxNode
    {
        public MockSyntaxNode(string value, IEnumerable<SyntaxNode> children) : base(value, children)
        {
        }
    }
    
    [Fact]
    public void Equals_WithSameValueButEachWithoutChildren_ShouldBe_True()
    {
        // Arrange 
        var a = new MockSyntaxNode("x", Array.Empty<SyntaxNode>());
        var b = new MockSyntaxNode("x", Array.Empty<SyntaxNode>());

        // Act
        var actual = a.Equals(b);

        // Assert
        actual.Should().BeTrue();
    }
    
    
    [Fact]
    public void Equals_WithDifferentValueButEachWithoutChildren_ShouldBe_False()
    {
        // Arrange 
        var a = new MockSyntaxNode("x", Array.Empty<SyntaxNode>());
        var b = new MockSyntaxNode("y", Array.Empty<SyntaxNode>());

        // Act
        var actual = a.Equals(b);

        // Assert
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void Equals_WithSameValueAndEachWithSameChildren_ShouldBe_True()
    {
        // Arrange 
        var a = new MockSyntaxNode("x", new SyntaxNode[]
        {
            new MockSyntaxNode("child1", Array.Empty<SyntaxNode>()),
            new MockSyntaxNode("child2", Array.Empty<SyntaxNode>()),
            new MockSyntaxNode("child3", Array.Empty<SyntaxNode>()),
        });
        
        var b = new MockSyntaxNode("x", new SyntaxNode[]
        {
            new MockSyntaxNode("child1", Array.Empty<SyntaxNode>()),
            new MockSyntaxNode("child2", Array.Empty<SyntaxNode>()),
            new MockSyntaxNode("child3", Array.Empty<SyntaxNode>()),
        });

        // Act
        var actual = a.Equals(b);

        // Assert
        actual.Should().BeTrue();
    } 
    
    [Fact]
    public void Equals_WithSameValueAndDifferentChildren_ShouldBe_False()
    {
        // Arrange 
        var a = new MockSyntaxNode("x", new SyntaxNode[]
        {
            new MockSyntaxNode("child1", Array.Empty<SyntaxNode>()),
            new MockSyntaxNode("child2", Array.Empty<SyntaxNode>()),
            new MockSyntaxNode("child3", Array.Empty<SyntaxNode>()),
        });
        
        var b = new MockSyntaxNode("x", new SyntaxNode[]
        {
            new MockSyntaxNode("different", Array.Empty<SyntaxNode>()),
            new MockSyntaxNode("child2", Array.Empty<SyntaxNode>()),
            new MockSyntaxNode("child3", Array.Empty<SyntaxNode>()),
        });

        // Act
        var actual = a.Equals(b);

        // Assert
        actual.Should().BeFalse();
    } 
    
     
    [Fact]
    public void Equals_WithOtherAsNull_ShouldBe_False()
    {
        // Arrange 
        var a = new MockSyntaxNode("x", Array.Empty<SyntaxNode>());

        MockSyntaxNode b = null;

        // Act
        var actual = a.Equals(b);

        // Assert
        actual.Should().BeFalse();
    }    
}