using BuscaCEP_DLL.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuscaCEP_DLL.Testes.ValueObjects
{
    [TestClass]
    public class CEPTest
    {
        public CEPTest() { }

        [TestMethod]
        public void InvalidCepThrowError()
        {
            CEP cep1= (CEP)"17509320";
            CEP cep2 = (CEP)"17509-320";
            Assert.AreEqual(cep1.Value, cep2.Value);
        }


    }
}
