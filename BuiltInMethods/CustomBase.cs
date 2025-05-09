namespace EnumerablesTest.BuiltInMethods;

public static class CustomBase
{
    /// <summary>
    /// Example of how (I think) the foreach is/could work under the hood
    /// </summary>
    /// <param name="collection">The enumerable collection to iterate over</param>
    /// <param name="action">The action to run on each item in the collection</param>
    /// <typeparam name="T">The type of items in the collection</typeparam>
    public static void ForEach<T>(IEnumerable<T> collection, Action<T> action)
    {
        using IEnumerator<T> enumerator = collection.GetEnumerator();
        while (enumerator.MoveNext())
        {
            action(enumerator.Current);
        }
    }

    /// <summary>
    /// Example of how (I think) the Linq Select method could work under the hood
    /// </summary>
    /// <param name="collection">The enumerable collection to iterate over</param>
    /// <param name="func">The function to run on each item in the collection</param>
    /// <typeparam name="TIn">The type of the items in the collection</typeparam>
    /// <typeparam name="TOut">The output types</typeparam>
    /// <returns>A new enumerable with the outputs of the func on each item in the input collection</returns>
    public static IEnumerable<TOut> CustomSelect<TIn, TOut>(this IEnumerable<TIn> collection, Func<TIn, TOut> func)
    {
        using IEnumerator<TIn> enumerator = collection.GetEnumerator();
        while (enumerator.MoveNext())
        {
            yield return func(enumerator.Current);
        }
    }
}