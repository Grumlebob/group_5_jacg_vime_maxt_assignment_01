namespace Assignment1;

public static class Iterators
{
    static bool Even<t>(int i) => i % 2 == 0;
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
    {
        foreach (var item in items)
        {
            foreach (var i in item)
            {
                yield return i;
            }
        }
    } 

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
    {
        foreach (var item in items)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    } 
}