using BuscaCEP_DLL.Interfaces;
using System;

namespace BuscaCEP_DLL.DTO
{
    public class OpenCepDTO : ICepAdapter
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Unidade { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Estado { get; set; }
        public string Regiao { get; set; }
        public string Ibge { get; set; }

        public string GetBairro() => Bairro;
        public string GetCep() => Cep;
        public string GetCidade() => Localidade;
        public string GetComplemento() => Complemento;
        public string GetEstado() => Estado;
        public string GetLogradouro() => Logradouro;
        public string GetUF() => Uf;
        public bool IsSuccessfullOperation()
        {
            if (String.IsNullOrEmpty(Cep)) return false;

            if (String.IsNullOrEmpty(Localidade)) return false;

            if (String.IsNullOrEmpty(Uf)) return false;

            return true;
        }
    }
}
