using System;
using System.Text.RegularExpressions;

namespace BuscaCEP_DLL.ValueObject
{
    public class CEP
    {
        public string Value { get;private set; }
        public string GetCepComMascara() => String.Format("{0:#####-###}", Convert.ToInt64(Value));
        public CEP(string cep)
        {
            this.Value = cep;
            EnsureIsValid();
        }

        public CEP(int cep)
        {
            this.Value= cep.ToString();
            EnsureIsValid();
        }
        private void EnsureIsValid()
        {
            Regex regexComMascara = new Regex(@"^\d{5}-\d{3}$");
            Regex regexSemMascara = new Regex(@"^\d{8}$");

            if (!regexComMascara.IsMatch(Value) && !regexSemMascara.IsMatch(Value))
                throw new ArgumentException("CEP inválido");
            else 
                Value = Regex.Replace(Value, @"[^\d]", "");
        }

        public static explicit operator CEP(string cep) => new CEP(cep);
        public static explicit operator CEP(int cep) => new CEP(cep);
    }
}
