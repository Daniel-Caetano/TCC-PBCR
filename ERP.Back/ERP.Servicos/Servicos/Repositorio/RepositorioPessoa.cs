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

        private string _stringConexao;
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
    }
}
