using System.Text.Json.Serialization;

namespace StarWars;

public class People
{
    [JsonPropertyName("birth_year")]
    public string Birth_year { get; set; }

    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonPropertyName("edited")]
    public DateTime Edited { get; set; }

    [JsonPropertyName("eye_color")]
    public string Eye_color { get; set; }

    [JsonPropertyName("films")]
    public List<string> Films { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("hair_color")]
    public string Hair_color { get; set; }

    [JsonPropertyName("height")]
    public string Height { get; set; }

    [JsonPropertyName("homeworld")]
    public string Homeworld { get; set; }

    [JsonPropertyName("mass")]
    public string Mass { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("skin_color")]
    public string Skin_color { get; set; }

    [JsonPropertyName("species")]
    public List<object> Species { get; set; }

    [JsonPropertyName("starships")]
    public List<string> Starships { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("vehicles")]
    public List<string> Vehicles { get; set; }
}