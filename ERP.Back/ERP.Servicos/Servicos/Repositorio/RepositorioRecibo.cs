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

        public List<Recibo> ListaRecibos()
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
                        NumeroRecibo = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK")),
                        Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP")),
                        Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL")),
                        ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT")),
                        Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS")),
                        CidadeRecebedor = reader.GetString(reader.GetOrdinal("RECI_CID")),
                        UFRecebedor = reader.GetString(reader.GetOrdinal("RECI_UF")),
                        Data = reader.GetDateTime(reader.GetOrdinal("RECI_DAT"))
                    };

                    recibos.Add(recibo);
                }
            }
            return recibos;

        }

        public Recibo BuscaRecibo(int id)
        {
            var recibo = new Recibo();
            var sql = new StringBuilder()
                .AppendLine("SELECT * FROM RECIBOS RE WHERE RE.[RECI_ID_PK] = @id");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar) { Value = id });
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //var pessoa = new Pessoa();
                    recibo.NumeroRecibo = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK"));
                    recibo.Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP"));
                    recibo.Valor = reader.GetDecimal (reader.GetOrdinal("RECI_VAL"));
                    recibo.ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT"));
                    recibo.Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"));
                    recibo.CidadeRecebedor = reader.GetString(reader.GetOrdinal("RECI_CID"));
                    recibo.UFRecebedor = reader.GetString(reader.GetOrdinal("RECI_UF"));
                    recibo.Data = reader.GetDateTime(reader.GetOrdinal("RECI_DAT"));

                    //pessoas.Add(pessoa);
                }
            }
            return recibo;
        }

        //public Recibo ReceberRecibo(int id)
        //{
        //    var recibo = new Recibo();
        //    var sql = new StringBuilder()
        //        .AppendLine("SELECT RE.[RECI_ID_PK], RE.[RECI_TIP], EM.[EMPR_CNPJ]" +
        //        "FROM  RECIBOS RE " +
        //        "INNER JOIN EMPRESAS EM " +
        //        "ON EM.[EMPRE_DI_PK] = RE.[RECI_EMPR_FK] " +
        //        "INNER JOIN ENDERECOS EN " +
        //        "ON EM.[EMPR_ENDE_ID_FK] = EN.[ENDE_ID_PK] " +
        //        "INNER JOIN [CODIGOS_POSTAI] CO " +
        //        "ON EN.[ENDE_CODI_ID_FK] = CO.[CODI_ID_PK] " +
        //        "WHERE RE.[RECI_ID_PK] = @id");

        //    using (var conn = new SqlConnection(_stringConexao))
        //    {
        //        conn.Open();
        //        var command = new SqlCommand(sql.ToString(), conn);
        //        command.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar) { Value = id });
        //        var reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            Recebedor
        //            recibo.NumeroRecibo = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK"));
        //            recibo.Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP"));
        //            recibo.NomeRecebedor = reader.GetString(reader.GetOrdinal(""));
        //            recibo.CPFCNPJRecebedor = reader.GetString(reader.GetOrdinal(""));
        //            recibo.LogradouroRecebedor = reader.GetString(reader.GetOrdinal(""));
        //            recibo.NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal(""));
        //            recibo.ComplementoRecebedor = reader.GetString(reader.GetOrdinal(""));
        //            recibo.CEPRecebedor = reader.GetString(reader.GetOrdinal(""));
        //            recibo.BairroRecebedor = reader.GetString(reader.GetOrdinal(""));
        //            recibo.CidadeRecebedor = reader.GetString(reader.GetOrdinal(""));
        //            recibo.UFRecebedor = reader.GetString(reader.GetOrdinal(""));
        //            Pagador
        //            recibo.NomePagador = reader.GetString(reader.GetOrdinal(""));
        //            recibo.CPFCNPJPagador = reader.GetString(reader.GetOrdinal(""));
        //            recibo.Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL"));
        //            recibo.ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT"));
        //            recibo.Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"));
        //            recibo.CidadeCorrente = reader.GetString(reader.GetOrdinal(""));
        //            recibo.UFCorrente = reader.GetString(reader.GetOrdinal(""));
        //            recibo.Data = reader.GetDateTime(reader.GetOrdinal(""));
        //        }
        //    }
        //    return recibo;
        //}

        //public Recibo Pagar PagarRecibo()
        //{

        //}
    }
}
