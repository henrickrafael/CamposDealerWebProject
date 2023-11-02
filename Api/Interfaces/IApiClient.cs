namespace CamposDealerWebProject.Api.Interfaces
{
    public interface IApiClient
    {
        public Task<List<T>> GetData<T>(string endpoint, HttpClient httpClient);
    }
}
