using CamposDealerWebProject.Api.Interfaces;

namespace CamposDealerWebProject.Api
{
    public class ApiClient : IApiClient
    {        
        public async Task<HttpResponseMessage> GetData(string endpoint, HttpClient httpClient)
        {            
            return await httpClient.GetAsync(endpoint);
        }
    }
}
