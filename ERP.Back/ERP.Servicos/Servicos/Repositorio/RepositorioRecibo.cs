﻿using ERP.Servico.Negocio;
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
<<<<<<< HEAD
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
=======
                    var recibo = new Recibo();
                  
                    recibo.Numero = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK"));
                    recibo.Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP"));
                    recibo.Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL"));
                    recibo.ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT"));
                    recibo.Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"));
                    recibo.Cidade = reader.GetString(reader.GetOrdinal("RECI_CID"));
                    recibo.Estado = reader.GetString(reader.GetOrdinal("RECI_UF"));
                    recibo.Data = reader.GetDateTime(reader.GetOrdinal("RECI_DAT"));
>>>>>>> 454f609ec64146b340ff674f02ff02873e0405d1

                    recibos.Add(recibo);
                }
            }
            return recibos;

        }
    }
}
