using System.Net.Http;

namespace BuscaCEP_DLL.Interfaces
{
    public interface IServiceResponse
    {
        HttpResponseMessage GetContent();
        bool IsSuccessfullOperation();
        ICepAdapter GetAdapter();
    }
}
