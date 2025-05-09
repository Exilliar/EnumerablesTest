namespace EnumerablesTest.PersonEnumerable;

public class Person(string name, int age)
{
    public string Name = name;
    public int Age = age;

    public override string ToString()
    {
        return $"{Name} is {Age} years old.";
    }
}