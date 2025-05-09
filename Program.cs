using System.Collections;
using EnumerablesTest.BuiltInMethods;
using EnumerablesTest.PokemonTypeEnumerable;
using EnumerablesTest.PersonEnumerable;
using EnumerablesTest.CalcEnumerable;

Person[] people = [new("Rory", 25), new("John", 26), new("Jane", 27)];

PersonCollection personCollection = new(people);

Console.WriteLine("People collection by using a foreach");
foreach (Person person in personCollection)
{
    Console.WriteLine(person);
}

Console.WriteLine("\nPeople who are >25");

Console.WriteLine(string.Join(", ", personCollection.Where(p => p.Age > 25)));

Console.WriteLine("\nAdding a new person");

personCollection.Add(new Person("Jeremy", 24));

foreach (Person person in personCollection)
{
    Console.WriteLine(person);
}

Console.WriteLine("\nFirst two people:");
Console.WriteLine(string.Join(", ", personCollection.Take(2)));

Console.WriteLine("\nPeople collection by directly using the enumerator");
using IEnumerator<Person> enumerator = personCollection.GetEnumerator();
while (enumerator.MoveNext())
{
    Console.WriteLine(enumerator.Current);
}

Console.WriteLine("\nPeople collection using my custom foreach method");

CustomBase.ForEach(personCollection, person => Console.WriteLine(person));

Console.WriteLine("\nPeople collection using my custom select method");

IEnumerable<int> ages = personCollection.CustomSelect(person => person.Age);

Console.WriteLine(string.Join(", ", ages));

Console.WriteLine("\nCalc enumerable, adding one each time, max 5");

int AddOne(int i) => i + 1;

CalcCollection calcCollection = new(AddOne, 5, 0);

foreach (int result in calcCollection)
{
    Console.WriteLine(result);
}

const int max = 1024;

Console.WriteLine($"\nCalc enumerable, multiply by two each time, max {max}");

int MultiplyByTwo(int i) => i == 0 ? 1 : i * 2;

CalcCollection calcCollection2 = new(MultiplyByTwo, max, 0);

foreach (int result in calcCollection2)
{
    Console.WriteLine(result);
}

Console.WriteLine("\nMultiply calc enumerable, take 3");

Console.WriteLine(string.Join(", ", calcCollection2.Take(3)));

Console.WriteLine("\nMultiply calc enumerable, count");

Console.WriteLine(calcCollection2.Count());

// PokemonTypeCollection pokemonTypeCollection = new();
//
// await foreach (PokemonType pokemonType in pokemonTypeCollection)
// {
//     Console.WriteLine(pokemonType);
// }