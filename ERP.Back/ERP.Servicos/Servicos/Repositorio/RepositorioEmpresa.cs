using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Servico.Negocio;

namespace ERP.Servico.Servicos.Repositorio
{
    public class RepositorioEmpresa
    {
        private readonly string _stringConexao;
        //UTILIZAR ORM (ENTITY)
        public RepositorioEmpresa(string stringConexao)
        {
            _stringConexao = stringConexao;
        }
        public List<Empresa> BuscaCnpj(string cnpj)
        {
            var empresa = new List<Empresa>();
            var sql = new StringBuilder()
                .AppendLine("SELECT es.EMPR_ID_PK , es.EMPR_RAZ ,es.EMPR_CNPJ, ENDE_ID_PK ,e.ENDE_NUM, e.ENDE_COM , CODI_ID_PK ,cp.CODI_CEP , cp.CODI_LOG , cp.CODI_BAI , cp.CODI_LOC , cp.CODI_UF " +
                            "FROM EMPRESAS es " +
                            "INNER JOIN ENDERECOS e ON ENDE_ID_PK = EMPR_ENDE_ID_FK " +
                            "INNER JOIN CODIGOS_POSTAIS cp ON cp.CODI_ID_PK = e.ENDE_CODI_ID_FK " +
                            "WHERE es.EMPR_CNPJ = @cnpj");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.Add(new SqlParameter("@cnpj", SqlDbType.VarChar) { Value = cnpj });
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var empresal = new Empresa
                    {
                        ID_Empresa = reader.GetInt32(reader.GetOrdinal("EMPR_ID_PK")),
                        ID_Endereco = reader.GetInt32(reader.GetOrdinal("ENDE_ID_PK")),
                        ID_CEP = reader.GetInt32(reader.GetOrdinal("CODI_ID_PK")),
                        Razao = reader.GetString(reader.GetOrdinal("EMPR_RAZ")),
                        CNPJ = reader.GetString(reader.GetOrdinal("EMPR_CNPJ")),
                        NumeroEndereco = reader.GetString(reader.GetOrdinal("ENDE_NUM")),
                        Complemento = reader.GetString(reader.GetOrdinal("ENDE_COM")),
                        CEP = reader.GetString(reader.GetOrdinal("CODI_CEP")),
                        Logradouro = reader.GetString(reader.GetOrdinal("CODI_LOG")),
                        Bairro = reader.GetString(reader.GetOrdinal("CODI_BAI")),
                        Localidade = reader.GetString(reader.GetOrdinal("CODI_LOC")),
                        UF = reader.GetString(reader.GetOrdinal("CODI_UF"))
                    };

                    empresa.Add(empresal);
                }
            }
            return empresa;
        }

        public void Adicionar(string razao, string cnpj)
        {
            //var  novaEmpresa = new Empresa();
            var sql = new StringBuilder()
                .AppendLine("INSERT INTO EMPRESAS ( EMPR_RAZ, EMPR_CNPJ ) " +
                             "VALUES ( @razao, @cnpj) ");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@razao", razao);
                command.Parameters.AddWithValue("@cnpj", cnpj);
                var reader = command.ExecuteNonQuery();
            }
        }
        public void Atualizar(string cnpjAtual, string novaRazao, string novoCnpj, 
            string NumeroEndereco, string Complemento, string CEP
            , string Logradouro, string Bairro, string Localidade, string UF)
        {
            var dadosAntigos = BuscaCnpj(cnpjAtual);

            if (novaRazao == null)
            {
                novaRazao = dadosAntigos[0].Razao;
                //command.Parameters.AddWithValue("@razao", novaRazao);
            }
            if (novoCnpj == null)
            {
                novoCnpj = dadosAntigos[0].CNPJ;
                //command.Parameters.AddWithValue("@cnpj", novoCnpj);
            }
            if (NumeroEndereco == null)
            {
                NumeroEndereco = dadosAntigos[0].NumeroEndereco;
                //command.Parameters.AddWithValue("@razao", novaRazao);
            }
            if (Complemento == null)
            {
                Complemento = dadosAntigos[0].Complemento;
                //command.Parameters.AddWithValue("@cnpj", novoCnpj);
            }
            if (CEP == null)
            {
                CEP = dadosAntigos[0].CEP;
                //command.Parameters.AddWithValue("@razao", novaRazao);
            }
            if (Logradouro == null)
            {
                Logradouro = dadosAntigos[0].Logradouro;
                //command.Parameters.AddWithValue("@cnpj", novoCnpj);
            }
            if (Bairro == null)
            {
                Bairro = dadosAntigos[0].Bairro;
                //command.Parameters.AddWithValue("@razao", novaRazao);
            }
            if (Localidade == null)
            {
                Localidade = dadosAntigos[0].Localidade;
                //command.Parameters.AddWithValue("@cnpj", novoCnpj);
            }
            if (UF == null)
            {
                UF = dadosAntigos[0].UF;
                //command.Parameters.AddWithValue("@cnpj", novoCnpj);
            }


            var sql = new StringBuilder().AppendLine("UPDATE EMPRESAS "+
                                                     "SET EMPR_RAZ = @novarazao, EMPR_CNPJ = @novocnpj " +
                                                     "WHERE EMPR_CNPJ = @cnpjatual " +
                                                     "UPDATE ENDERECOS " +
                                                     "SET ENDE_NUM = @NumeroEndereco, ENDE_COM = @Complemento " +
                                                     "WHERE ENDE_ID_PK = @ID_end " + 
                                                     "UPDATE CODIGOS_POSTAIS " +
                                                     "SET CODI_BAI = @Bairro, CODI_CEP = @CEP, CODI_LOC = @Localidade, CODI_LOG = @Logradouro, CODI_UF = @UF " +
                                                     "WHERE CODI_ID_PK = @ID_CEP "); 

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@novarazao", novaRazao);
                command.Parameters.AddWithValue("@novocnpj", novoCnpj);
                command.Parameters.AddWithValue("@cnpjatual", cnpjAtual);
                command.Parameters.AddWithValue("@NumeroEndereco", NumeroEndereco);
                command.Parameters.AddWithValue("@Complemento", Complemento);
                command.Parameters.AddWithValue("@ID_end", dadosAntigos[0].ID_Endereco);
                command.Parameters.AddWithValue("@Bairro", Bairro);
                command.Parameters.AddWithValue("@CEP", CEP);
                command.Parameters.AddWithValue("@Localidade", Localidade);
                command.Parameters.AddWithValue("@Logradouro", Logradouro);
                command.Parameters.AddWithValue("@UF", UF);
                command.Parameters.AddWithValue("@ID_CEP", dadosAntigos[0].ID_CEP);

                var reader = command.ExecuteNonQuery();
            }
        }

        public void Deletar(string cnpj)
        {

            var sql = new StringBuilder().AppendLine("DELETE FROM EMPRESAS WHERE EMPR_CNPJ = @cnpj");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@cnpj", cnpj);
                var reader = command.ExecuteNonQuery();
            }
        }
    }
}