using ERP.Servico.Negocio;
using System;
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

        private const string select = "SELECT RE.[RECI_ID_PK], RE.[RECI_TIP], RE.[RECI_REC], RE.[RECI_REC_DOC], RE.[RECI_REC_END], RE.[RECI_REC_NUM], " +
        "RE.[RECI_REC_COM], RE.[RECI_REC_CEP], RE.[RECI_REC_BAI], RE.[RECI_REC_CID], RE.[RECI_REC_UF], RE.[RECI_PAG], RE.[RECI_PAG_DOC], " +
        "RE.[RECI_VAL], RE.[RECI_VAL_EXT], RE.[RECI_OBS], RE.[RECI_DAT] " +
        "FROM RECIBOS RE ";

        // Recebe os dados do Banco de Dados
        private List<Recibo> Tabela(SqlDataReader reader)
        {
            var recibos = new List<Recibo>();
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
                        Observacao = reader.GetString(reader.GetOrdinal("RECI_OBS"))
                    };
                    recibos.Add(recibo);
                }
            }
            return recibos;
        }

        // Lista todos os Recibos do Banco de Dados
        public List<Recibo> ListaRecibos()
        {
            var tabelaRecibo = new RepositorioRecibo(_stringConexao);
            var sql = new StringBuilder()
                .AppendLine(select);

            using var conn = new SqlConnection(_stringConexao);
            conn.Open();
            var command = new SqlCommand(sql.ToString(), conn);
            var reader = command.ExecuteReader();
            List<Recibo> recibos = tabelaRecibo.Tabela(reader);
            return recibos;

        }

        // Busca por Recibo através do Numero identificado do mesmo
        public List<Recibo> BuscaReciboCompleto(int id)
        {
            var tabelaRecibo = new RepositorioRecibo(_stringConexao);
            var sql = new StringBuilder().
                AppendLine(select + "WHERE RE.[RECI_ID_PK] = @id ");

            using var conn = new SqlConnection(_stringConexao);
            conn.Open();

            var command = new SqlCommand(sql.ToString(), conn);
            _ = command.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar) { Value = id });

            var reader = command.ExecuteReader();
            List<Recibo> recibos = tabelaRecibo.Tabela(reader);
            return recibos;

        }

        // Lista todos os Recibos do Tipo a Pagar
        public List<Recibo> BuscaReciboCompletoApagar()
        {
            var tabelaRecibo = new RepositorioRecibo(_stringConexao);
            var sql = new StringBuilder()
                .AppendLine(select + "WHERE RE.[RECI_TIP] = 'A Pagar' ");

            using var conn = new SqlConnection(_stringConexao);
            conn.Open();

            var command = new SqlCommand(sql.ToString(), conn);
            var reader = command.ExecuteReader();

            List<Recibo> recibos = tabelaRecibo.Tabela(reader);

            return recibos;
        }

        // Lista todos os Recibos do Tipo a Receber
        public List<Recibo> BuscaReciboCompletoAreceber()
        {
            var tabelaRecibo = new RepositorioRecibo(_stringConexao);
            var sql = new StringBuilder()
                .AppendLine(select + " WHERE RE.[RECI_TIP] = 'A Receber' ");

            using var conn = new SqlConnection(_stringConexao);
            conn.Open();

            var command = new SqlCommand(sql.ToString(), conn);
            var reader = command.ExecuteReader();

            List<Recibo> recibos = tabelaRecibo.Tabela(reader);

            return recibos;
        }

        // Busca Recibos por CPF/CNPJ
        public List<Recibo> BuscaReciboCPF_CNPJ(string documento)
        {
            var tabelaRecibo = new RepositorioRecibo(_stringConexao);
            var sql = new StringBuilder()
                .AppendLine(select + " WHERE RE.[RECI_REC_DOC] = @documento OR RE.[RECI_PAG_DOC] = @documento");
            

            using var conn = new SqlConnection(_stringConexao);
            conn.Open();

            var command = new SqlCommand(sql.ToString(), conn);
            command.Parameters.Add(new SqlParameter("@documento", SqlDbType.VarChar) { Value = documento });

            var reader = command.ExecuteReader();
            List<Recibo> recibos = tabelaRecibo.Tabela(reader);

            return recibos;
        }

        // Busca Recibos por Nome/Razão Social
        public List<Recibo> BuscaReciboNome(string nome)
        {
            var tabelaRecibo = new RepositorioRecibo(_stringConexao);
            var sql = new StringBuilder()
                .AppendLine(select + " WHERE RE.[RECI_REC] = @nome OR RE.[RECI_PAG] = @nome");

            using var conn = new SqlConnection(_stringConexao);
            conn.Open();

            var command = new SqlCommand(sql.ToString(), conn);
            command.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar) { Value = nome });

            var reader = command.ExecuteReader();
            List<Recibo> recibos = tabelaRecibo.Tabela(reader);

            return recibos;
        }

        public void Adicionar(string Tipo, string Recebedor, string DocumentoRec, string EnderecoRec, string NumeroEndRec,
            string ComplementoRec, string CEPrec, string BairroRec, string CidadeRec, string UFrec, string Pagador, string DocumentoPag,
            decimal Valor, string ValorExtenso, string Observacao, string CidadeRecibo, string UFrecibo)
        {
            string MaxID = "SELECT MAX(RECI_ID_PK) FROM RECIBOS";

            int ID_Reci = 0;

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open(); // abre conexão

                // cria objeto do tipo SqlCommand
                using (var command = new SqlCommand(MaxID, conn))
                {
                    // variável quantidade recebe o resultado da execução do método ExecuteScalar
                    ID_Reci = (int)command.ExecuteScalar() + 1;

                }
                conn.Close();
            }
            var sqlReci = new StringBuilder()
                .AppendLine("INSERT INTO RECIBOS (RECI_TIP, RECI_REC, RECI_REC_DOC, RECI_REC_END, RECI_REC_NUM, RECI_REC_COM, RECI_REC_CEP, " +
                "RECI_REC_BAI, RECI_REC_CID,RECI_REC_UF, RECI_PAG, RECI_PAG_DOC, RECI_VAL, RECI_VAL_EXT, RECI_OBS, RECI_CID, RECI_UF) " +
                "VALUES (@Tipo, @Recebedor, @DocumentoRec, @EnderecoRec, @NumeroEndRec, @ComplementoRec, @CEPrec, @BairroRec, @CidadeRec, @UFrec, " +
                "@Pagador, @DocumentoPag , @Valor , @ValorExtenso , @Observacao , @CidadeRecibo , @UFrecibo) ");
            
            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sqlReci.ToString(), conn);
                command.Parameters.AddWithValue("@Tipo ", Tipo);
                command.Parameters.AddWithValue("@Recebedor ", Recebedor);
                command.Parameters.AddWithValue("@DocumentoRec ", DocumentoRec);
                command.Parameters.AddWithValue("@EnderecoRec ", EnderecoRec);
                command.Parameters.AddWithValue("@NumeroEndRec ", NumeroEndRec);
                command.Parameters.AddWithValue("@ComplementoRec ", ComplementoRec);
                command.Parameters.AddWithValue("@CEPrec ", CEPrec);
                command.Parameters.AddWithValue("@BairroRec ", BairroRec);
                command.Parameters.AddWithValue("@CidadeRec ", CidadeRec);
                command.Parameters.AddWithValue("@UFrec ", UFrec);
                command.Parameters.AddWithValue("@Pagador ", Pagador);
                command.Parameters.AddWithValue("@DocumentoPag ", DocumentoPag);
                command.Parameters.AddWithValue("@Valor ", Valor);
                command.Parameters.AddWithValue("@ValorExtenso ", ValorExtenso);
                command.Parameters.AddWithValue("@Observacao ", Observacao);
                command.Parameters.AddWithValue("@CidadeRecibo ", CidadeRecibo);
                command.Parameters.AddWithValue("@UFrecibo ", UFrecibo);
                var reader = command.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            var sql = new StringBuilder().AppendLine("DELETE FROM RECIBOS WHERE RECI_ID_PK = @id ");

            using (var conn = new SqlConnection(_stringConexao))
            {
                var command = new SqlCommand(sql.ToString(), conn);
                conn.Open();
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar) { Value = id });
                var reader = command.ExecuteReader();
                reader.Read();
            }
        }

    }
}