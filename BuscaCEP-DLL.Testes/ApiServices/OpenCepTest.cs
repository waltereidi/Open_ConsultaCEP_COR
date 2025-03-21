using BuscaCEP_DLL.ApiServices;
using BuscaCEP_DLL.Contracts;
using BuscaCEP_DLL.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCEP_DLL.Testes.ApiServices
{
    [TestClass]
    public class ViaCepTest
    {
        private readonly ConsultarCEP.Request request = new ConsultarCEP.Request()
        {
            Cep = (CEP)"17509320"

        }; 
        private readonly ViaCep _service; 
        public ViaCepTest() 
        {
            _service = new ViaCep(request);
        }

        [TestMethod]
        public void ConsultarCEP()
        {
            var result = _service.GetResponse().Result;

            Assert.IsNotNull(result);

        }
    }
}
