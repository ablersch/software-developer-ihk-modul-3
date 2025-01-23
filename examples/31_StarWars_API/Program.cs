using System.Text.Json;
using StarWars;

var starship = GetStarshipFromApi(10);

Console.WriteLine($"Name: {starship?.Name}");

static Starship GetStarshipFromApi(int id)
{
    using var httpClient = new HttpClient();

    try
    {
        using var response = httpClient.GetAsync($"https://swapi.dev/api/starships/{id}").Result;

        response.EnsureSuccessStatusCode();

        return JsonSerializer.Deserialize<Starship>(response.Content.ReadAsStringAsync().Result);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return null;
    }
}