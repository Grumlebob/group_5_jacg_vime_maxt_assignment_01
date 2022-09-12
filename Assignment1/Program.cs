namespace Assignment1;

public class Program
{

    public static void Main(string[] arg)
    {
        foreach (var tuple in RegExpr.Resolution(Console.ReadLine())) {
            Console.WriteLine(tuple);
        }
        
    }

}