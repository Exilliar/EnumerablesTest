using System.Collections;

namespace EnumerablesTest.CalcEnumerable;

public class CalcEnumerator(Func<int, int> action, int max, int start = 1) : IEnumerator<int>
{
    private object? Current1 => Current2;
    private int Current2 = start;

    public bool MoveNext()
    {
        Current2 = action(Current2);
        return Current2 <= max;
    }

    public void Reset()
    {
        Current2 = 1;
    }

    int IEnumerator<int>.Current => Current2;

    object? IEnumerator.Current => Current1;

    public void Dispose() {}
}