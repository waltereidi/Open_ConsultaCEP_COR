using BuscaCEP_DLL.ApiServices;
using BuscaCEP_DLL.Contracts;
using BuscaCEP_DLL.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuscaCEP_DLL.Testes.ApiServices
{
    [TestClass]
    public class ApiCepTest
    {
        private readonly ConsultarCEP.Request request = new ConsultarCEP.Request()
        {
            Cep = (CEP)"17509320"
        };
        private readonly ApiCep _service;
        public ApiCepTest()
        {
            _service = new ApiCep(request);
        }

        [TestMethod]
        public void ConsultarCEP()
        {
            var result = _service.GetResponse().Result;

            Assert.IsNotNull(result);

        }
    }
}
