namespace EnumerablesTest.PokemonTypeEnumerable;

public class PokemonTypeCollection : IAsyncEnumerable<PokemonType>
{
    public IAsyncEnumerator<PokemonType> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken())
    {
        return new PokemonTypeEnumerator();
    }
}