using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Infra.Servico
{
    public abstract class BaseServico
    {
        private HttpClient _httpClient;
        public HttpClient HttpClient
        {
            get
            {
                _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Add("token-ws", ConfigurationManager.AppSettings["token-ws"]);

                return _httpClient;
            }
        }
    }
}
