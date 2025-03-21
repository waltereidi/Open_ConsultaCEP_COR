using BuscaCEP_DLL.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuscaCEP_DLL.Interfaces
{
    public interface IBuscaCEP
    {
        Task<List<IServiceResponse>> ConsultarCEPBulk(List<ConsultarCEP.Request> cep);
        Task<IServiceResponse> ConsultarCEP(ConsultarCEP.Request cep);
    }
}
