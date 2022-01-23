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

        public Recibo ReciboReceberCNPJ(int id)
        {
            var recibo = new Recibo();
            var sql = new StringBuilder()
                .AppendLine("SELECT R.[RECI_TIP], EM.[EMPR_RAZ], EM.[EMPR_CNPJ], C.[CODI_LOG], E.[ENDE_NUM], E.[ENDE_COM], C.[CODI_CEP], C.[CODI_BAI], " +
                "C.[CODI_LOC], C.[CODI_UF], EM.[EMPR_RAZ], EM.[EMPR_CNPJ], R.[RECI_VAL], R.[RECI_VAL_EXT], R.[RECI_OBS]" +
                "FROM EMPRESAS EM " +
                "INNER JOIN RECIBOS R " +
                "ON R.[RECI_EMPR_ID_FK] = EM.[EMPR_ID_PK] " +
                "INNER JOIN ENDERECOS E " +
                "ON EM.[EMPR_ENDE_ID_FK] = E.[ENDE_ID_PK] " +
                "INNER JOIN [CODIGOS_POSTAIS] C " +
                "ON C.[CODI_ID_PK] = E.[ENDE_CODI_ID_FK] " +
                "WHERE R.[RECI_ID_PK] = @id");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar) { Value = id });
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //Recebedor
                    recibo.Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP"));
                    recibo.NomeRecebedor = reader.GetString(reader.GetOrdinal("EMPR_RAZ"));
                    recibo.CPF_CNPJRecebedor = reader.GetString(reader.GetOrdinal("EMPR_CNPJ"));
                    recibo.LogradouroRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOG"));
                    recibo.NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_NUM"));
                    recibo.ComplementoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_COM"));
                    recibo.CEPRecebedor = reader.GetString(reader.GetOrdinal("CODI_CEP"));
                    recibo.BairroRecebedor = reader.GetString(reader.GetOrdinal("CODI_BAI"));
                    recibo.CidadeRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOC"));
                    recibo.UFRecebedor = reader.GetString(reader.GetOrdinal("CODI_UF"));
                    // Pagador
                    recibo.NomePagador = reader.GetString(reader.GetOrdinal("EMPR_RAZ"));
                    recibo.CPF_CNPJPagador = reader.GetString(reader.GetOrdinal("EMPR_CNPJ"));
                    recibo.Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL"));
                    recibo.ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT"));
                    recibo.Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"));
                }
            }
            return recibo;
        }

        public Recibo ReciboReceberCPF(int id)
        {
            var recibo = new Recibo();
            var sql = new StringBuilder()
                .AppendLine("SELECT R.[RECI_TIP], EM.[EMPR_RAZ], EM.[EMPR_CNPJ], C.[CODI_LOG], E.[ENDE_NUM], E.[ENDE_COM], C.[CODI_CEP], C.[CODI_BAI], " +
                "C.[CODI_LOC], C.[CODI_UF], PE.[PESS_NOM], PE.[PESS_CPF], R.[RECI_VAL], R.[RECI_VAL_EXT], R.[RECI_OBS]" +
                "FROM PESSOAS PE, EMPRESAS EM " +
                "INNER JOIN RECIBOS R " +
                "ON R.[RECI_EMPR_ID_FK] = EM.[EMPR_ID_PK] " +
                "INNER JOIN ENDERECOS E " +
                "ON EM.[EMPR_ENDE_ID_FK] = E.[ENDE_ID_PK] " +
                "INNER JOIN [CODIGOS_POSTAIS] C " +
                "ON C.[CODI_ID_PK] = E.[ENDE_CODI_ID_FK] " +
                "WHERE R.[RECI_ID_PK] = @id");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar) { Value = id });
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //Recebedor
                    recibo.Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP"));
                    recibo.NomeRecebedor = reader.GetString(reader.GetOrdinal("EMPR_RAZ"));
                    recibo.CPF_CNPJRecebedor = reader.GetString(reader.GetOrdinal("EMPR_CNPJ"));
                    recibo.LogradouroRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOG"));
                    recibo.NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_NUM"));
                    recibo.ComplementoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_COM"));
                    recibo.CEPRecebedor = reader.GetString(reader.GetOrdinal("CODI_CEP"));
                    recibo.BairroRecebedor = reader.GetString(reader.GetOrdinal("CODI_BAI"));
                    recibo.CidadeRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOC"));
                    recibo.UFRecebedor = reader.GetString(reader.GetOrdinal("CODI_UF"));
                    // Pagador
                    recibo.NomePagador = reader.GetString(reader.GetOrdinal("PESS_NOM"));
                    recibo.CPF_CNPJPagador = reader.GetString(reader.GetOrdinal("PESS_CPF"));
                    recibo.Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL"));
                    recibo.ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT"));
                    recibo.Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"));
                }
            }
            return recibo;
        }
    }
}