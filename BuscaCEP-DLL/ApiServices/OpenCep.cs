using BuscaCEP_DLL.Contracts;
using BuscaCEP_DLL.DTO;
using BuscaCEP_DLL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuscaCEP_DLL.ApiServices
{
    /// <summary>
    /// Documentação da API 
    /// <see cref="https://opencep.com/"/>
    /// </summary>
    public class OpenCep : ApiRequest
    {
        ConsultarCEP.Request _cep;
        private string UrlGetCep => $"/v1/{_cep.Cep.Value }";

        public OpenCep(ConsultarCEP.Request cep) 
        : base
        (
            new Uri("https://opencep.com/"),
            null ,
            new OpenCepDTO(),
            typeof(OpenCepDTO)
        )
        => _cep = cep;

        protected override async Task<HttpResponseMessage> SendRequest()
            => await _client.GetAsync(UrlGetCep);

        protected override ICepAdapter Deserialize(string content)
            => JsonConvert.DeserializeObject<OpenCepDTO>(content);
    }
}
