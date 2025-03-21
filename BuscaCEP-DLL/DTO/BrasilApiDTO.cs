using BuscaCEP_DLL.Interfaces;
using System;

namespace BuscaCEP_DLL.DTO
{
    public class BrasilApiDTO : ICepAdapter
    {
        public string Cep { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string Service { get; set; }
        public BrasilApiDTO.Locations Location { get; set; }
        public class Locations
        {
            public string Type { get; set; }
            public BrasilApiDTO.Coordinates Coordinates { get; set; }
        }

        public class Coordinates
        {
            public string Longitude { get; set; }
            public string Latitude { get; set; }
        }
        public string GetCep() => Cep;
        public string GetCidade() => City;
        public string GetComplemento() => "";
        public string GetEstado() => State;
        public string GetLogradouro() => Street;
        public string GetUF() => State;
        public bool IsSuccessfullOperation()
        {
            if (String.IsNullOrEmpty(Cep)) return false;

            if (String.IsNullOrEmpty(City)) return false;

            if (String.IsNullOrEmpty(State)) return false;

            return true;
        }
        public string GetBairro() => Neighborhood;
    }
}
