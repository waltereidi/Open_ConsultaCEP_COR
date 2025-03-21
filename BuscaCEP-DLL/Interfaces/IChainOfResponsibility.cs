using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuscaCEP_DLL.Interfaces
{
    public interface IChainOfResponsibility
    {
        Task<List<IServiceResponse>> Start();
    }
}
