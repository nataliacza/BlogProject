namespace BlogProject.Services.Configuration;

public class JwtConfiguration
{
    public string Secret { get; set; }
    public int ExpirationTime { get; set; }
}
