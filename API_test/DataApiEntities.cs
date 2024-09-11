using System.Text.Json.Serialization;

// To tell how to convert JSON file into C# object
public class DataApiEntities
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("body")]
    public string Body { get; set; }

    [JsonPropertyName("userId")]
    public int UserId { get; set; }
}