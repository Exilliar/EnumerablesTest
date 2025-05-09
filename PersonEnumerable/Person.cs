namespace EnumerablesTest.PersonEnumerable;

public class Person(string name, int age)
{
    // ReSharper disable once MemberCanBePrivate.Global
    public readonly string Name = name;
    public readonly int Age = age;

    public override string ToString()
    {
        return $"{Name} is {Age} years old.";
    }
}
