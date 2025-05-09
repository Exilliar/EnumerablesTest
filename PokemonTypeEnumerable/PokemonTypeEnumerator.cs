using System.Net;
using System.Text.Json;

namespace EnumerablesTest.PokemonTypeEnumerable;

public class PokemonTypeEnumerator : IAsyncEnumerator<PokemonType>
{
    private int Index = 0;

    private PokemonType? Current1;

    public async ValueTask<bool> MoveNextAsync()
    {
        Index++;

        try
        {
            string textResponse = await MakeRequest();
            if (string.IsNullOrEmpty(textResponse)) // sometimes the response is empty, likely due to rate limiting
            {
                await Task.Delay(1000); // wait one second and try again
                textResponse = await MakeRequest();
                if (string.IsNullOrEmpty(textResponse)) // if the response is still empty, just assume that the list is over, not worth setting up anything more complicated here
                    return false;
            }

            Current1 = JsonSerializer.Deserialize<PokemonType>(textResponse);
            return true;
        }
        catch (HttpRequestException e)
        {
            if (e.StatusCode == HttpStatusCode.NotFound)
                return false;

            throw new InvalidOperationException(e.Message);
        }
        catch (JsonException)
        {
            throw new InvalidOperationException("Invalid poke type response");
        }
    }

    private async Task<string> MakeRequest()
    {
        HttpClient client = new();
        HttpResponseMessage res = await client.GetAsync($"https://pokeapi.co/api/v2/type/{Index}");
        string textResponse = await res.Content.ReadAsStringAsync();
        client.Dispose();
        return textResponse;
    }

    PokemonType IAsyncEnumerator<PokemonType>.Current =>
        Current1 ?? throw new InvalidOperationException();

    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }
}
