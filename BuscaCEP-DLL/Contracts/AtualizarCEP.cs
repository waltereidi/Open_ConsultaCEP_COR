using System;
using System.Collections.Generic;

namespace BuscaCEP_DLL.Contracts
{
    public class AtualizarCEP
    {
        public class BulkRequest
        {
            private List<Request> Requests { get; set; }
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
        
        }
    }
}
