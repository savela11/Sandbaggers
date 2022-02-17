namespace API.Config;

public static class HttpClientExtension
{
  public static void BaseHttpClient(this WebApplicationBuilder builder)
  {
    var res = builder.Configuration.GetValue<string>("HTTPClient:BaseURL");
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(res) });
  }
}