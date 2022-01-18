using ERP.Servico.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ERP.Servicos
{
    public class RepositorioRecibo
    {
        private string _stringConexao;
        //UTILIZAR ORM (ENTITY)
        public RepositorioRecibo(string stringConexao)
        {
            _stringConexao = stringConexao;
        }

        public List<Pessoa> ConsultaDados(string cpf)
        {
            var pessoas = new List<Pessoa>();
            var sql = new StringBuilder()
                .AppendLine("SELECT * FROM PESSOA PE WHERE PE.[CPF_PESSOA] = @cpf");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.Add(new SqlParameter("@cpf", SqlDbType.VarChar) { Value = cpf });
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var pessoa = new Pessoa();
                    pessoa.Nome = reader.GetString(reader.GetOrdinal("NOME_PESSOA"));
                    pessoa.ID = reader.GetInt32(reader.GetOrdinal("ID_PESSOA"));
                    pessoa.CPF = reader.GetString(reader.GetOrdinal("CPF_PESSOA"));
                    pessoa.Endereco = reader.GetString(reader.GetOrdinal("ENDERECO_PESSOA"));
                    pessoa.Telefone = reader.GetString(reader.GetOrdinal("TELEFONE_PESSOA"));

                    pessoas.Add(pessoa);
                }
            }

            return pessoas;
        }

        public List<Recibo> GeraRecibo()
        {
            var recibos = new List<Recibo>();
            var sql = new StringBuilder()
                .AppendLine("SELECT * FROM RECIBOS RE");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var recibo = new Recibo();

                    recibo.Numero = reader.GetInt32(reader.GetOrdinal("RECI_NUME_RECIBO_PK"));
                    recibo.Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VALOR"));
                    recibo.ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VALOR_EXTENSO"));
                    recibo.Observacao = reader.GetString(reader.GetOrdinal("RECI_OBSERVACAO"));
                    recibo.Cidade = reader.GetString(reader.GetOrdinal("RECI_CIDADE"));
                    recibo.Estado = reader.GetString(reader.GetOrdinal("RECI_ESTADO"));
                    recibo.Data = reader.GetDateTime(reader.GetOrdinal("RECI_DATA"));
                    recibo.Tipo = reader.GetString(reader.GetOrdinal("RECI_TIPO"));

                    recibos.Add(recibo);
                }
            }

            return recibos;

        }
    }
}
