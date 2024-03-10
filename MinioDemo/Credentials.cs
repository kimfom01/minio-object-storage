using System.Text.Json.Serialization;

namespace MinioDemo;

public class Credentials
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("accessKey")]
    public string AccessKey { get; set; }

    [JsonPropertyName("secretKey")]
    public string SecretKey { get; set; }

    [JsonPropertyName("api")]
    public string Api { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }
}
