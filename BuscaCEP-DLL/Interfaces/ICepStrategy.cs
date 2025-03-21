using System.Threading.Tasks;

namespace BuscaCEP_DLL.Interfaces
{
    public interface ICepStrategy
    {
        Task<IServiceResponse> GetResponse();
    }
}
