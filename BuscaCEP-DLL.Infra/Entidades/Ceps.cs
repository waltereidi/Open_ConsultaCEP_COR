

using System.Globalization;
using System.Text;

namespace BuscaCEP_DLL.Infra.Entidades
{
    public class Ceps 
    {
        public int SEQ_CEP { get; set; }
        public int SEQ_PAIS { get; set; }
        public int SEQ_MUNICIPIO { get; set; }
        public int NRO_CEP { get; set; }
        public string? SIG_TIPO_LOGRADOURO { get; set; }
        public string? NOM_LOGRADOURO { get; set; }
        public string? DES_INTERVALO { get; set; }
        public string? NOM_BAIRRO { get; set; }
        public DateTime? DAT_FIM { get; set; }
        public string? FLG_TIPO { get; set; }
        public int COD_LOG_NU { get; set; }
        public int COD_LOC_NU { get; set; }
        public int ATUALIZADO { get; set; }
        public string ObsImportacao { get; set; }
        private string RemoverAcentos(string texto)
        {
            if (texto == null)
                return null;

            texto = texto.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in texto)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
        public void SetLogradouro(string text)
            => NOM_LOGRADOURO = RemoverAcentos(text).ToUpper();
        public void SetComplemento(string text)
            => DES_INTERVALO = RemoverAcentos(text).ToUpper();
        public void SetUF(string text)
            => ObsImportacao+= RemoverAcentos(text).ToUpper() + ";";
        public void SetEstado(string text)
            => ObsImportacao += RemoverAcentos(text).ToUpper() + ";";
        public void SetCidade(string text)
            => ObsImportacao += RemoverAcentos(text).ToUpper() + ";";
        public void SetBairro(string text)
            => NOM_BAIRRO = RemoverAcentos(text).ToUpper();
    }
}
