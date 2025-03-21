using BuscaCEP_DLL.Contracts;
using BuscaCEP_DLL.DTO;
using BuscaCEP_DLL.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuscaCEP_DLL.ApiServices
{
    /// <summary>
    /// Abstração da execução de chamadas á APIs<br></br>
    /// de consulta de CEPs
    /// </summary>
    public abstract class ApiRequest : ICepStrategy
    {
        protected HttpClient _client { get; private set; }
        protected readonly Uri _urlBase;
        protected readonly HttpContent _content;
        protected readonly ICepAdapter _adapter;
        protected readonly Type _adapterType;
        protected ApiRequest(Uri urlBase , HttpContent content , ICepAdapter cepAdapter, Type AdapterType ) 
        {
            _urlBase = urlBase;
            _content = content;
            _adapter = cepAdapter;
            _adapterType = AdapterType;
            _client = new HttpClient();
        }
        /// <summary>
        /// Executa toda os comandos necessários para <br></br>
        /// Instanciar e interpretar as respostas das APIs<br></br>
        /// Sobrescreva este método quando precisar refazer o fluxo inteiro.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IServiceResponse> GetResponse()
        {
            try
            {
                SetHeaders();
                ConfigureClient();
                HttpResponseMessage response = await SendRequest();

                ICepAdapter adapter = await ReadResponse(response);

                return new ConsultaCepResponse(response, adapter);

            }catch(Exception ex)
            {
                ICepAdapter erroAdpter = new ApiErrorDTO(ex);
                return new ConsultaCepResponse(erroAdpter);
            }
            
        }
        /// <summary>
        /// Esse método deve instanciar a DTO correspondente á API <br></br>
        /// de destino. <br></br>
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        protected abstract ICepAdapter Deserialize(string content);
        /// <summary>
        /// Sobrecreva este método para comportar leituras de respostas<br></br>
        /// adversas as demais chamadas.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected virtual async Task<ICepAdapter> ReadResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var result = await response.Content.ReadAsStringAsync();

            return Deserialize(result);
        }
        /// <summary>
        /// Este método deve adicionar a parametrização necessária<br></br>
        /// para fazer uma solicitação á API alvo.
        /// </summary>
        /// <returns></returns>
        protected abstract Task<HttpResponseMessage> SendRequest();
        /// <summary>
        /// Adicione aqui as configurações do WebClient<br></br>
        /// Ou sobrescreva para criar um serviço mais customizado
        /// </summary>
        protected virtual void ConfigureClient()
        {
            _client.BaseAddress =_urlBase;
        }
        /// <summary>
        /// Adicione aqui configurações globais para header<br></br>
        /// Ou sobrescreva para uma única chamada adversa as demais.
        /// </summary>
        protected virtual void SetHeaders()
        {
            //_client.DefaultRequestHeaders.Add("Bearer" , "Token");
        }
        


    }
}
