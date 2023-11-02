using CamposDealerWebProject.Api.Interfaces;
using CamposDealerWebProject.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CamposDealerWebProject.Api
{
    public class ApiClient : IApiClient
    {                
        public async Task<List<T>> GetData<T>(string endpoint, HttpClient httpClient)
        {
            var httpResponse = await httpClient.GetAsync(endpoint);
            var responseObject = JsonConvert.DeserializeObject(httpResponse.Content.ReadAsStringAsync().Result).ToString();

            return JsonConvert.DeserializeObject<List<T>>(responseObject);
        }
    }
}
