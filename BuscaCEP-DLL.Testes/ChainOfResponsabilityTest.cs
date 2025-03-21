using BuscaCEP_DLL.Contracts;
using BuscaCEP_DLL.Interfaces;
using BuscaCEP_DLL.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCEP_DLL.Testes
{
    [TestClass]
    public class ChainOfResponsabilityTest
    {

        public ChainOfResponsabilityTest() { }
        
        [TestMethod]
        public void TestChainOfResponsability() 
        {
            var data =new ConsultarCEP.Request() 
            { 
                Cep = (CEP)"17509320"
            };
            IChainOfResponsibility service = new ChainOfResponsibility(data);
            List<IServiceResponse> result = service.Start().Result;
            Assert.IsNotNull(result.First());
            
        
        }

    }
}
