using BuscaCEP_DLL.Infra.Entidades;
using Oracle.ManagedDataAccess.Client;



namespace BuscaCEP_DLL.Infra
{
    public class FamemaContext
    {
        private readonly string _connectionString; 
        public FamemaContext() 
        {
            _connectionString = "Data Source=172.16.3.25/SISTEMAS; User Id=famemasistemas;Password=desenv2013;";
        }
        public OracleDataReader ExecuteCommand(string sql )
        {
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.BindByName = true;

                        cmd.CommandText = sql; 

                        return cmd.ExecuteReader();
                        
                    }
                    catch (Exception ex)
                    {
                        return null; 
                    }
                }
            }
        }
        public int UpdateCep(Ceps cep)
        {
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.BindByName = true;

                        cmd.CommandText = String.Format(@"
                            update sihosp.cep_bkp 
                            set 
                            sig_tipo_logradouro = '{1}' , 
                            nom_bairro = '{2}' , 
                            des_intervalo = '{3}' , 
                            obsImportacao = '{4}',
                            atualizado = 1 
                            where seq_cep = {0}"
                            , cep.SEQ_CEP 
                            , cep.SIG_TIPO_LOGRADOURO 
                            , cep.NOM_BAIRRO 
                            , cep.DES_INTERVALO
                            , cep.ObsImportacao);

                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return 0;
                    }
                }
            }
        }
        public Ceps GetCepDesatualizado()
        {
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.BindByName = true;

                        cmd.CommandText = @"
                        select 
                        SEQ_CEP ,SEQ_PAIS ,SEQ_MUNICIPIO ,
                        NRO_CEP ,SIG_TIPO_LOGRADOURO ,NOM_LOGRADOURO ,
                        DES_INTERVALO ,NOM_BAIRRO ,
                        FLG_TIPO ,COD_LOG_NU ,COD_LOC_NU ,
                        ATUALIZADO 
                        from sihosp.cep_bkp 
                        where atualizado = 0 
                        and seq_municipio in (
                            3420,3437,3274,3893,3447,
                            3481,3704,3729,3452,3571,
                            3448,3369,3648,3638,3642,
                            3646,3880,3549,3455,3275)
                        and rownum = 1 ";

                        var result =  cmd.ExecuteReader();
                        if (result.Read())
                        {
                            return new Ceps()
                            {
                                SEQ_CEP = result.GetInt32(0),
                                SEQ_PAIS = result.GetInt32(1),
                                SEQ_MUNICIPIO = result.GetInt32(2),
                                NRO_CEP = result.GetInt32(3),
                                SIG_TIPO_LOGRADOURO = result["SIG_TIPO_LOGRADOURO"].ToString() ,
                                NOM_LOGRADOURO = result["NOM_LOGRADOURO"].ToString(),
                                DES_INTERVALO = result["DES_INTERVALO"].ToString(),
                                NOM_BAIRRO = result["NOM_BAIRRO"].ToString(),
                                FLG_TIPO = result["FLG_TIPO"].ToString(),
                                COD_LOG_NU = result.GetInt32(9),
                                COD_LOC_NU = result.GetInt32(10),
                                ATUALIZADO = result.GetInt32(11),
                            };
                        }
                        else
                            return null;

                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
        }

    }
}
