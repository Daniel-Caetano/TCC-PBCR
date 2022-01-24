using ERP.Servico.Negocio;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ERP.Servicos
{
    public class RepositorioRecibo : Recibo
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

        public Recibo BuscaRecibo(string cnpj)
        {
            var recibo = new Recibo();
            var sql = new StringBuilder()
                .AppendLine("SELECT R.[RECI_ID_PK], R.[RECI_TIP], C.[CODI_LOC], C.[CODI_UF], R.[RECI_VAL], R.[RECI_VAL_EXT], R.[RECI_OBS], R.[RECI_DAT]" +
                "FROM PESSOAS PE, EMPRESAS EM " +
                "INNER JOIN RECIBOS R " +
                "ON R.[RECI_EMPR_ID_FK] = EM.[EMPR_ID_PK] " +
                "INNER JOIN ENDERECOS E " +
                "ON EM.[EMPR_ENDE_ID_FK] = E.[ENDE_ID_PK] " +
                "INNER JOIN [CODIGOS_POSTAIS] C " +
                "ON C.[CODI_ID_PK] = E.[ENDE_CODI_ID_FK] " +
                "WHERE EM.[EMPR_CNPJ] = @cnpj");

            using var conn = new SqlConnection(_stringConexao);
            conn.Open();
            var command = new SqlCommand(sql.ToString(), conn);
            command.Parameters.Add(new SqlParameter("@cnpj", SqlDbType.VarChar) { Value = cnpj });
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                //Recebedor
                recibo.NumeroRecibo = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK"));
                recibo.Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP"));
                //recibo.NomeRecebedor = reader.GetString(reader.GetOrdinal("EMPR_RAZ"));
                //recibo.CPF_CNPJRecebedor = reader.GetString(reader.GetOrdinal("EMPR_CNPJ"));
                //recibo.LogradouroRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOG"));
                //recibo.NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_NUM"));
                //recibo.ComplementoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_COM"));
                //recibo.CEPRecebedor = reader.GetString(reader.GetOrdinal("CODI_CEP"));
                //recibo.BairroRecebedor = reader.GetString(reader.GetOrdinal("CODI_BAI"));
                recibo.CidadeRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOC"));
                recibo.UFRecebedor = reader.GetString(reader.GetOrdinal("CODI_UF"));
                // Pagador
                //recibo.NomePagador = reader.GetString(reader.GetOrdinal("PESS_NOM"));
                //recibo.CPF_CNPJPagador = reader.GetString(reader.GetOrdinal("PESS_CPF"));
                recibo.Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL"));
                recibo.ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT"));
                recibo.Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"));
                Data = reader.GetDateTime(reader.GetOrdinal("RECI_DAT"));
            }
            return recibo;
        }

        //public List<Recibo> BuscaReciboCpf(string cpf)
        //{
        //    var recibos = new List<Recibo>();
        //    var sql = new StringBuilder()
        //        .AppendLine("SELECT R.[RECI_ID_PK], R.[RECI_TIP], EM.[EMPR_RAZ], EM.[EMPR_CNPJ], C.[CODI_LOG], E.[ENDE_NUM], E.[ENDE_COM], C.[CODI_CEP], C.[CODI_BAI], " +
        //        "C.[CODI_LOC], C.[CODI_UF], PE.[PESS_NOM], PE.[PESS_CPF], R.[RECI_VAL], R.[RECI_VAL_EXT], R.[RECI_OBS]" +
        //        "FROM PESSOAS PE, EMPRESAS EM " +
        //        "INNER JOIN RECIBOS R " +
        //        "ON R.[RECI_EMPR_ID_FK] = EM.[EMPR_ID_PK] " +
        //        "INNER JOIN ENDERECOS E " +
        //        "ON EM.[EMPR_ENDE_ID_FK] = E.[ENDE_ID_PK] " +
        //        "INNER JOIN [CODIGOS_POSTAIS] C " +
        //        "ON C.[CODI_ID_PK] = E.[ENDE_CODI_ID_FK] " +
        //        "WHERE PE.[PESS_CPF] = @cpf");

        //    using var conn = new SqlConnection(_stringConexao);
        //    conn.Open();
        //    var command = new SqlCommand(sql.ToString(), conn);
        //    command.Parameters.Add(new SqlParameter("@cpf", SqlDbType.VarChar) { Value = cpf });
        //    var reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        var recibo = new Recibo
        //        {
        //            //Recebedor
        //            NumeroRecibo = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK")),
        //            Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP")),
        //            NomeRecebedor = reader.GetString(reader.GetOrdinal("EMPR_RAZ")),
        //            CPF_CNPJRecebedor = reader.GetString(reader.GetOrdinal("EMPR_CNPJ")),
        //            LogradouroRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOG")),
        //            NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_NUM")),
        //            ComplementoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_COM")),
        //            CEPRecebedor = reader.GetString(reader.GetOrdinal("CODI_CEP")),
        //            BairroRecebedor = reader.GetString(reader.GetOrdinal("CODI_BAI")),
        //            CidadeRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOC")),
        //            UFRecebedor = reader.GetString(reader.GetOrdinal("CODI_UF")),
        //            // Pagador
        //            NomePagador = reader.GetString(reader.GetOrdinal("PESS_NOM")),
        //            CPF_CNPJPagador = reader.GetString(reader.GetOrdinal("PESS_CPF")),
        //            Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL")),
        //            ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT")),
        //            Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"))
        //        };

        //        recibos.Add(recibo);
        //    }
        //    return recibos;
        //}

        //public List<Recibo> BuscaReciboCnpj(string cnpj)
        //{
        //    var recibos = new List<Recibo>();
        //    var sql = new StringBuilder()
        //        .AppendLine("SELECT R.[RECI_TIP], EM.[EMPR_RAZ], EM.[EMPR_CNPJ], C.[CODI_LOG], E.[ENDE_NUM], E.[ENDE_COM], C.[CODI_CEP], C.[CODI_BAI], " +
        //        "C.[CODI_LOC], C.[CODI_UF], EM.[EMPR_RAZ], EM.[EMPR_CNPJ], R.[RECI_VAL], R.[RECI_VAL_EXT], R.[RECI_OBS]" +
        //        "FROM EMPRESAS EM" +
        //        "INNER JOIN RECIBOS R " +
        //        "ON R.[RECI_EMPR_ID_FK] = EM.[EMPR_ID_PK] " +
        //        "INNER JOIN ENDERECOS E " +
        //        "ON EM.[EMPR_ENDE_ID_FK] = E.[ENDE_ID_PK] " +
        //        "INNER JOIN [CODIGOS_POSTAIS] C " +
        //        "ON C.[CODI_ID_PK] = E.[ENDE_CODI_ID_FK] " +
        //        "WHERE EM.[EMPR_CNPJ] = @cnpj");

        //    using var conn = new SqlConnection(_stringConexao);
        //    conn.Open();
        //    var command = new SqlCommand(sql.ToString(), conn);
        //    command.Parameters.Add(new SqlParameter("@cnpj", SqlDbType.VarChar) { Value = cnpj });
        //    var reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        var recibo = new Recibo
        //        {
        //            //Recebedor
        //            Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP")),
        //            NomeRecebedor = reader.GetString(reader.GetOrdinal("EMPR_RAZ")),
        //            CPF_CNPJRecebedor = reader.GetString(reader.GetOrdinal("EMPR_CNPJ")),
        //            LogradouroRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOG")),
        //            NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_NUM")),
        //            ComplementoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_COM")),
        //            CEPRecebedor = reader.GetString(reader.GetOrdinal("CODI_CEP")),
        //            BairroRecebedor = reader.GetString(reader.GetOrdinal("CODI_BAI")),
        //            CidadeRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOC")),
        //            UFRecebedor = reader.GetString(reader.GetOrdinal("CODI_UF")),
        //            // Pagador
        //            NomePagador = reader.GetString(reader.GetOrdinal("EMPR_RAZ")),
        //            CPF_CNPJPagador = reader.GetString(reader.GetOrdinal("EMPR_CNPJ")),
        //            Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL")),
        //            ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT")),
        //            Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"))
        //        };
        //        recibos.Add(recibo);
        //    }
        //    return recibos;
        //}
    }
}