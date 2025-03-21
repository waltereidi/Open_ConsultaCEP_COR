using BuscaCEP_DLL.ApiServices;
using BuscaCEP_DLL.Contracts;
using BuscaCEP_DLL.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCEP_DLL.Testes.ApiServices
{
    [TestClass]
    public class OpenCepTest
    {
        private readonly ConsultarCEP.Request request = new ConsultarCEP.Request()
        {
            Cep = (CEP)"17509320"

        }; 
        private readonly OpenCep _service; 
        public OpenCepTest() 
        {
            _service = new OpenCep(request);
        }

        [TestMethod]
        public void ConsultarCEP()
        {
            var result = _service.GetResponse().Result;

            Assert.IsNotNull(result);
            
        }
    }
}
