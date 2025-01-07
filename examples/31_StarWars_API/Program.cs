using System.Text.Json;
using StarWars;

var people = GetPeopleFromApi(10);

Console.WriteLine($"Name: {people?.Name}");

static People GetPeopleFromApi(int id)
{
    using var httpClient = new HttpClient();

    try
    {
        using var response = httpClient.GetAsync($"https://swapi.dev/api/people/{id}").Result;

        response.EnsureSuccessStatusCode();

        return JsonSerializer.Deserialize<People>(response.Content.ReadAsStringAsync().Result);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return null;
    }
}