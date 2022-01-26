namespace API.Config;

public class AppSettingsExtension
{
    public string Secret { get; set; } = null!;
    public string AzureStorageCredentials { get; set; } = null!;
    public string DbConnection { get; set; } = null!;
}