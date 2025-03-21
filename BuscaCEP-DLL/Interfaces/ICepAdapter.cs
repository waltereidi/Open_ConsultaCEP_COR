namespace BuscaCEP_DLL.Interfaces
{
    public interface ICepAdapter
    {
        string GetCep();
        string GetLogradouro();
        string GetComplemento();
        string GetUF();
        string GetEstado();
        string GetCidade();
        string GetBairro();
        bool IsSuccessfullOperation();
    }
}
