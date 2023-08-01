﻿using Pidgin;
using BrightSky.Parsing.Xml;

namespace BrightSky.Parsing.Tests;

public class XmlNameTokenTests
{
    [Fact]
    public void Parser_ShouldBe_AsExpected()
    {
        // Action
        var actual = XmlNameToken.Parser.ParseOrThrow("xml");
        
        // Assert
        actual.Should().BeOfType<XmlNameToken>();
        actual.Value.Should().Be("xml");
    }
    
    [Fact]
    public void Parser_ShouldThrowExactly_ParseException()
    {
        // Action
        Action action = () => XmlNameToken.Parser.ParseOrThrow("");
        
        // Assert
        action.Should().ThrowExactly<ParseException>();
    }
}