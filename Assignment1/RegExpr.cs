namespace Assignment1;
using System.Text.RegularExpressions;
public static class RegExpr
{

    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {

        var regex = new Regex(@"(?P<words>\w+)");

        List<string> output = new List<string>();

        foreach (string line in lines)
        {
            foreach (Match match in regex.Matches(line))
            {
                yield return (match.Groups["words"].Value);
            }
        }

        
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions)
    {

        var regex = new Regex("(?<width>[0-9]+)x(?<height>[0-9]+)");

        var output = new List<(int width, int height)>();

        foreach (Match match in regex.Matches(resolutions))
        {
            var groups = match.Groups;

           yield return (Int32.Parse(groups["width"].Value), Int32.Parse(groups["height"].Value));

        }

       
    }

    public static IEnumerable<string> InnerText(string html, string tag)
    {
        var regex = new Regex("<" + tag + @"(?:.| )*?>(?<innerText>(?:\w| )*)<\/" + tag + ">");

        var output = new List<string>();

        foreach (Match match in regex.Matches(html))
        {
            yield return (match.Groups["innerText"].Value);
        }

       
    }

    IEnumerable<(Uri url, string title)> Urls(string html) {
            
    }
}
