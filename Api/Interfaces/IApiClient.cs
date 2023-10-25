namespace CamposDealerWebProject.Api.Interfaces
{
    public interface IApiClient
    {
        public Task<HttpResponseMessage> GetData(string endpoint, HttpClient httpClient);
    }
}
