using System.Text.Json;

namespace MinioDemo;

public static class CredentialsHelper
{
    public static Credentials? LoadCredentials(string path)
    {
        var fileStream = File.OpenRead(path);

        var credentials = JsonSerializer.Deserialize<Credentials>(fileStream);

        return credentials;
    }
}
