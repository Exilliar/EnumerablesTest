using System.Collections;

namespace EnumerablesTest.CalcEnumerable;

public class CalcCollection(Func<int, int> action, int max, int start = 1) : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        return new CalcEnumerator(action, max, start);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}