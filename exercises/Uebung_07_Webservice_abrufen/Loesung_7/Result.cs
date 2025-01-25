using System.Text.Json.Serialization;

namespace REST_Webservice_abrufen;

public class Result
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("next")]
    public object Next { get; set; }

    [JsonPropertyName("previous")]
    public object Previous { get; set; }

    [JsonPropertyName("results")]
    public List<People> Results { get; set; }
}