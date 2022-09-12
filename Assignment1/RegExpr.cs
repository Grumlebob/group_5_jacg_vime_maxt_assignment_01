namespace Assignment1;
using System.Text.RegularExpressions;

public static class RegExpr
{

    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        Regex regex = new Regex(@"(?<word>\w+)");
        foreach (string line in lines)
        {
            foreach (Match match in regex.Matches(line))
            {
                yield return (match.Groups["word"].Value);
            }
        }


    }

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
    {
        Regex regex = new Regex("(?<width>[0-9]+)x(?<height>[0-9]+)");
        foreach (string line in resolutions)
        {
            foreach (Match match in regex.Matches(line))
            {
                GroupCollection groups = match.Groups;
                yield return (Int32.Parse(groups["width"].Value), Int32.Parse(groups["height"].Value));
            }
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag)
    {
        Regex regex = new Regex("<" + tag + @"(?:.)*?>(?<innerText>(?:.)*?)<\/" + tag + ">");
        foreach (Match match in regex.Matches(html))
        {
            yield return (Regex.Replace(match.Groups["innerText"].Value, "<[^>]+>", ""));
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html)
    {
        Regex regex = new Regex(@"(?:href=[""'])(?<url>.*?)[""'].*?(?: title=[""'](?<title>.*?)[""'])?.*?>(?<innerText>.*?)<");
        foreach (Match match in regex.Matches(html))
        {
            GroupCollection groups = match.Groups;
            if (groups["title"].Success)
            {
                yield return (new Uri(groups["url"].Value), groups["title"].Value);
            }
            else
            {
                yield return (new Uri(groups["url"].Value), groups["innerText"].Value);
            }
        }
    }
}
