using BuscaCEP_DLL.Interfaces;
using System;

namespace BuscaCEP_DLL.DTO
{
    public class ApiErrorDTO : ICepAdapter
    {
        public string GetCep() => "";
        public string GetCidade() => "";
        public string GetComplemento() => "";
        public string GetEstado() => "";
        public string GetLogradouro() => "";
        public string GetUF() => "";
        public bool IsSuccessfullOperation() => false;
        public string GetBairro() => "";

        public readonly Exception _ex;
        public ApiErrorDTO(Exception ex)
        {
            this._ex = ex;
        }
    }
}
