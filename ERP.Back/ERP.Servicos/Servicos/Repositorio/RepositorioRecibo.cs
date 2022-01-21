using ERP.Servico.Negocio;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ERP.Servicos
{
    public class RepositorioRecibo
    {
        private readonly string _stringConexao;
        //UTILIZAR ORM (ENTITY)
        public RepositorioRecibo(string stringConexao)
        {
            _stringConexao = stringConexao;
        }

<<<<<<< HEAD
        public List<Pessoa> ConsultaDados(string cpf)
        {
            var pessoas = new List<Pessoa>();
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
                    var pessoa = new Pessoa
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("PESS_ID_PK")),
                        Nome = reader.GetString(reader.GetOrdinal("PESS_NOM")),
                        CPF = reader.GetString(reader.GetOrdinal("PESS_CPF")),
                        Endereco = reader.GetInt32(reader.GetOrdinal("PESS_ENDE_ID_FK"))
                    };

                    pessoas.Add(pessoa);
                }
            }
            return pessoas;
        }

        public List<Recibo> GeraRecibo()
=======
        public List<Recibo> ListaRecibos()
>>>>>>> d8c217f2a346c27dcf6e244d94ab444a809eaf87
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
                    var recibo = new Recibo
                    {
                        Numero = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK")),
                        Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP")),
                        Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL")),
                        ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT")),
                        Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS")),
                        Cidade = reader.GetString(reader.GetOrdinal("RECI_CID")),
                        Estado = reader.GetString(reader.GetOrdinal("RECI_UF")),
                        Data = reader.GetDateTime(reader.GetOrdinal("RECI_DAT"))
                    };

                    recibos.Add(recibo);
                }
            }
            return recibos;

        }

        //public List<Pessoa> ConsultaDados(string cpf)
        //{
        //    var pessoas = new List<Pessoa>();
        //    var sql = new StringBuilder()
        //        .AppendLine("SELECT * FROM PESSOAS PE WHERE PE.[PESS_CPF] = @cpf");

        //    using (var conn = new SqlConnection(_stringConexao))
        //    {
        //        conn.Open();
        //        var command = new SqlCommand(sql.ToString(), conn);
        //        command.Parameters.Add(new SqlParameter("@cpf", SqlDbType.VarChar) { Value = cpf });
        //        var reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            //var pessoa = new Pessoa
        //            {
        //                pessoas.ID = reader.GetInt32(reader.GetOrdinal("PESS_ID_PK")),
        //                pessoas.Nome = reader.GetString(reader.GetOrdinal("PESS_NOM")),
        //                pessoas.CPF = reader.GetString(reader.GetOrdinal("PESS_CPF")),
        //                pessoas.Endereco = reader.GetInt32(reader.GetOrdinal("PESS_ENDE_ID_FK"))
        //            };

        //            //pessoas.Add(pessoa);
        //        }
        //    }
        //    return pessoas;
        //}
    }
}
