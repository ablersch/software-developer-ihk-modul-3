using System.Text.Json.Serialization;

namespace REST_Webservice_abrufen;

public class People
{
    [JsonPropertyName("birth_year")]
    public string BirthYear { get; set; }

    [JsonPropertyName("films")]
    public List<string> Films { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("hair_color")]
    public string HairColor { get; set; }

    [JsonPropertyName("height")]
    public string Height { get; set; }

    [JsonPropertyName("homeworld")]
    public string Homeworld { get; set; }

    public string Image
    {
        get
        {
            // Letzten Slash entfernen
            string url = Url.EndsWith('/') ? Url.Remove(Url.Length-1) : Url;
            var parts = url.Split('/');

            return $"https://vieraboschkova.github.io/swapi-gallery/static/assets/img/people/{parts[parts.Length-1]}.jpg";
        }
    }

    [JsonPropertyName("mass")]
    public string Mass { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("starships")]
    public List<string> Starships { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}