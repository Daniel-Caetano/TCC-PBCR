using ERP.Servico.Negocio;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ERP.Servicos
{
    public class RepositorioRecibo : Recibo
    {
        private const string select = "SELECT RE.[RECI_ID_PK], RE.[RECI_TIP], RE.[RECI_REC], RE.[RECI_REC_DOC], RE.[RECI_REC_END], RE.[RECI_REC_NUM], " +
            "RE.[RECI_REC_COM], RE.[RECI_REC_CEP], RE.[RECI_REC_BAI], RE.[RECI_REC_CID], RE.[RECI_REC_UF], RE.[RECI_PAG], RE.[RECI_PAG_DOC], " +
                "RE.[RECI_VAL], RE.[RECI_VAL_EXT], RE.[RECI_OBS], RE.[RECI_DAT] " +
                "FROM RECIBOS RE ";

        private readonly string _stringConexao;
        //UTILIZAR ORM (ENTITY)
        public RepositorioRecibo(string stringConexao)
        {
            _stringConexao = stringConexao;
        }

        // Lista todos os Recibos do Banco de Dados
        public List<Recibo> ListaRecibos()
        {
            var recibos = new List<Recibo>();
            var sql = new StringBuilder()
                .AppendLine(select);

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var recibo = new Recibo
                    {
                        //Recebedor
                        NumeroRecibo = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK")),
                        Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP")),
                        NomeRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC")),
                        CPF_CNPJRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_DOC")),
                        LogradouroRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_END")),
                        NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_NUM")),
                        ComplementoRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_COM")),
                        CEPRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_CEP")),
                        BairroRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_BAI")),
                        CidadeRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_CID")),
                        UFRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_UF")),

                        // Pagador
                        NomePagador = reader.GetString(reader.GetOrdinal("RECI_PAG")),
                        CPF_CNPJPagador = reader.GetString(reader.GetOrdinal("RECI_PAG_DOC")),

                        // Informações de valores e Observações
                        Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL")),
                        ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT")),
                        Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS")),
                        Data = reader.GetDateTime(reader.GetOrdinal("RECI_DAT"))
                    };

                    recibos.Add(recibo);
                }
            }
            return recibos;

        }

        // Busca por Recibo através do Numero identificado do mesmo
        public List<Recibo> BuscaReciboCompleto(int id)
        {
            var recibos = new List<Recibo>();
            var sql = new StringBuilder().
                AppendLine(select + "WHERE RE.[RECI_ID_PK] = @id ");

            using var conn = new SqlConnection(_stringConexao);
            conn.Open();
            var command = new SqlCommand(sql.ToString(), conn);
            command.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar) { Value = id });
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                {
                    var recibo = new Recibo
                    {
                        //Recebedor
                        NumeroRecibo = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK")),
                        Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP")),
                        NomeRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC")),
                        CPF_CNPJRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_DOC")),
                        LogradouroRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_END")),
                        NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_NUM")),
                        ComplementoRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_COM")),
                        CEPRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_CEP")),
                        BairroRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_BAI")),
                        CidadeRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_CID")),
                        UFRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_UF")),
                        // Pagador
                        NomePagador = reader.GetString(reader.GetOrdinal("RECI_PAG")),
                        CPF_CNPJPagador = reader.GetString(reader.GetOrdinal("RECI_PAG_DOC")),
                        Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL")),
                        ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT")),
                        Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS")),
                        Data = reader.GetDateTime(reader.GetOrdinal("RECI_DAT"))
                    };
                    recibos.Add(recibo);
                }
            }
            return recibos;

        }

        // Lista todos os Recibos do Tipo a Pagar
        public List<Recibo> BuscaReciboCompletoApagar()
        {
            var recibos = new List<Recibo>();
            var sql = new StringBuilder()
                .AppendLine(select + "WHERE RE.[RECI_TIP] = 'A Pagar' ");

            using var conn = new SqlConnection(_stringConexao);
            conn.Open();
            var command = new SqlCommand(sql.ToString(), conn);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                {
                    var recibo = new Recibo
                    {
                        //Recebedor
                        NumeroRecibo = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK")),
                        Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP")),
                        NomeRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC")),
                        CPF_CNPJRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_DOC")),
                        LogradouroRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_END")),
                        NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_NUM")),
                        ComplementoRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_COM")),
                        CEPRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_CEP")),
                        BairroRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_BAI")),
                        CidadeRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_CID")),
                        UFRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_UF")),
                        // Pagador
                        NomePagador = reader.GetString(reader.GetOrdinal("RECI_PAG")),
                        CPF_CNPJPagador = reader.GetString(reader.GetOrdinal("RECI_PAG_DOC")),
                        Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL")),
                        ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT")),
                        Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS")),
                        Data = reader.GetDateTime(reader.GetOrdinal("RECI_DAT"))
                    };
                    recibos.Add(recibo);
                }
            }
            return recibos;
        }

        // Lista todos os Recibos do Tipo a Receber
        public List<Recibo> BuscaReciboCompletoAreceber()
        {
            var recibos = new List<Recibo>();
            var sql = new StringBuilder()
                .AppendLine(select + " WHERE RE.[RECI_TIP] = 'A Receber' ");

            using var conn = new SqlConnection(_stringConexao);
            conn.Open();
            var command = new SqlCommand(sql.ToString(), conn);
            
            var reader = command.ExecuteReader();

            while (reader.Read())
            {

                var recibo = new Recibo
                {
                    //Recebedor
                    NumeroRecibo = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK")),
                    Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP")),
                    NomeRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC")),
                    CPF_CNPJRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_DOC")),
                    LogradouroRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_END")),
                    NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_NUM")),
                    ComplementoRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_COM")),
                    CEPRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_CEP")),
                    BairroRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_BAI")),
                    CidadeRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_CID")),
                    UFRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_UF")),
                    // Pagador
                    NomePagador = reader.GetString(reader.GetOrdinal("RECI_PAG")),
                    CPF_CNPJPagador = reader.GetString(reader.GetOrdinal("RECI_PAG_DOC")),
                    Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL")),
                    ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT")),
                    Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS")),
                    Data = reader.GetDateTime(reader.GetOrdinal("RECI_DAT"))
                };

                recibos.Add(recibo);
            }
            return recibos;
        }

        public List<Recibo> BuscaReciboPorCPF_CNPJ(string documento)
        {
            var recibos = new List<Recibo>();
            var sql = new StringBuilder()
                .AppendLine(select + " WHERE RE.[RECI_REC_DOC] = @documento ");

            using var conn = new SqlConnection(_stringConexao);
            conn.Open();
            var command = new SqlCommand(sql.ToString(), conn);
            command.Parameters.Add(new SqlParameter("@documento", SqlDbType.VarChar) { Value = documento });

            var reader = command.ExecuteReader();

            while (reader.Read())
            {

                var recibo = new Recibo
                {
                    //Recebedor
                    NumeroRecibo = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK")),
                    Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP")),
                    NomeRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC")),
                    CPF_CNPJRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_DOC")),
                    LogradouroRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_END")),
                    NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_NUM")),
                    ComplementoRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_COM")),
                    CEPRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_CEP")),
                    BairroRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_BAI")),
                    CidadeRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_CID")),
                    UFRecebedor = reader.GetString(reader.GetOrdinal("RECI_REC_UF")),
                    // Pagador
                    NomePagador = reader.GetString(reader.GetOrdinal("RECI_PAG")),
                    CPF_CNPJPagador = reader.GetString(reader.GetOrdinal("RECI_PAG_DOC")),
                    Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL")),
                    ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT")),
                    Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS")),
                    Data = reader.GetDateTime(reader.GetOrdinal("RECI_DAT"))
                };

                recibos.Add(recibo);
            }
            return recibos;
        }
    }
}   