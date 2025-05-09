using System.Collections;

namespace EnumerablesTest.PersonEnumerable;

public class PersonCollection(Person[] people) : IEnumerable<Person>
{
    private Person[] People = people;

    public IEnumerator<Person> GetEnumerator()
    {
        return new PersonEnumerator(People);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(Person person)
    {
        People = People.Append(person).ToArray();
    }
}
