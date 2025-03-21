using BuscaCEP_DLL;
using BuscaCEP_DLL.Infra;
using BuscaCEP_DLL.Interfaces;
using Quartz;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace QuartzAPI.Jobs
{
    public class AtualizarCepJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            FamemaContext con = new();

            var cep = con.GetCepDesatualizado();
            Console.WriteLine($"Atualizar CEP {cep.NRO_CEP}");
            Debug.WriteLine("Atualizar CEP");

            IBuscaCEP service = new BuscaCEP();
            var result = await service.ConsultarCEP(new() { Cep = new(cep.NRO_CEP)});

            if(result.IsSuccessfullOperation())
            {
                ICepAdapter adapter = result.GetAdapter();
                cep.SetUF(adapter.GetUF() );
                cep.SetLogradouro(adapter.GetLogradouro());
                cep.SetBairro(adapter.GetBairro());
                cep.SetComplemento(adapter.GetComplemento());
                cep.SetCidade(adapter.GetCidade());
                cep.SetEstado(adapter.GetEstado());

                con.UpdateCep(cep); //Update cep
            }

        }
    }
}
