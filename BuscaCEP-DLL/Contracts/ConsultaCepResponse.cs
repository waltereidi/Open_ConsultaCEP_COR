using BuscaCEP_DLL.Interfaces;
using BuscaCEP_DLL.ValueObject;
using System;
using System.Net.Http;


namespace BuscaCEP_DLL.Contracts
{
    public class ConsultaCepResponse: IServiceResponse
    {
        private readonly HttpResponseMessage _response;
        private readonly ICepAdapter _adapter;
        public CEP Cep { get =>(CEP)this._adapter.GetCep(); }
        public string Logradouro { get => this._adapter.GetLogradouro(); }
        public string Complemento { get => this._adapter.GetComplemento(); }
        public string UF { get => this._adapter.GetUF(); }
        public string Estado { get => this._adapter.GetEstado(); }
        public string Cidade { get => this._adapter.GetCidade(); }
        public string Bairro { get => this._adapter.GetBairro(); }
        public ConsultaCepResponse(HttpResponseMessage response , ICepAdapter instance)
        {
            this._response = response;
            this._adapter = instance;
        }
        public ConsultaCepResponse(ICepAdapter instance)
            => this._adapter = instance;

        public HttpResponseMessage GetContent()
            => _response;
        public ICepAdapter GetAdapter()
            => _adapter;
        public bool IsSuccessfullOperation()
            => _adapter.IsSuccessfullOperation();
    }
}
