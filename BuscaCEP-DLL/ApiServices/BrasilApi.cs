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
    /// <see cref="https://brasilapi.com.br/docs#tag/CEP"/>
    /// </summary>
    public class BrasilApi : ApiRequest
    {
        ConsultarCEP.Request _cep;
        private string UrlGetCep => $"/api/cep/v2/{_cep.Cep.Value }";

        public BrasilApi(ConsultarCEP.Request cep) 
        : base
        (
            new Uri("https://brasilapi.com.br"),
            null ,
            new BrasilApiDTO(),
            typeof(BrasilApiDTO)
        )
        => _cep = cep;

        protected override async Task<HttpResponseMessage> SendRequest()
            => await _client.GetAsync(UrlGetCep);

        protected override ICepAdapter Deserialize(string content)
            => JsonConvert.DeserializeObject<BrasilApiDTO>(content);
    }
}
