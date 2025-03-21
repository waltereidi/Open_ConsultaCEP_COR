using BuscaCEP_DLL.Interfaces;
using System;

namespace BuscaCEP_DLL.DTO
{
    public class ApiCepDTO : ICepAdapter
    {
        public string Code { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public bool Ok { get; set; }
        public string StatusText { get; set; }

        public string GetBairro() => District;
        public string GetCep() => Code;
        public string GetCidade() => City;
        public string GetComplemento()=> "";
        public string GetEstado() => State;
        public string GetLogradouro() => Address;
        public string GetUF() => State;
        public bool IsSuccessfullOperation()
        {
            if (String.IsNullOrEmpty(District)) return false;
            if (String.IsNullOrEmpty(Code)) return false;
            if (String.IsNullOrEmpty(City)) return false;
            if (String.IsNullOrEmpty(State)) return false;

            return true;

        }
    }
}
