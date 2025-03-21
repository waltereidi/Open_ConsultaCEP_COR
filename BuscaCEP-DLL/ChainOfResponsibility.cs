
using BuscaCEP_DLL.ApiServices;
using BuscaCEP_DLL.Contracts;
using BuscaCEP_DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuscaCEP_DLL
{
    public class ChainOfResponsibility : IChainOfResponsibility
    {
        private readonly Queue<ConsultarCEP.Request> _ceps;

        public ChainOfResponsibility(ConsultarCEP.Request cep )
        {
            _ceps = new Queue<ConsultarCEP.Request>();
            _ceps.Enqueue(cep);

        }
        public ChainOfResponsibility(List<ConsultarCEP.Request> ceps)
        {
            _ceps = new Queue<ConsultarCEP.Request>();
            
            ceps.ForEach(f => _ceps.Enqueue(f));
        }
        private Queue<ICepStrategy> InicializarOrdemPadrao(ConsultarCEP.Request cep)
        {          
            var clients = new Queue<ICepStrategy>();
            
            clients.Enqueue(new ViaCep(cep));
            clients.Enqueue(new BrasilApi(cep));
            clients.Enqueue(new OpenCep(cep));
            clients.Enqueue(new ApiCep(cep));
            
            return clients;
        }

        public async Task<List<IServiceResponse>> Start()
        {
            List<IServiceResponse> result = new List<IServiceResponse>();

            while(_ceps.Count > 0 )
            {
                var cep = _ceps.Dequeue();
                var queue = InicializarOrdemPadrao(cep);
                var response = await GetReponseFromQueue(queue);
                result.Add(response);
            }
            return result;
        }
        private async Task<IServiceResponse> GetReponseFromQueue(Queue<ICepStrategy> queue)
        {
            while (queue.Count > 0)
            {
                var operation = queue.Dequeue();
                IServiceResponse result = await operation.GetResponse();

                if (result.IsSuccessfullOperation())
                    return result;
            }
            throw new OperationCanceledException("None of the options returned a succesfull response");
        }

    }
}
