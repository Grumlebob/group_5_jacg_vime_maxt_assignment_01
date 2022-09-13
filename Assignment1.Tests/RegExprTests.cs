using Xunit;


namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void SplitLineTest()
    {
        //Arange
        IEnumerable<string> lines1 = new[] { "SMB", "Yeah Buddy", "Type Beat" };

        //Act
        IEnumerable<string> result1 = RegExpr.SplitLine(lines1);

        //Assert
        Assert.Equal(new[] { "SMB", "Yeah", "Buddy", "Type", "Beat" }, result1);
    }

    [Fact]
    public void ResolutionTest()
    {
        // Arrange
        IEnumerable<string> resolutions1 = new[] { "1920x1080" };
        IEnumerable<string> resolutions2 = new[] { "1024x768", "800x600", "640x480" };
        IEnumerable<string> resolutions3 = new[] { "800x600", "640x480", "320x200" };
        IEnumerable<string> resolutions4 = new[] { "1280x960" };

        // Act
        IEnumerable<(int width, int height)> result1 = RegExpr.Resolution(resolutions1);
        IEnumerable<(int width, int height)> result2 = RegExpr.Resolution(resolutions2);
        IEnumerable<(int width, int height)> result3 = RegExpr.Resolution(resolutions3);
        IEnumerable<(int width, int height)> result4 = RegExpr.Resolution(resolutions4);

        // Assert
        Assert.Equal(new[] { (1920, 1080) }, result1);
        Assert.Equal(new[] { (1024, 768), (800, 600), (640, 480) }, result2);
        Assert.Equal(new[] { (800, 600), (640, 480), (320, 200) }, result3);
        Assert.Equal(new[] { (1280, 960) }, result4);
    }

    [Fact]
    public void InnerTextTest()
    {
        // Arrange
        string html1 = @"<div>
        <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=""https://en.wikipedia.org/wiki/Theoretical_computer_science"" title=""Theoretical computer science"">theoretical computer science</a> and <a href=""https://en.wikipedia.org/wiki/Formal_language"" title=""Formal language"">formal language</a> theory, a sequence of <a href=""https://en.wikipedia.org/wiki/Character_(computing)"" title=""Character (computing)"">characters</a> that define a <i>search <a href=""https://en.wikipedia.org/wiki/Pattern_matching"" title=""Pattern matching"">pattern</a></i>. Usually this pattern is then used by <a href=""https://en.wikipedia.org/wiki/String_searching_algorithm"" title=""String searching algorithm"">string searching algorithms</a> for ""find"" or ""find and replace"" operations on <a href=""https://en.wikipedia.org/wiki/String_(computer_science)"" title=""String (computer science)"">strings</a>.</p>
        </div>";

        string html2 = @"<div>
        <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>
        </div>";

        // Act
        IEnumerable<string> result1 = RegExpr.InnerText(html1, "a");

        IEnumerable<string> result2 = RegExpr.InnerText(html2, "p");

        // Assert
        Assert.Equal(new[] { "theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings" }, result1);

        Assert.Equal(new[] { "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to." }, result2);

    }

    [Fact]
    public void UrlTest()
    {
        // Arrange
        string htmlTitle = @"<div>
        <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=""https://en.wikipedia.org/wiki/Theoretical_computer_science"" title=""Theoretical computer science"">theoretical computer science</a> and <a href=""https://en.wikipedia.org/wiki/Formal_language"" title=""Formal language"">formal language</a> theory, a sequence of <a href=""https://en.wikipedia.org/wiki/Character_(computing)"" title=""Character (computing)"">characters</a> that define a <i>search <a href=""https://en.wikipedia.org/wiki/Pattern_matching"" title=""Pattern matching"">pattern</a></i>. Usually this pattern is then used by <a href=""https://en.wikipedia.org/wiki/String_searching_algorithm"" title=""String searching algorithm"">string searching algorithms</a> for ""find"" or ""find and replace"" operations on <a href=""https://en.wikipedia.org/wiki/String_(computer_science)"" title=""String (computer science)"">strings</a>.</p>
        </div>";

        string htmlNoTitle = @"<div>
        <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=""https://en.wikipedia.org/wiki/Theoretical_computer_science"">theoretical computer science</a> and <a href=""https://en.wikipedia.org/wiki/Formal_language"">formal language</a> theory, a sequence of <a href=""https://en.wikipedia.org/wiki/Character_(computing)"">characters</a> that define a <i>search <a href=""https://en.wikipedia.org/wiki/Pattern_matching"">pattern</a></i>. Usually this pattern is then used by <a href=""https://en.wikipedia.org/wiki/String_searching_algorithm"">string searching algorithms</a> for ""find"" or ""find and replace"" operations on <a href=""https://en.wikipedia.org/wiki/String_(computer_science)"">strings</a>.</p>
        </div>";

        // Act
        IEnumerable<(Uri url, string title)> result1 = RegExpr.Urls(htmlTitle);

        IEnumerable<(Uri url, string title)> result2 = RegExpr.Urls(htmlNoTitle);

        // Assert
        Assert.Equal(new [] { (new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"),
        (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language"), 
        (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"),
        (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching"),
        (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"), "String searching algorithm"),
        (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"), "String (computer science)")
        }, result1);

        Assert.Equal(new [] { (new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "theoretical computer science"),
        (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "formal language"), 
        (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "characters"),
        (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "pattern"),
        (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"), "string searching algorithms"),
        (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"), "strings")
        }, result2);
    }
}