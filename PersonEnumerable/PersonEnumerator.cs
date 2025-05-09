using System.Collections;

namespace EnumerablesTest.PersonEnumerable;

public class PersonEnumerator(Person[] people) : IEnumerator<Person>
{
    private int CurrentIndex = -1;

    private object? Current1 => Current2;

    private Person Current2
    {
        get
        {
            try
            {
                return people[CurrentIndex];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public bool MoveNext()
    {
        CurrentIndex++;
        return CurrentIndex < people.Length;
    }

    public void Reset()
    {
        CurrentIndex = -1;
    }

    Person IEnumerator<Person>.Current => Current2;

    object? IEnumerator.Current => Current1;

    public void Dispose() { }
}
