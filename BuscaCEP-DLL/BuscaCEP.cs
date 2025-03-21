
using BuscaCEP_DLL.Contracts;
using BuscaCEP_DLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaCEP_DLL
{
    public class BuscaCEP : IBuscaCEP
    {
        public async Task<IServiceResponse> ConsultarCEP(ConsultarCEP.Request cep)
        {
            IChainOfResponsibility service = new ChainOfResponsibility(cep);
            var result = await service.Start();
            return result.First();
        }

        public async Task<List<IServiceResponse>> ConsultarCEPBulk(List<ConsultarCEP.Request> ceps)
        {
            IChainOfResponsibility service = new ChainOfResponsibility(ceps);
            
            var result = await service.Start();
            
            return result;
        }
            
    }
}
