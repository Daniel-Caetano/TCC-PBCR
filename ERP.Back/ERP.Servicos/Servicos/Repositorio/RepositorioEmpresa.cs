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
        public List<Empresa> Lista()
        {
            var empresas = new List<Empresa>();
            var sql = new StringBuilder()
                .AppendLine("SELECT es.EMPR_ID_PK , es.EMPR_RAZ ,es.EMPR_CNPJ, ENDE_ID_PK ,e.ENDE_NUM, e.ENDE_COM , CODI_ID_PK ,cp.CODI_CEP , cp.CODI_LOG , cp.CODI_BAI , cp.CODI_LOC , cp.CODI_UF " +
                            "FROM EMPRESAS es " +
                            "INNER JOIN ENDERECOS e ON ENDE_ID_PK = EMPR_ENDE_ID_FK " +
                            "INNER JOIN CODIGOS_POSTAIS cp ON cp.CODI_ID_PK = e.ENDE_CODI_ID_FK ");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                //command.Parameters.Add(new SqlParameter("@cnpj", SqlDbType.VarChar) { Value = cnpj });
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var empresa = new Empresa
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

                    empresas.Add(empresa);
                }
            }
            return empresas;
        }
        public List<Empresa> BuscaCnpj(string cnpj)
        {
            var empresas = new List<Empresa>();
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
                    var empresa = new Empresa
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

                    empresas.Add(empresa);
                }
            }
            return empresas;
        }

        public void Adicionar(string razao, string cnpj,
            string NumeroEndereco, string Complemento, string CEP
            , string Logradouro, string Bairro, string Localidade, string UF)
        {

            string maxCP = "SELECT MAX(CODI_ID_PK) FROM CODIGOS_POSTAIS";
            string maxEND = "SELECT MAX(ENDE_ID_PK) FROM ENDERECOS";

            // cria variável do tipo inteiro
            int ID_CEP = 0;
            int ID_END = 0;
            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open(); // abre conexão

                // cria objeto do tipo SqlCommand
                using (var command = new SqlCommand(maxCP, conn))
                {
                    // variável quantidade recebe o resultado da execução do método ExecuteScalar
                    ID_CEP = (int)command.ExecuteScalar() + 1;

                }
                using (var command = new SqlCommand(maxEND, conn))
                {
                    // variável quantidade recebe o resultado da execução do método ExecuteScalar
                    ID_END = (int)command.ExecuteScalar() + 1;
                }
                conn.Close(); // fecha a conexao
            }
            // retorna a variável quantidade
            var sqlCEP = new StringBuilder()
                .AppendLine("INSERT INTO CODIGOS_POSTAIS(CODI_CEP,CODI_LOG,CODI_BAI, CODI_LOC, CODI_UF ) " +
                            "VALUES(@CEP, @Logradouro, @Bairro, @Localidade, @UF)");

            var sqlEnderecos = new StringBuilder()
                .AppendLine("INSERT INTO ENDERECOS(ENDE_NUM, ENDE_COM, ENDE_CODI_ID_FK) " +
                            "VALUES(@NumeroEndereco, @Complemento, @ID_CEP)");
         
            var sqlEmpresa = new StringBuilder()
                .AppendLine("INSERT INTO EMPRESAS(EMPR_RAZ, EMPR_CNPJ, EMPR_ENDE_ID_FK) " +
                            "VALUES(@razao, @cnpj, @ID_end)");


            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sqlCEP.ToString(), conn);
                command.Parameters.AddWithValue("@CEP", CEP);
                command.Parameters.AddWithValue("@Bairro", Bairro);
                command.Parameters.AddWithValue("@Localidade", Localidade);
                command.Parameters.AddWithValue("@Logradouro", Logradouro);
                command.Parameters.AddWithValue("@UF", UF);
                var reader = command.ExecuteNonQuery();
            }
            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open(); // abre conexão

                // cria objeto do tipo SqlCommand
                using (var command = new SqlCommand(maxCP, conn))
                {
                    // variável quantidade recebe o resultado da execução do método ExecuteScalar
                    ID_CEP = (int)command.ExecuteScalar();

                }
                conn.Close(); // fecha a conexao
            }
            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sqlEnderecos.ToString(), conn);
                command.Parameters.AddWithValue("@ID_CEP", ID_CEP);
                command.Parameters.AddWithValue("@NumeroEndereco", NumeroEndereco);
                command.Parameters.AddWithValue("@Complemento", Complemento);
                var reader = command.ExecuteNonQuery();
            }

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open(); // abre conexão

                // cria objeto do tipo SqlCommand
                using (var command = new SqlCommand(maxEND, conn))
                {
                    // variável quantidade recebe o resultado da execução do método ExecuteScalar
                    ID_END = (int)command.ExecuteScalar();
                }
                conn.Close(); // fecha a conexao
            }
            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sqlEmpresa.ToString(), conn);
                command.Parameters.AddWithValue("@ID_end", ID_END);
                command.Parameters.AddWithValue("@razao", razao);
                command.Parameters.AddWithValue("@cnpj", cnpj);
                var reader = command.ExecuteNonQuery();
            }
        }
        public void Atualizar(string cnpjAtual, string razao, string cnpj,
            string NumeroEndereco, string Complemento, string CEP
            , string Logradouro, string Bairro, string Localidade, string UF)
        {

            var dadosAntigos = BuscaCnpj(cnpjAtual);

            var sql = new StringBuilder().AppendLine("UPDATE EMPRESAS " +
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
                command.Parameters.AddWithValue("@novarazao", razao);
                command.Parameters.AddWithValue("@novocnpj", cnpj);
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
            var empresaDeletada = new Empresa();

            var sql = new StringBuilder().AppendLine("SELECT EMPR_ENDE_ID_FK, ENDE_CODI_ID_FK , CODI_ID_PK " +
                                                     "FROM EMPRESAS " +
                                                     "INNER JOIN ENDERECOS " +
                                                     "ON ENDE_CODI_ID_FK = EMPR_ENDE_ID_FK " +
                                                     "INNER JOIN CODIGOS_POSTAIS " +
                                                     "ON CODI_ID_PK = ENDE_CODI_ID_FK " +
                                                     "WHERE EMPR_CNPJ = @cnpj");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.Add(new SqlParameter("@cnpj", SqlDbType.VarChar) { Value = cnpj });
                var reader = command.ExecuteReader();

               while(reader.Read()){

                    var empresal = new Empresa
                    {
                        ID_Endereco = reader.GetInt32(reader.GetOrdinal("ENDE_CODI_ID_FK")),
                        ID_CEP = reader.GetInt32(reader.GetOrdinal("CODI_ID_PK")),
                    };
                    empresaDeletada = empresal;
                }
            }

            sql = new StringBuilder().AppendLine("DELETE FROM EMPRESAS " +
                                                 "WHERE EMPR_CNPJ = @cnpj");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@cnpj", cnpj);
                var reader = command.ExecuteNonQuery();
            }

            sql = new StringBuilder().AppendLine("DELETE FROM ENDERECOS " +
                                                 "WHERE ENDE_CODI_ID_FK = @ID_Endereco ");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@ID_Endereco", empresaDeletada.ID_Endereco);

                var reader = command.ExecuteNonQuery();
            }

            sql = new StringBuilder().AppendLine("DELETE FROM CODIGOS_POSTAIS " +
                                                 "WHERE CODI_ID_PK = @ID_CEP");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@ID_CEP", empresaDeletada.ID_CEP);

                var reader = command.ExecuteNonQuery();
            }

        }
    }
}