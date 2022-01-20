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

                    recibo.Numero = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK"));
                    recibo.Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP"));
                    recibo.Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL"));
                    recibo.ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT"));
                    recibo.Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"));
                    recibo.Cidade = reader.GetString(reader.GetOrdinal("RECI_CID"));
                    recibo.Estado = reader.GetString(reader.GetOrdinal("RECI_UF"));
                    recibo.Data = reader.GetDateTime(reader.GetOrdinal("RECI_DAT"));

                    recibos.Add(recibo);
                }
            }

            return recibos;

        }
    }
}
