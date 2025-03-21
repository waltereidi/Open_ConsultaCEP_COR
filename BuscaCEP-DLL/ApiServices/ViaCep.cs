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
    /// <see cref="https://viacep.com.br"/>
    /// </summary>
    public class ViaCep : ApiRequest
    {
        ConsultarCEP.Request _cep;
        private string UrlGetCep => $"/ws/{_cep.Cep.Value }/json";

        public ViaCep(ConsultarCEP.Request cep) 
        : base
        (
            new Uri("https://viacep.com.br"),
            null ,
            new ViaCepDTO(),
            typeof(ViaCepDTO)
        )
        => _cep = cep;

        protected override async Task<HttpResponseMessage> SendRequest()
            => await _client.GetAsync(UrlGetCep);

        protected override ICepAdapter Deserialize(string content)
            => JsonConvert.DeserializeObject<ViaCepDTO>(content);
    }
}
