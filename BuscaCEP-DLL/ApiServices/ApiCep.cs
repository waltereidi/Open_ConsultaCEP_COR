using BuscaCEP_DLL.Contracts;
using BuscaCEP_DLL.DTO;
using BuscaCEP_DLL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuscaCEP_DLL.ApiServices
{
    /// <summary>
    /// Documentação da API 
    /// <see cref="https://apicep.com/api-de-consulta/"/>
    /// </summary>
    public class ApiCep : ApiRequest
    {
        ConsultarCEP.Request _cep;
        private string UrlGetCep => $"file/apicep/{_cep.Cep.GetCepComMascara()}.json";

        public ApiCep(ConsultarCEP.Request cep) 
        : base
        (
            new Uri("https://cdn.apicep.com"),
            null ,
            new ApiCepDTO(),
            typeof(ApiCepDTO)
        )
        => _cep = cep;

        protected override async Task<HttpResponseMessage> SendRequest()
            => await _client.GetAsync(UrlGetCep);

        protected override ICepAdapter Deserialize(string content)
            => JsonConvert.DeserializeObject<ViaCepDTO>(content);
    }
}
