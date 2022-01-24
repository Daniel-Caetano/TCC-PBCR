using ERP.Servico.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ERP.Servico.Servicos.Repositorio
{
    public class RepositorioPessoa
    {

        private readonly string _stringConexao;
        //UTILIZAR ORM (ENTITY)
        public RepositorioPessoa(string stringConexao)
        {
            _stringConexao = stringConexao;
        }

        public Pessoa BuscaCpf(string cpf)
        {
            var pessoa = new Pessoa();
            var sql = new StringBuilder()
                .AppendLine("SELECT * FROM PESSOAS PE WHERE PE.[PESS_CPF] = @cpf");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.Add(new SqlParameter("@cpf", SqlDbType.VarChar) { Value = cpf });
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //var pessoa = new Pessoa();
                    pessoa.ID = reader.GetInt32(reader.GetOrdinal("PESS_ID_PK"));
                    pessoa.Nome = reader.GetString(reader.GetOrdinal("PESS_NOM"));
                    pessoa.CPF = reader.GetString(reader.GetOrdinal("PESS_CPF"));
                    pessoa.Endereco = reader.GetInt32(reader.GetOrdinal("PESS_ENDE_ID_FK"));

                    //pessoas.Add(pessoa);
                }
            }
            return pessoa;
        }

        public Pessoa BuscaNome(string nome)
        {
            var pessoa = new Pessoa();
            var sql = new StringBuilder()
                .AppendLine("SELECT * FROM PESSOAS PE WHERE PE.[PESS_NOM] = @nome");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar) { Value = nome });
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //var pessoa = new Pessoa();
                    pessoa.Nome = reader.GetString(reader.GetOrdinal("PESS_NOM"));
                    pessoa.ID = reader.GetInt32(reader.GetOrdinal("PESS_ID_PK"));
                    pessoa.CPF = reader.GetString(reader.GetOrdinal("PESS_CPF"));
                    pessoa.Endereco = reader.GetInt32(reader.GetOrdinal("PESS_ENDE_ID_FK"));

                    //pessoas.Add(pessoa);
                }
            }
            return pessoa;
        }

        public PessoaEndereco BuscaPessoaEndereco(string cpf)
        {
            var pessoaEndereco = new PessoaEndereco();

            var sql = new StringBuilder()
                .AppendLine("SELECT PE.[PESS_NOM], CO.[CODI_LOG], EN.[ENDE_NUM], EN.[ENDE_COM], CO.[CODI_BAI], CO.[CODI_LOC], CO.[CODI_UF], CO.[CODI_CEP] " +
                "FROM PESSOAS PE " +
                "INNER JOIN ENDERECOS EN " +
                "ON PE.[PESS_ENDE_ID_FK] = EN.[ENDE_ID_PK] " +
                "INNER JOIN [CODIGOS_POSTAIS] CO " +
                "ON CO.[CODI_ID_PK] = EN.[ENDE_CODI_ID_FK] " +
                "WHERE PE.[PESS_CPF] = @cpf");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.Add(new SqlParameter("@cpf", SqlDbType.VarChar) { Value = cpf });
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    pessoaEndereco.Nome = reader.GetString(reader.GetOrdinal("PESS_NOM"));
                    pessoaEndereco.Logradouro = reader.GetString(reader.GetOrdinal("CODI_LOG"));
                    pessoaEndereco.NumeroEndereco = reader.GetString(reader.GetOrdinal("ENDE_NUM"));
                    pessoaEndereco.Complemento = reader.GetString(reader.GetOrdinal("ENDE_COM"));
                    pessoaEndereco.Bairro = reader.GetString(reader.GetOrdinal("CODI_BAI"));
                    pessoaEndereco.Cidade = reader.GetString(reader.GetOrdinal("CODI_LOC"));
                    pessoaEndereco.UF = reader.GetString(reader.GetOrdinal("CODI_UF"));
                    pessoaEndereco.CEP = reader.GetString(reader.GetOrdinal("CODI_CEP"));
                }
            }

            return pessoaEndereco;
        }
    }
}
