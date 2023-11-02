using CamposDealerWebProject.Enums;
using CamposDealerWebProject.Models;
using Newtonsoft.Json;
using System.Collections;

namespace CamposDealerWebProject.Api.Helpers
{
    public static class ApiClassHelper
    {        
        public static HttpClient GetHttpClient(string url)
        {
            HttpClient httpClient = new()
            {
                BaseAddress = new Uri(url)
            };

            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));            
            return httpClient;
        }
      
        public static string GetUrlFromConfigurationFile(string key)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfiguration configuration = builder.Build();
         
            return configuration.GetValue<string>(key);
        }

        public async static Task<IEnumerable> GetObjects(TipoModel model, ApiClient api)
        {
            return model switch
            {
                TipoModel.Clientes => await api.GetData<Cliente>(nameof(Cliente), GetHttpClient(GetUrlFromConfigurationFile("UrlApi:CamposDealerBaseUrl"))),
                TipoModel.Produtos => await api.GetData<Produto>(nameof(Produto), GetHttpClient(GetUrlFromConfigurationFile("UrlApi:CamposDealerBaseUrl"))),
                TipoModel.Vendas => await api.GetData<Venda>(nameof(Venda), GetHttpClient(GetUrlFromConfigurationFile("UrlApi:CamposDealerBaseUrl"))),
                _ => null,
            };
        }
    }
}
