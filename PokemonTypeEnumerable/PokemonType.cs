using System.Text.Json.Serialization;

namespace EnumerablesTest.PokemonTypeEnumerable;

public record PokemonType([property:JsonPropertyName("id")]int Id, [property:JsonPropertyName("name")]string Name)
{
    public override string ToString()
    {
        return $"{Id} - {Name}";
    }
}
