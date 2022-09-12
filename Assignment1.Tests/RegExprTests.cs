using Xunit;
using FLuentAssertions;


namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void isSplitLineTest() {
        //Arange
        var lines1 = new [] {"SMB", "Yeah Buddy", "Type Beat"};

        //Act
        var result1 = RegExpr.SplitLine(lines1);

        //Assert
        result1.Should().Be()
    }   

    [Fact]
    public void isResolutionTest()
    {
        // Arrange
        var resolutions1 = new [] { "1920x1080" };
        var resolutions2 = new[] { "1024x768", "800x600", "640x480" };
        var resolutions3 = new[] { "800x600", "640x480", "320x200" };
        var resolutions4 = new[] { "1280x960" };

        // Act
        var result1 = RegExpr.Resolution(resolutions1);
        var result2 = RegExpr.Resolution(resolutions2);
        var result3 = RegExpr.Resolution(resolutions3);
        var result4 = RegExpr.Resolution(resolutions4);

        // Assert
        Assert.Equal(new[] { (1920, 1080) }, result1);
        Assert.Equal(new[] { (1024, 768), (800, 600), (640, 480) }, result2);
        Assert.Equal(new[] { (800, 600), (640, 480), (320, 200) }, result3);
        Assert.Equal(new[] { (1280, 960) }, result4);
    }
}