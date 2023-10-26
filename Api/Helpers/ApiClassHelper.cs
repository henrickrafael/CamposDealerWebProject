namespace CamposDealerWebProject.Api.Helpers
{
    public static class ApiClassHelper
    {        
        public static HttpClient GetHttpClient(string url)
        {
            using HttpClient httpClient = new();
            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            
            return httpClient;
        }
      
        public static string GetUrlFromConfigurationFile(string key)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfiguration configuration = builder.Build();
         
            return configuration.GetValue<string>(key);
        }
    }
}
