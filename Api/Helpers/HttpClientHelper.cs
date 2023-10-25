namespace CamposDealerWebProject.Api.Helpers
{
    public static class HttpClientHelper
    {        
        public static HttpClient GetHttpClient(string url)
        {
            using HttpClient httpClient = new();
            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            
            return httpClient;
        }

    }
}
