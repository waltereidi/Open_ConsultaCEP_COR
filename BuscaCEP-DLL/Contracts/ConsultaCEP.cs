using BuscaCEP_DLL.ValueObject;
using System;
using System.Collections.Generic;


namespace BuscaCEP_DLL.Contracts
{
    public class ConsultarCEP
    {
        public class BulkRequest
        {
            public List<Request> Requests { get; set; }
            public BulkRequest(List<Request> requests)
            {
                Requests = requests ?? throw new ArgumentNullException();
                EnsureIsValid();
            }
            private void EnsureIsValid()
            {
                if (Requests.Count == 0)
                {
                    throw new ArgumentException("Requests cannot be empty");
                }
            }
        }

        public class Request
        { 
            public CEP Cep { get; set; }
        
        }
    }
}
