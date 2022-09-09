using Xunit;

namespace Assignment1.Tests;

public class RegExprTests
{
    
    //STARTER SETUP, ALSO EXPERIENCING WITH COPILOT.
    [Fact]
    public void Resolution_1920x1080_Returns_1920_1080()
    {
        // Arrange
        var resolutions = new[] { "1920x1080" };
        // Act
        var result = RegExpr.Resolution(resolutions);

        // Assert
        Assert.Equal(new[] { (1920, 1080) }, result);
        
    }


    [Fact]
    public void Resolution_1024x768_800x600_640x480_Returns_1024_768_800_600_640_480()
    {
        // Arrange
        var resolutions = new[] { "1024x768", "800x600", "640x480" };

        // Act
        var result = RegExpr.Resolution(resolutions);

        // Assert
        Assert.Equal(new[] { (1024, 768), (800, 600), (640, 480) }, result);
    }

    [Fact]
    public void Resolution_800x600_640x480_320x200_Returns_800_600_640_480_320_200()
    {
        // Arrange
        var resolutions = new[] { "800x600", "640x480", "320x200" };

        // Act
        var result = RegExpr.Resolution(resolutions);

        // Assert
        Assert.Equal(new[] { (800, 600), (640, 480), (320, 200) }, result);
    }

    [Fact]
    public void Resolution_1280x960_Returns_1280_960()
    {
        // Arrange
        var resolutions = new[] { "1280x960" };

        // Act
        var result = RegExpr.Resolution(resolutions);

        // Assert
        Assert.Equal(new[] { (1280, 960) }, result);
    }
}