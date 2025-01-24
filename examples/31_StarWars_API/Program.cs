using System.Text.Json;
using StarWars;

var starship = GetStarshipFromApi(10);

Console.WriteLine($"Name: {starship?.Name}");

static Starship GetStarshipFromApi(int id)
{
    using var httpClient = new HttpClient();
    using var response = httpClient.GetAsync($"https://swapi.dev/api/starships/{id}").Result;

    // Alternative 1
    //string response = httpClient.GetStringAsync(new Uri(url)).Result;
    //var result = JsonSerializer.Deserialize<Starship>(response);

    // Alternative 2
    //var client = new WebClient();
    //var response = client.DownloadString(url);

    if (response.IsSuccessStatusCode)
    {
        return JsonSerializer.Deserialize<Starship>(response.Content.ReadAsStringAsync().Result);
    }
    else
    {
        Console.WriteLine(response.StatusCode);
        return null;
    }
}