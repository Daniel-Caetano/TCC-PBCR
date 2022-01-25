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

        public Recibo BuscaRecibo(int id)
        {
            var recibo = new Recibo();
            var sql = new StringBuilder()
                .AppendLine("SELECT RE.[RECI_ID_PK], RE.[RECI_TIP], RE.[RECI_CID], RE.[RECI_UF], RE.[RECI_VAL], RE.[RECI_VAL_EXT], RE.[RECI_OBS], RE.[RECI_DAT] " +
                "FROM RECIBOS RE " +
                "WHERE RE.[RECI_ID_PK] = @id");

            using var conn = new SqlConnection(_stringConexao);
            conn.Open();
            var command = new SqlCommand(sql.ToString(), conn);
            command.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar) { Value = id });
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                //Recebedor
                recibo.NumeroRecibo = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK"));
                recibo.Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP"));
                recibo.CidadeRecebedor = reader.GetString(reader.GetOrdinal("RECI_CID"));
                recibo.UFRecebedor = reader.GetString(reader.GetOrdinal("RECI_UF"));
                //Pagador
                recibo.Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL"));
                recibo.ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT"));
                recibo.Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"));
                Data = reader.GetDateTime(reader.GetOrdinal("RECI_DAT"));
            }
            return recibo;
        }

        public List<Recibo> BuscaReciboCompleto(int id)
        {
            var recibos = new List<Recibo>(); ;
            var sql = new StringBuilder()
                .AppendLine("SELECT RE.[RECI_ID_PK], RE.[RECI_TIP], PE.[PESS_NOM], PE.[PESS_CPF], CO.[CODI_LOG], EN.[ENDE_NUM], EN.[ENDE_COM], CO.[CODI_CEP], CO.[CODI_BAI], " +
                "CO.[CODI_LOC], CO.[CODI_UF], EM.[EMPR_RAZ], EM.[EMPR_CNPJ], RE.[RECI_VAL], RE.[RECI_VAL_EXT], RE.[RECI_OBS] " +
                "FROM RECIBOS RE " +
                "INNER JOIN RECEBEDOR REC " +
                "ON RE.RECI_RECE_ID_FK = REC.RECE_ID_PK INNER JOIN PESSOAS PE " +
                "ON REC.RECE_PESS_ID_FK = PE.[PESS_ID_PK] INNER JOIN ENDERECOS EN " +
                "ON PE.[PESS_ENDE_ID_FK] = EN.[ENDE_ID_PK] INNER JOIN CODIGOS_POSTAIS CO " +
                "ON EN.[ENDE_CODI_ID_FK] = CO.[CODI_ID_PK] INNER JOIN PAGADOR PA " +
                "ON RE.[RECI_PAGA_ID_FK] = PA.[PAGA_ID_PK] INNER JOIN EMPRESAS EM " +
                "ON PA.[PAGA_EMPR_ID_FK] = EM.[EMPR_ID_PK] " +
                "WHERE RE.[RECI_ID_PK] = @id");

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
                        NomeRecebedor = reader.GetString(reader.GetOrdinal("PESS_NOM")),
                        CPF_CNPJRecebedor = reader.GetString(reader.GetOrdinal("PESS_CPF")),
                        LogradouroRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOG")),
                        NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_NUM")),
                        ComplementoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_COM")),
                        CEPRecebedor = reader.GetString(reader.GetOrdinal("CODI_CEP")),
                        BairroRecebedor = reader.GetString(reader.GetOrdinal("CODI_BAI")),
                        CidadeRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOC")),
                        UFRecebedor = reader.GetString(reader.GetOrdinal("CODI_UF")),
                        // Pagador
                         NomePagador = reader.GetString(reader.GetOrdinal("EMPR_RAZ")),
                        CPF_CNPJPagador = reader.GetString(reader.GetOrdinal("EMPR_CNPJ")),
                        Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL")),
                        ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT")),
                        Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"))
                    };
                    recibos.Add(recibo);
                }
            }
            return recibos;
        }

        public List<Recibo> BuscaRecibosPagarCpf(string cpf)
        {
            var recibos = new List<Recibo>();
            var sql = new StringBuilder()
                .AppendLine("SELECT RE.[RECI_ID_PK], RE.[RECI_TIP], PE.[PESS_NOM], PE.[PESS_CPF], CO.[CODI_LOG], EN.[ENDE_NUM], EN.[ENDE_COM], CO.[CODI_CEP], CO.[CODI_BAI], " +
                "CO.[CODI_LOC], CO.[CODI_UF], EM.[EMPR_RAZ], EM.[EMPR_CNPJ], RE.[RECI_VAL], RE.[RECI_VAL_EXT], RE.[RECI_OBS] " +
                "FROM RECIBOS RE " +
                "INNER JOIN RECEBEDOR REC " +
                "ON RE.RECI_RECE_ID_FK = REC.RECE_ID_PK INNER JOIN PESSOAS PE " +
                "ON REC.RECE_PESS_ID_FK = PE.[PESS_ID_PK] INNER JOIN ENDERECOS EN " +
                "ON PE.[PESS_ENDE_ID_FK] = EN.[ENDE_ID_PK] INNER JOIN CODIGOS_POSTAIS CO " +
                "ON EN.[ENDE_CODI_ID_FK] = CO.[CODI_ID_PK] INNER JOIN PAGADOR PA " +
                "ON RE.[RECI_PAGA_ID_FK] = PA.[PAGA_ID_PK] INNER JOIN EMPRESAS EM " +
                "ON PA.[PAGA_EMPR_ID_FK] = EM.[EMPR_ID_PK] " +
                "WHERE PE.[PESS_CPF] = @cpf");

            using var conn = new SqlConnection(_stringConexao);
            conn.Open();
            var command = new SqlCommand(sql.ToString(), conn);
            command.Parameters.Add(new SqlParameter("@cpf", SqlDbType.VarChar) { Value = cpf });
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var recibo = new Recibo
                {
                    //Recebedor
                    NumeroRecibo = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK")),
                    Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP")),
                    NomeRecebedor = reader.GetString(reader.GetOrdinal("PESS_NOM")),
                    CPF_CNPJRecebedor = reader.GetString(reader.GetOrdinal("PESS_CPF")),
                    LogradouroRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOG")),
                    NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_NUM")),
                    ComplementoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_COM")),
                    CEPRecebedor = reader.GetString(reader.GetOrdinal("CODI_CEP")),
                    BairroRecebedor = reader.GetString(reader.GetOrdinal("CODI_BAI")),
                    CidadeRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOC")),
                    UFRecebedor = reader.GetString(reader.GetOrdinal("CODI_UF")),
                    // Pagador
                    NomePagador = reader.GetString(reader.GetOrdinal("EMPR_RAZ")),
                    CPF_CNPJPagador = reader.GetString(reader.GetOrdinal("EMPR_CNPJ")),
                    Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL")),
                    ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT")),
                    Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"))
                };

                recibos.Add(recibo);
            }
            return recibos;
        }

        public Recibo BuscaReciboPagarCpf(string cpf)
        {
            var recibo = new Recibo();
            var sql = new StringBuilder()
                .AppendLine("SELECT RE.[RECI_ID_PK], RE.[RECI_TIP], PE.[PESS_NOM], PE.[PESS_CPF], CO.[CODI_LOG], EN.[ENDE_NUM], EN.[ENDE_COM], CO.[CODI_CEP], CO.[CODI_BAI], " +
                "CO.[CODI_LOC], CO.[CODI_UF], EM.[EMPR_RAZ], EM.[EMPR_CNPJ], RE.[RECI_VAL], RE.[RECI_VAL_EXT], RE.[RECI_OBS] " +
                "FROM RECIBOS RE " +
                "INNER JOIN RECEBEDOR REC " +
                "ON RE.RECI_RECE_ID_FK = REC.RECE_ID_PK INNER JOIN PESSOAS PE " +
                "ON REC.RECE_PESS_ID_FK = PE.[PESS_ID_PK] INNER JOIN ENDERECOS EN " +
                "ON PE.[PESS_ENDE_ID_FK] = EN.[ENDE_ID_PK] INNER JOIN CODIGOS_POSTAIS CO " +
                "ON EN.[ENDE_CODI_ID_FK] = CO.[CODI_ID_PK] INNER JOIN PAGADOR PA " +
                "ON RE.[RECI_PAGA_ID_FK] = PA.[PAGA_ID_PK] INNER JOIN EMPRESAS EM " +
                "ON PA.[PAGA_EMPR_ID_FK] = EM.[EMPR_ID_PK] " +
                "WHERE PE.[PESS_CPF] = @cpf");

            using var conn = new SqlConnection(_stringConexao);
            conn.Open();
            var command = new SqlCommand(sql.ToString(), conn);
            command.Parameters.Add(new SqlParameter("@cpf", SqlDbType.VarChar) { Value = cpf });
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                {

                    //Recebedor
                    NumeroRecibo = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK"));
                    Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP"));
                    NomeRecebedor = reader.GetString(reader.GetOrdinal("PESS_NOM"));
                    CPF_CNPJRecebedor = reader.GetString(reader.GetOrdinal("PESS_CPF"));
                    LogradouroRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOG"));
                    NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_NUM"));
                    ComplementoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_COM"));
                    CEPRecebedor = reader.GetString(reader.GetOrdinal("CODI_CEP"));
                    BairroRecebedor = reader.GetString(reader.GetOrdinal("CODI_BAI"));
                    CidadeRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOC"));
                    UFRecebedor = reader.GetString(reader.GetOrdinal("CODI_UF"));
                    // Pagador
                    NomePagador = reader.GetString(reader.GetOrdinal("EMPR_RAZ"));
                    CPF_CNPJPagador = reader.GetString(reader.GetOrdinal("EMPR_CNPJ"));
                    Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL"));
                    ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT"));
                    Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"));
                }
            }
            return recibo;
        }

        public Recibo BuscaReciboReceberCpf(string cpf)
        {
            var recibo = new Recibo();
            var sql = new StringBuilder()
                .AppendLine("SELECT RE.[RECI_ID_PK], RE.[RECI_TIP], PE.[PESS_NOM], PE.[PESS_CPF], CO.[CODI_LOG], EN.[ENDE_NUM], EN.[ENDE_COM], CO.[CODI_CEP], CO.[CODI_BAI], " +
                "CO.[CODI_LOC], CO.[CODI_UF], EM.[EMPR_RAZ], EM.[EMPR_CNPJ], RE.[RECI_VAL], RE.[RECI_VAL_EXT], RE.[RECI_OBS] " +
                "FROM RECIBOS RE " +
                "INNER JOIN PAGADOR PA " +
                "ON RE.[] " +
                " " +
                " " +
                " " +
                " " +
                " " +
                "WHERE PE.[PESS_CPF] = @cpf");

            using var conn = new SqlConnection(_stringConexao);
            conn.Open();
            var command = new SqlCommand(sql.ToString(), conn);
            command.Parameters.Add(new SqlParameter("@cpf", SqlDbType.VarChar) { Value = cpf });
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                {
                    //Recebedor
                    NumeroRecibo = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK"));
                    Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP"));
                    NomeRecebedor = reader.GetString(reader.GetOrdinal("PESS_NOM"));
                    CPF_CNPJRecebedor = reader.GetString(reader.GetOrdinal("PESS_CPF"));
                    LogradouroRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOG"));
                    NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_NUM"));
                    ComplementoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_COM"));
                    CEPRecebedor = reader.GetString(reader.GetOrdinal("CODI_CEP"));
                    BairroRecebedor = reader.GetString(reader.GetOrdinal("CODI_BAI"));
                    CidadeRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOC"));
                    UFRecebedor = reader.GetString(reader.GetOrdinal("CODI_UF"));
                    // Pagador
                    NomePagador = reader.GetString(reader.GetOrdinal("EMPR_RAZ"));
                    CPF_CNPJPagador = reader.GetString(reader.GetOrdinal("EMPR_CNPJ"));
                    Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL"));
                    ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT"));
                    Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"));
                }
            }
            return recibo;
        }

        public List<Recibo> BuscaReciboCnpj(string cnpj)
        {
            var recibos = new List<Recibo>();
            var sql = new StringBuilder()
                .AppendLine("SELECT R.[RECI_ID_PK], R.[RECI_TIP], EM.[EMPR_RAZ], EM.[EMPR_CNPJ], C.[CODI_LOG], E.[ENDE_NUM], E.[ENDE_COM], C.[CODI_CEP], C.[CODI_BAI], " +
                "C.[CODI_LOC], C.[CODI_UF], EM.[EMPR_RAZ], EM.[EMPR_CNPJ], R.[RECI_VAL], R.[RECI_VAL_EXT], R.[RECI_OBS]" +
                "FROM EMPRESAS EM" +
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
                var recibo = new Recibo
                {
                    //Recebedor
                    NumeroRecibo = reader.GetInt32(reader.GetOrdinal("RECI_ID_PK")),
                    Tipo = reader.GetString(reader.GetOrdinal("RECI_TIP")),
                    NomeRecebedor = reader.GetString(reader.GetOrdinal("EMPR_RAZ")),
                    CPF_CNPJRecebedor = reader.GetString(reader.GetOrdinal("EMPR_CNPJ")),
                    LogradouroRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOG")),
                    NumeroEnderecoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_NUM")),
                    ComplementoRecebedor = reader.GetString(reader.GetOrdinal("ENDE_COM")),
                    CEPRecebedor = reader.GetString(reader.GetOrdinal("CODI_CEP")),
                    BairroRecebedor = reader.GetString(reader.GetOrdinal("CODI_BAI")),
                    CidadeRecebedor = reader.GetString(reader.GetOrdinal("CODI_LOC")),
                    UFRecebedor = reader.GetString(reader.GetOrdinal("CODI_UF")),
                    // Pagador
                    NomePagador = reader.GetString(reader.GetOrdinal("EMPR_RAZ")),
                    CPF_CNPJPagador = reader.GetString(reader.GetOrdinal("EMPR_CNPJ")),
                    Valor = reader.GetDecimal(reader.GetOrdinal("RECI_VAL")),
                    ValorExtenso = reader.GetString(reader.GetOrdinal("RECI_VAL_EXT")),
                    Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"))
                };
                recibos.Add(recibo);
            }
            return recibos;
        }
    }
}