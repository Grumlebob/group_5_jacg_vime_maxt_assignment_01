namespace Assignment1;
using System.Text.RegularExpressions;
public static class RegExpr
{
    
    // public static IEnumerable<string> SplitLine(IEnumerable<string> lines){
        
    // }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions) {
        
        var regex = new Regex("(?<width>[0-9]+)x(?<height>[0-9]+)");

        var matches = regex.Matches(resolutions);

        var output = new List<(int width, int height)>();
        
        foreach(Match match in matches) {
            var groups = match.Groups;

            output.Add((Int32.Parse(groups["width"].Value), Int32.Parse(groups["height"].Value)));
            
        }

        return output;
    }

//   {  public static IEnumerable<string> InnerText(string html, string tag) {
        
//     }

//     IEnumerable<(Uri url, string title)> Urls(string html);

// }
}
