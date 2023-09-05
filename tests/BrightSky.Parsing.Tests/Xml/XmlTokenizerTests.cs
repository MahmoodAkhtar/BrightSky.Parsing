using BrightSky.Parsing.Xml;

namespace BrightSky.Parsing.Tests.Xml;

public class XmlTokenizerTests
{
    [Theory]
    [InlineData("\"")]
    public void Tokenize_DqToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new DqToken() };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }    
 
    [Theory]
    [InlineData("\"\"\"", "")]
    public void Tokenize_DqToken_x3_ShouldBe_AsExpected(string input, string value)
    {
        // Arrange
        var expected = new SyntaxNode[]
        {
            new AttributeValueToken(value, new SyntaxNode[]
            {
                new DqToken(),
                new ValueToken(value),
                new DqToken()
            }),
            new DqToken()
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }     
  
    [Theory]
    [InlineData("\" \" \"", " ")]
    public void Tokenize_DqToken_x3_WithWhitespaces_ShouldBe_AsExpected(string input, string value)
    {
        // Arrange
        var expected = new SyntaxNode[]
        {
            new AttributeValueToken(value, new SyntaxNode[]
            {
                new DqToken(),
                new ValueToken(value),
                new DqToken()
            }),
            new WhitespacesToken(value),
            new DqToken()
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }  
    
    [Theory]
    [InlineData("<")]
    public void Tokenize_LtToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new LtToken() };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("<<<")]
    public void Tokenize_LtToken_x3_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new LtToken(), new LtToken(), new LtToken() };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData(">")]
    public void Tokenize_GtToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new GtToken() };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    } 
    
    [Theory]
    [InlineData(">>>")]
    public void Tokenize_GtToken_x3_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new GtToken(), new GtToken(), new GtToken() };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    } 
    
    [Theory]
    [InlineData("/")]
    public void Tokenize_ForwardSlashToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new ForwardSlashToken() };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    } 
    
     
    [Theory]
    [InlineData("///")]
    public void Tokenize_ForwardSlashToken_x3_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new ForwardSlashToken(), new ForwardSlashToken(), new ForwardSlashToken() };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("</")]
    public void Tokenize_LtForwardSlashToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new LtForwardSlashToken() };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("</</</")]
    public void Tokenize_LtForwardSlashToken_x3_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new LtForwardSlashToken(), new LtForwardSlashToken(), new LtForwardSlashToken() };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }  
    
    [Theory]
    [InlineData("/>")]
    public void Tokenize_ForwardSlashGtToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new ForwardSlashGtToken() };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
     
    [Theory]
    [InlineData("/>/>/>")]
    public void Tokenize_ForwardSlashGtToken_x3_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new ForwardSlashGtToken(), new ForwardSlashGtToken(), new ForwardSlashGtToken() };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("a")]
    [InlineData("_")]
    [InlineData(":")]
    [InlineData("abc")]
    [InlineData("_abc")]
    [InlineData(":abc")]
    [InlineData("abc_def")]
    [InlineData("abc:def")]
    public void Tokenize_IdentifierToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new IdentifierToken(input) };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("=")]
    public void Tokenize_EqToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new EqToken() };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("===")]
    public void Tokenize_EqToken_x3_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new EqToken(), new EqToken(), new EqToken() };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("\"\"", "")]
    [InlineData("\" \"", " ")]
    [InlineData("\"abc\"", "abc")]
    [InlineData("\" a b c \"", " a b c ")]
    public void Tokenize_AttributeValueToken_ShouldBe_AsExpected(string input, string value)
    {
        // Arrange
        var expected = new SyntaxNode[]
        {
            new AttributeValueToken(value, new SyntaxNode[]
            {
                new DqToken(),
                new ValueToken(value),
                new DqToken()
            })
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    } 
    
    [Theory]
    [InlineData("\"\"\"\"\"\"", "")]
    [InlineData("\" \"\" \"\" \"", " ")]
    [InlineData("\"abc\"\"abc\"\"abc\"", "abc")]
    [InlineData("\" a b c \"\" a b c \"\" a b c \"", " a b c ")]
    public void Tokenize_AttributeValueToken_x3_ShouldBe_AsExpected(string input, string value)
    {
        // Arrange
        var expected = new SyntaxNode[]
        {
            new AttributeValueToken(value, new SyntaxNode[]
            {
                new DqToken(),
                new ValueToken(value),
                new DqToken()
            }),
            new AttributeValueToken(value, new SyntaxNode[]
            {
                new DqToken(),
                new ValueToken(value),
                new DqToken()
            }),
            new AttributeValueToken(value, new SyntaxNode[]
            {
                new DqToken(),
                new ValueToken(value),
                new DqToken()
            })
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("a=\"x\"", "a", "x")]
    public void Tokenize_AttributeToken_ShouldBe_AsExpected(string input, string identifier, string value)
    {
        // Arrange
        var expected = new SyntaxNode[] 
        { 
            new AttributeToken(identifier, new SyntaxNode[]
            {
                new IdentifierToken(identifier),
                new EqToken(),
                new AttributeValueToken(value, new SyntaxNode[]
                {
                    new DqToken(),
                    new ValueToken(value),
                    new DqToken()
                })
            }) 
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
 
    [Theory]
    [InlineData("a=\"x\"a=\"x\"a=\"x\"", "a", "x")]
    public void Tokenize_AttributeToken_x3_ShouldBe_AsExpected(string input, string identifier, string value)
    {
        // Arrange
        var expected = new SyntaxNode[] 
        { 
            new AttributeToken(identifier, new SyntaxNode[]
            {
                new IdentifierToken(identifier),
                new EqToken(),
                new AttributeValueToken(value, new SyntaxNode[]
                {
                    new DqToken(),
                    new ValueToken(value),
                    new DqToken()
                })
            }), 
            new AttributeToken(identifier, new SyntaxNode[]
            {
                new IdentifierToken(identifier),
                new EqToken(),
                new AttributeValueToken(value, new SyntaxNode[]
                {
                    new DqToken(),
                    new ValueToken(value),
                    new DqToken()
                })
            }), 
            new AttributeToken(identifier, new SyntaxNode[]
            {
                new IdentifierToken(identifier),
                new EqToken(),
                new AttributeValueToken(value, new SyntaxNode[]
                {
                    new DqToken(),
                    new ValueToken(value),
                    new DqToken()
                })
            })
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }    
 
    [Theory]
    [InlineData("a=\"x\" a=\"x\" a=\"x\"", "a", "x")]
    public void Tokenize_AttributeToken_x3_WithWhitespaces_ShouldBe_AsExpected(string input, string identifier, string value)
    {
        // Arrange
        var expected = new SyntaxNode[] 
        { 
            new AttributeToken(identifier, new SyntaxNode[]
            {
                new IdentifierToken(identifier),
                new EqToken(),
                new AttributeValueToken(value, new SyntaxNode[]
                {
                    new DqToken(),
                    new ValueToken(value),
                    new DqToken()
                })
            }), 
            new WhitespacesToken(" "),
            new AttributeToken(identifier, new SyntaxNode[]
            {
                new IdentifierToken(identifier),
                new EqToken(),
                new AttributeValueToken(value, new SyntaxNode[]
                {
                    new DqToken(),
                    new ValueToken(value),
                    new DqToken()
                })
            }), 
            new WhitespacesToken(" "),
            new AttributeToken(identifier, new SyntaxNode[]
            {
                new IdentifierToken(identifier),
                new EqToken(),
                new AttributeValueToken(value, new SyntaxNode[]
                {
                    new DqToken(),
                    new ValueToken(value),
                    new DqToken()
                })
            })
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }     

    [Theory]
    [InlineData("a = \"x\"", "a", "x", " ")]
    public void Tokenize_AttributeTokenWithWhitespaces_ShouldBe_AsExpected(string input, string identifier, string value, string ws)
    {
        // Arrange
        var expected = new SyntaxNode[] 
        { 
            new AttributeToken(identifier, new SyntaxNode[]
            {
                new IdentifierToken(identifier),
                new WhitespacesToken(ws),
                new EqToken(),
                new WhitespacesToken(ws),
                new AttributeValueToken(value, new SyntaxNode[]
                {
                    new DqToken(),
                    new ValueToken(value),
                    new DqToken()
                })
            }) 
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("a = \"x\" a = \"x\" a = \"x\"", "a", "x", " ")]
    public void Tokenize_AttributeTokenWithWhitespaces_x3_WithWhitespaaces_ShouldBe_AsExpected(string input, string identifier, string value, string ws)
    {
        // Arrange
        var expected = new SyntaxNode[] 
        { 
            new AttributeToken(identifier, new SyntaxNode[]
            {
                new IdentifierToken(identifier),
                new WhitespacesToken(ws),
                new EqToken(),
                new WhitespacesToken(ws),
                new AttributeValueToken(value, new SyntaxNode[]
                {
                    new DqToken(),
                    new ValueToken(value),
                    new DqToken()
                })
            }),
            new WhitespacesToken(ws),
            new AttributeToken(identifier, new SyntaxNode[]
            {
                new IdentifierToken(identifier),
                new WhitespacesToken(ws),
                new EqToken(),
                new WhitespacesToken(ws),
                new AttributeValueToken(value, new SyntaxNode[]
                {
                    new DqToken(),
                    new ValueToken(value),
                    new DqToken()
                })
            }),
            new WhitespacesToken(ws),
            new AttributeToken(identifier, new SyntaxNode[]
            {
                new IdentifierToken(identifier),
                new WhitespacesToken(ws),
                new EqToken(),
                new WhitespacesToken(ws),
                new AttributeValueToken(value, new SyntaxNode[]
                {
                    new DqToken(),
                    new ValueToken(value),
                    new DqToken()
                })
            }),
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }   

    [Theory]
    [InlineData("<abc>", "abc")]
    public void Tokenize_OpeningTagToken_ShouldBe_AsExpected(string input, string identifier)
    {
        // Arrange
        var expected = new SyntaxNode[] 
        { 
            new OpeningTagToken(identifier, new SyntaxNode[]
            {
                new LtToken(),
                new IdentifierToken(identifier),
                new GtToken()
            }) 
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("<abc><abc><abc>", "abc")]
    public void Tokenize_OpeningTagToken_x3_ShouldBe_AsExpected(string input, string identifier)
    {
        // Arrange
        var expected = new SyntaxNode[] 
        { 
            new OpeningTagToken(identifier, new SyntaxNode[]
            {
                new LtToken(),
                new IdentifierToken(identifier),
                new GtToken()
            }),
            new OpeningTagToken(identifier, new SyntaxNode[]
            {
                new LtToken(),
                new IdentifierToken(identifier),
                new GtToken()
            }),
            new OpeningTagToken(identifier, new SyntaxNode[]
            {
                new LtToken(),
                new IdentifierToken(identifier),
                new GtToken()
            })
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("<abc> <abc> <abc>", "abc")]
    public void Tokenize_OpeningTagToken_x3_WithWhitespaces_ShouldBe_AsExpected(string input, string identifier)
    {
        // Arrange
        var expected = new SyntaxNode[] 
        { 
            new OpeningTagToken(identifier, new SyntaxNode[]
            {
                new LtToken(),
                new IdentifierToken(identifier),
                new GtToken()
            }),
            new WhitespacesToken(" "),
            new OpeningTagToken(identifier, new SyntaxNode[]
            {
                new LtToken(),
                new IdentifierToken(identifier),
                new GtToken()
            }),
            new WhitespacesToken(" "),
            new OpeningTagToken(identifier, new SyntaxNode[]
            {
                new LtToken(),
                new IdentifierToken(identifier),
                new GtToken()
            })
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }   
    
    [Theory]
    [InlineData("<abc a=\"x\">", "abc", "a", "x")]
    public void Tokenize_OpeningTagTokenWithAttributeToken_ShouldBe_AsExpected(string input, string identifier1, string identifier2, string value)
    {
        // Arrange
        var expected = new SyntaxNode[] 
        { 
            new OpeningTagToken(identifier1, new SyntaxNode[]
            {
                new LtToken(),
                new IdentifierToken(identifier1),
                new WhitespacesToken(" "),
                new AttributeToken(identifier2, new SyntaxNode[]
                {
                    new IdentifierToken(identifier2),
                    new EqToken(),
                    new AttributeValueToken(value, new SyntaxNode[]
                    {
                        new DqToken(),
                        new ValueToken(value),
                        new DqToken()
                    })
                }),
                new GtToken()
            }) 
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("<abc a=\"x\"><abc a=\"x\"><abc a=\"x\">", "abc", "a", "x")]
    public void Tokenize_OpeningTagTokenWithAttributeToken_x3_ShouldBe_AsExpected(string input, string identifier1, string identifier2, string value)
    {
        // Arrange
        var expected = new SyntaxNode[] 
        { 
            new OpeningTagToken(identifier1, new SyntaxNode[]
            {
                new LtToken(),
                new IdentifierToken(identifier1),
                new WhitespacesToken(" "),
                new AttributeToken(identifier2, new SyntaxNode[]
                {
                    new IdentifierToken(identifier2),
                    new EqToken(),
                    new AttributeValueToken(value, new SyntaxNode[]
                    {
                        new DqToken(),
                        new ValueToken(value),
                        new DqToken()
                    })
                }),
                new GtToken()
            }),
            new OpeningTagToken(identifier1, new SyntaxNode[]
            {
                new LtToken(),
                new IdentifierToken(identifier1),
                new WhitespacesToken(" "),
                new AttributeToken(identifier2, new SyntaxNode[]
                {
                    new IdentifierToken(identifier2),
                    new EqToken(),
                    new AttributeValueToken(value, new SyntaxNode[]
                    {
                        new DqToken(),
                        new ValueToken(value),
                        new DqToken()
                    })
                }),
                new GtToken()
            }),
            new OpeningTagToken(identifier1, new SyntaxNode[]
            {
                new LtToken(),
                new IdentifierToken(identifier1),
                new WhitespacesToken(" "),
                new AttributeToken(identifier2, new SyntaxNode[]
                {
                    new IdentifierToken(identifier2),
                    new EqToken(),
                    new AttributeValueToken(value, new SyntaxNode[]
                    {
                        new DqToken(),
                        new ValueToken(value),
                        new DqToken()
                    })
                }),
                new GtToken()
            })
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("<abc a=\"x\"> <abc a=\"x\"> <abc a=\"x\">", "abc", "a", "x")]
    public void Tokenize_OpeningTagTokenWithAttributeToken_x3_WithWhitespaces_ShouldBe_AsExpected(string input, string identifier1, string identifier2, string value)
    {
        // Arrange
        var expected = new SyntaxNode[] 
        { 
            new OpeningTagToken(identifier1, new SyntaxNode[]
            {
                new LtToken(),
                new IdentifierToken(identifier1),
                new WhitespacesToken(" "),
                new AttributeToken(identifier2, new SyntaxNode[]
                {
                    new IdentifierToken(identifier2),
                    new EqToken(),
                    new AttributeValueToken(value, new SyntaxNode[]
                    {
                        new DqToken(),
                        new ValueToken(value),
                        new DqToken()
                    })
                }),
                new GtToken()
            }),
            new WhitespacesToken(" "),
            new OpeningTagToken(identifier1, new SyntaxNode[]
            {
                new LtToken(),
                new IdentifierToken(identifier1),
                new WhitespacesToken(" "),
                new AttributeToken(identifier2, new SyntaxNode[]
                {
                    new IdentifierToken(identifier2),
                    new EqToken(),
                    new AttributeValueToken(value, new SyntaxNode[]
                    {
                        new DqToken(),
                        new ValueToken(value),
                        new DqToken()
                    })
                }),
                new GtToken()
            }),
            new WhitespacesToken(" "),
            new OpeningTagToken(identifier1, new SyntaxNode[]
            {
                new LtToken(),
                new IdentifierToken(identifier1),
                new WhitespacesToken(" "),
                new AttributeToken(identifier2, new SyntaxNode[]
                {
                    new IdentifierToken(identifier2),
                    new EqToken(),
                    new AttributeValueToken(value, new SyntaxNode[]
                    {
                        new DqToken(),
                        new ValueToken(value),
                        new DqToken()
                    })
                }),
                new GtToken()
            })
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("</abc>", "abc")]
    public void Tokenize_ClosingTagToken_ShouldBe_AsExpected(string input, string identifier)
    {
        // Arrange
        var expected = new SyntaxNode[] 
        { 
            new ClosingTagToken(identifier, new SyntaxNode[]
            {
                new LtForwardSlashToken(),
                new IdentifierToken(identifier),
                new GtToken()
            }) 
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("</abc></abc></abc>", "abc")]
    public void Tokenize_ClosingTagToken_x3_ShouldBe_AsExpected(string input, string identifier)
    {
        // Arrange
        var expected = new SyntaxNode[] 
        { 
            new ClosingTagToken(identifier, new SyntaxNode[]
            {
                new LtForwardSlashToken(),
                new IdentifierToken(identifier),
                new GtToken()
            }), 
            new ClosingTagToken(identifier, new SyntaxNode[]
            {
                new LtForwardSlashToken(),
                new IdentifierToken(identifier),
                new GtToken()
            }) ,
            new ClosingTagToken(identifier, new SyntaxNode[]
            {
                new LtForwardSlashToken(),
                new IdentifierToken(identifier),
                new GtToken()
            }) 
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("</abc> </abc> </abc>", "abc")]
    public void Tokenize_ClosingTagToken_x3_WithWhitespaces_ShouldBe_AsExpected(string input, string identifier)
    {
        // Arrange
        var expected = new SyntaxNode[] 
        { 
            new ClosingTagToken(identifier, new SyntaxNode[]
            {
                new LtForwardSlashToken(),
                new IdentifierToken(identifier),
                new GtToken()
            }), 
            new WhitespacesToken(" "),
            new ClosingTagToken(identifier, new SyntaxNode[]
            {
                new LtForwardSlashToken(),
                new IdentifierToken(identifier),
                new GtToken()
            }) ,
            new WhitespacesToken(" "),
            new ClosingTagToken(identifier, new SyntaxNode[]
            {
                new LtForwardSlashToken(),
                new IdentifierToken(identifier),
                new GtToken()
            }) 
        };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    } 
    
    [Theory]
    [InlineData("!")]
    public void Tokenize_ExcMarkToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new ExcMarkToken() };
        
        // Action
        var actual =  XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("!!!")]
    public void Tokenize_ExcMarkToken_x3_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new ExcMarkToken(), new ExcMarkToken(), new ExcMarkToken() };
        
        // Action
        var actual = XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("-")]
    public void Tokenize_HyphenToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new HyphenToken() };
        
        // Action
        var actual = XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
     
    [Theory]
    [InlineData("---")]
    public void Tokenize_HyphenToken_x3_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new HyphenToken(), new HyphenToken(), new HyphenToken() };
        
        // Action
        var actual = XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }  
     
    [Theory]
    [InlineData("- - -")]
    public void Tokenize_HyphenToken_x3_WithWhitespaces_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[]
        {
            new HyphenToken(),
            new WhitespacesToken(" "),
            new HyphenToken(),
            new WhitespacesToken(" "),
            new HyphenToken()
        };
        
        // Action
        var actual = XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("<!--")]
    public void Tokenize_OpeningCommentTagToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new OpeningCommentTagToken() };
        
        // Action
        var actual = XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("<!--<!--<!--")]
    public void Tokenize_OpeningCommentTagToken_x3_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[]
        {
            new OpeningCommentTagToken(),
            new OpeningCommentTagToken(),
            new OpeningCommentTagToken()
        };
        
        // Action
        var actual = XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }    
    
    [Theory]
    [InlineData("<!-- <!-- <!--")]
    public void Tokenize_OpeningCommentTagToken_x3_WithWhitespaces_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[]
        {
            new OpeningCommentTagToken(),
            new WhitespacesToken(" "),
            new OpeningCommentTagToken(),
            new WhitespacesToken(" "),
            new OpeningCommentTagToken()
        };
        
        // Action
        var actual = XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("-->")]
    public void Tokenize_ClosingCommentTagToken_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[] { new ClosingCommentTagToken() };
        
        // Action
        var actual = XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("-->-->-->")]
    public void Tokenize_ClosingCommentTagToken_x3_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[]
        {
            new ClosingCommentTagToken(),
            new ClosingCommentTagToken(),
            new ClosingCommentTagToken()
        };
        
        // Action
        var actual = XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("--> --> -->")]
    public void Tokenize_ClosingCommentTagToken_x3_WithWhitespaces_ShouldBe_AsExpected(string input)
    {
        // Arrange
        var expected = new SyntaxNode[]
        {
            new ClosingCommentTagToken(),
            new WhitespacesToken(" "),
            new ClosingCommentTagToken(),
            new WhitespacesToken(" "),
            new ClosingCommentTagToken()
        };
        
        // Action
        var actual = XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("<!---->", "")]
    [InlineData("<!-- -->", " ")]
    [InlineData("<!--x-->", "x")]
    [InlineData("<!-- x -->", " x ")]
    [InlineData("<!--xyz-->", "xyz")]
    [InlineData("<!-- xyz -->", " xyz ")]
    [InlineData("<!-- <> -->", " <> ")]
    [InlineData("<!-- x-y -->", " x-y ")]
    [InlineData("<!-- -- -->", " -- ")]
    [InlineData("<!-- <!-- -->", " <!-- ")]
    [InlineData("<!-- --> -->", " --> ")]
    [InlineData("<!-- <abc/> -->", " <abc/> ")]
    [InlineData("<!-- <abc></abc> -->", " <abc></abc> ")]
    [InlineData("<!-- <abc>xyz</abc> -->", " <abc>xyz</abc> ")]
    [InlineData("<!-- <abc><!----></abc> -->", " <abc><!----></abc> ")]
    [InlineData("<!-- <abc><!-- xyz --></abc> -->", " <abc><!-- xyz --></abc> ")]
    [InlineData("<!--\r\n\txyz \r\n-->", "\r\n\txyz \r\n")]
    public void Tokenize_CommentTagToken_ShouldBe_AsExpected(string input, string value)
    {
        // Arrange
        var expected = new SyntaxNode[]
        {
            new CommentTagToken(value, new SyntaxNode[]
            {
                new OpeningCommentTagToken(),
                new CommentTagContentToken(value),
                new ClosingCommentTagToken()
            })
        };
        
        // Action
        var actual = XmlTokenizer.Tokenize(input);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("<?xml?>", "xml")]
    public void Tokenize_XmlDeclToken_ShouldBe_AsExpected(string input, string value)
    {
        // Arrange
        var expected = new SyntaxNode[]
        {
            new XmlDeclToken(value, new SyntaxNode[]
            {
                new LtQMarkToken(),
                new XmlNameToken(value),
                new QMarkGtToken()
            })
        };
        
        // Action
        var actual = XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }    
 
    [Theory]
    [InlineData("<?xml?><?xml?><?xml?>", "xml")]
    public void Tokenize_XmlDeclToken_x3_ShouldBe_AsExpected(string input, string value)
    {
        // Arrange
        var expected = new SyntaxNode[]
        {
            new XmlDeclToken(value, new SyntaxNode[]
            {
                new LtQMarkToken(),
                new XmlNameToken(value),
                new QMarkGtToken()
            }),
            new XmlDeclToken(value, new SyntaxNode[]
            {
                new LtQMarkToken(),
                new XmlNameToken(value),
                new QMarkGtToken()
            }),
            new XmlDeclToken(value, new SyntaxNode[]
            {
                new LtQMarkToken(),
                new XmlNameToken(value),
                new QMarkGtToken()
            })
        };
        
        // Action
        var actual = XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
 
    [Theory]
    [InlineData("<?xml?> <?xml?> <?xml?>", "xml")]
    public void Tokenize_XmlDeclToken_x3_WithWhitespaces_ShouldBe_AsExpected(string input, string value)
    {
        // Arrange
        var expected = new SyntaxNode[]
        {
            new XmlDeclToken(value, new SyntaxNode[]
            {
                new LtQMarkToken(),
                new XmlNameToken(value),
                new QMarkGtToken()
            }),
            new WhitespacesToken(" "),
            new XmlDeclToken(value, new SyntaxNode[]
            {
                new LtQMarkToken(),
                new XmlNameToken(value),
                new QMarkGtToken()
            }),
            new WhitespacesToken(" "),
            new XmlDeclToken(value, new SyntaxNode[]
            {
                new LtQMarkToken(),
                new XmlNameToken(value),
                new QMarkGtToken()
            })
        };
        
        // Action
        var actual = XmlTokenizer.Tokenize(input);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}