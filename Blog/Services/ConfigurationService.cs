namespace Blog.Services;

public class ConfigurationService
{
    public string? ApiServiceUrl { get; init; }

    public ConfigurationService(IConfiguration configuration)
    {
        ApiServiceUrl = configuration["Url:ApiService"];
    }
}