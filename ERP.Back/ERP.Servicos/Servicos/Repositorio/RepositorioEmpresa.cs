using ERP.Servico.Negocio;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ERP.Servico.Servicos.Repositorio
{
    public class RepositorioEmpresa
    {
        private readonly string _stringConexao;
        //UTILIZAR ORM (ENTITY)

        //Construtor sempre preca da string de conexão do banco de dados
        public RepositorioEmpresa(string stringConexao)
        {
            _stringConexao = stringConexao;
        }

        //variavel select que guarda um comando SQL comum entre as funções
        private readonly string select = "SELECT es.EMPR_ID_PK , es.EMPR_RAZ ,es.EMPR_CNPJ, ENDE_ID_PK ,e.ENDE_NUM, e.ENDE_COM , CODI_ID_PK ,cp.CODI_CEP , cp.CODI_LOG , cp.CODI_BAI , cp.CODI_LOC , cp.CODI_UF " +
                            "FROM EMPRESAS es " +
                            "INNER JOIN ENDERECOS e ON ENDE_ID_PK = EMPR_ENDE_ID_FK " +
                            "INNER JOIN CODIGOS_POSTAIS cp ON cp.CODI_ID_PK = e.ENDE_CODI_ID_FK ";


        //Função para receber valores da tabela do BD, criada para não precisar repetir o codigo várias vezes
        public List<Empresa> RecebeTabela(SqlDataReader reader)
        {
            var empresas = new List<Empresa>();
            while (reader.Read())
            {
                var empresa = new Empresa
                {
                    ID_Empresa = reader.GetInt32(reader.GetOrdinal("EMPR_ID_PK")),
                    ID_Endereco = reader.GetInt32(reader.GetOrdinal("ENDE_ID_PK")),
                    ID_CEP = reader.GetInt32(reader.GetOrdinal("CODI_ID_PK")),
                    Razao = reader.GetString(reader.GetOrdinal("EMPR_RAZ")),
                    CNPJ = reader.GetString(reader.GetOrdinal("EMPR_CNPJ")),
                    NumeroEndereco = reader.GetString(reader.GetOrdinal("ENDE_NUM")),
                    Complemento = reader.GetString(reader.GetOrdinal("ENDE_COM")),
                    CEP = reader.GetString(reader.GetOrdinal("CODI_CEP")),
                    Logradouro = reader.GetString(reader.GetOrdinal("CODI_LOG")),
                    Bairro = reader.GetString(reader.GetOrdinal("CODI_BAI")),
                    Localidade = reader.GetString(reader.GetOrdinal("CODI_LOC")),
                    UF = reader.GetString(reader.GetOrdinal("CODI_UF"))
                };
                empresas.Add(empresa);
            }
            return empresas;
        }

        public List<Empresa> Lista()
        {
            //variavel do tipo repositorio criada para chamar a funcao de receber tabela
            var repositorioEmpresa = new RepositorioEmpresa(_stringConexao);

            var empresas = new List<Empresa>();

            //sql salva o comando SQL que será enviado para o BD
            var sql = new StringBuilder()
                .AppendLine(select);

            using (var conn = new SqlConnection(_stringConexao))
            {
                //Bloco para conexão com banco de dados com SQL enviado pela string sql
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                var reader = command.ExecuteReader();
                //fim bloco de conexao 

                //pessoas recebe uma lista de objeto do tipo Pessoa criado com os valores da tabela do BD
                empresas = repositorioEmpresa.RecebeTabela(reader);
            }

            return empresas;
        }

        public List<Empresa> BuscaCnpj(string cnpj)
        {
            //variavel do tipo repositorio criada para chamar a funcao de receber tabela
            var repositorioEmpresa = new RepositorioEmpresa(_stringConexao);

            var empresas = new List<Empresa>();

            var sql = new StringBuilder()
                .AppendLine(select + "WHERE es.EMPR_CNPJ = @cnpj");

            using (var conn = new SqlConnection(_stringConexao))
            {
                //Bloco para conexão com banco de dados com SQL enviado pela string sql
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.Add(new SqlParameter("@cnpj", SqlDbType.VarChar) { Value = cnpj });
                var reader = command.ExecuteReader();
                //fim bloco de conexao 

                empresas = repositorioEmpresa.RecebeTabela(reader);
            }
            return empresas;
        }

        public void Adicionar(string razao, string cnpj,
                              string NumeroEndereco, string Complemento, string CEP,
                              string Logradouro, string Bairro, string Localidade, string UF)
        {
            //obtendo os Os valores maximo dos ids de CODIGOS POSTAIS E ENDERECOS, para saber qual valor das chaves estrangeiras
            string maxCP = "SELECT MAX(CODI_ID_PK) FROM CODIGOS_POSTAIS";
            string maxEND = "SELECT MAX(ENDE_ID_PK) FROM ENDERECOS";


            int ID_CEP = 0;
            int ID_END = 0;

            //Criando 3 variaveis para guardar o comando SQL que será enviado para o BD, uma para cada tabela que será adicionada
            var sqlCEP = new StringBuilder()
                .AppendLine("INSERT INTO CODIGOS_POSTAIS(CODI_CEP,CODI_LOG,CODI_BAI, CODI_LOC, CODI_UF ) " +
                            "VALUES(@CEP, @Logradouro, @Bairro, @Localidade, @UF)");

            var sqlEnderecos = new StringBuilder()
                .AppendLine("INSERT INTO ENDERECOS(ENDE_NUM, ENDE_COM, ENDE_CODI_ID_FK) " +
                            "VALUES(@NumeroEndereco, @Complemento, @ID_CEP)");

            var sqlEmpresa = new StringBuilder()
                .AppendLine("INSERT INTO EMPRESAS(EMPR_RAZ, EMPR_CNPJ, EMPR_ENDE_ID_FK) " +
                            "VALUES(@razao, @cnpj, @ID_end)");
            //FIM variaveis SQL


            //Estrutura para conectar os parametros '@' do comando sql com variáveis do sistema
            //Crianda a Tabela CODIGOS_POSTAIS que é chave estrangeira em ENDERECOS
            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sqlCEP.ToString(), conn);
                command.Parameters.AddWithValue("@CEP", CEP);
                command.Parameters.AddWithValue("@Bairro", Bairro);
                command.Parameters.AddWithValue("@Localidade", Localidade);
                command.Parameters.AddWithValue("@Logradouro", Logradouro);
                command.Parameters.AddWithValue("@UF", UF);
                var reader = command.ExecuteNonQuery();
            }

            //ESTRUTURA DO MAX para receber qual valor do ultimo ID de CODIGOS POSTAIS para colocar como chave estrangeira em ENDERECOS
            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open(); // abre conexão

                // maxCP tem o comando SQL para encontrar o valor maximo de ID
                using (var command = new SqlCommand(maxCP, conn))
                {
                    // ID_CEP guarda o ID que será chave estrangeiro em ENDERECOS(@ID_CEP
                    ID_CEP = (int)command.ExecuteScalar();

                }
                conn.Close(); // fecha a conexao
            }

            //Crianda a Tabela ENDERECOS que é chave estrangeira em PESSOA
            using (var conn = new SqlConnection(_stringConexao))
            {
                //estutura de conexao e relação dos atributos da string sql criada acima
                conn.Open();
                var command = new SqlCommand(sqlEnderecos.ToString(), conn);
                command.Parameters.AddWithValue("@ID_CEP", ID_CEP);
                command.Parameters.AddWithValue("@NumeroEndereco", NumeroEndereco);
                command.Parameters.AddWithValue("@Complemento", Complemento);
                var reader = command.ExecuteNonQuery();
            }

            //ESTRUTURA DO MAX para receber qual valor do ultimo ID de ENDERECOS para colocar como chave estrangeira em EMPRESAS
            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open(); // abre conexão

                // maxEND tem o comando SQL para encontrar o valor maximo de ID
                using (var command = new SqlCommand(maxEND, conn))
                {
                    // variável quantidade recebe o resultado da execução do método ExecuteScalar
                    ID_END = (int)command.ExecuteScalar();
                }
                conn.Close(); // fecha a conexao
            }

            //Crianda a tabela Empresa com chave estrangeira de ENDERECO
            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sqlEmpresa.ToString(), conn);
                command.Parameters.AddWithValue("@ID_end", ID_END);
                command.Parameters.AddWithValue("@razao", razao);
                command.Parameters.AddWithValue("@cnpj", cnpj);
                var reader = command.ExecuteNonQuery();
            }
        }

        public void Atualizar(string cnpjAtual, string razao, string cnpj,
            string NumeroEndereco, string Complemento, string CEP
            , string Logradouro, string Bairro, string Localidade, string UF)
        {

            var dadosAntigos = BuscaCnpj(cnpjAtual);

            var sql = new StringBuilder().AppendLine("UPDATE EMPRESAS " +
                                                     "SET EMPR_RAZ = @novarazao, EMPR_CNPJ = @novocnpj " +
                                                     "WHERE EMPR_CNPJ = @cnpjatual " +
                                                     "UPDATE ENDERECOS " +
                                                     "SET ENDE_NUM = @NumeroEndereco, ENDE_COM = @Complemento " +
                                                     "WHERE ENDE_ID_PK = @ID_end " +
                                                     "UPDATE CODIGOS_POSTAIS " +
                                                     "SET CODI_BAI = @Bairro, CODI_CEP = @CEP, CODI_LOC = @Localidade, CODI_LOG = @Logradouro, CODI_UF = @UF " +
                                                     "WHERE CODI_ID_PK = @ID_CEP ");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@novarazao", razao);
                command.Parameters.AddWithValue("@novocnpj", cnpj);
                command.Parameters.AddWithValue("@cnpjatual", cnpjAtual);
                command.Parameters.AddWithValue("@NumeroEndereco", NumeroEndereco);
                command.Parameters.AddWithValue("@Complemento", Complemento);
                command.Parameters.AddWithValue("@ID_end", dadosAntigos[0].ID_Endereco);
                command.Parameters.AddWithValue("@Bairro", Bairro);
                command.Parameters.AddWithValue("@CEP", CEP);
                command.Parameters.AddWithValue("@Localidade", Localidade);
                command.Parameters.AddWithValue("@Logradouro", Logradouro);
                command.Parameters.AddWithValue("@UF", UF);
                command.Parameters.AddWithValue("@ID_CEP", dadosAntigos[0].ID_CEP);

                var reader = command.ExecuteNonQuery();
            }
        }
        public bool DeletarEmpresa(Empresa empresaDeletada)
        {
            var sql = new StringBuilder().AppendLine("DELETE FROM EMPRESAS " +
                                                 "WHERE EMPR_CNPJ = @cnpj");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@cnpj", empresaDeletada.CNPJ);
                var reader = command.ExecuteNonQuery();
            }
            return true;
        }

        public bool DeletarEndereco(Empresa empresaDeletada)
        {
            var sql = new StringBuilder().AppendLine("DELETE FROM ENDERECOS " +
                                                 "WHERE ENDE_CODI_ID_FK = @ID_Endereco ");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@ID_Endereco", empresaDeletada.ID_Endereco);

                var reader = command.ExecuteNonQuery();
            }
            return true;
        }

        public bool DeletarCodigoPostal(Empresa pessoaDeletada)
        {
            var sql = new StringBuilder().AppendLine("DELETE FROM CODIGOS_POSTAIS " +
                                                 "WHERE CODI_ID_PK = @ID_CEP");
            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@ID_CEP", pessoaDeletada.ID_CEP);

                var reader = command.ExecuteNonQuery();
            }
            return true;
        }

        public void Deletar(string cnpj)
        {
            var repositorioEmpresa = new RepositorioEmpresa(_stringConexao);

            var empresaDeletada = new Empresa();
            //SQL para pegar o ENDERECO e CODIGO_POSTAL em comum com CNPJ
            var sql = new StringBuilder().AppendLine("SELECT EMPR_CNPJ, EMPR_ENDE_ID_FK, ENDE_CODI_ID_FK , CODI_ID_PK " +
                                                     "FROM EMPRESAS " +
                                                     "INNER JOIN ENDERECOS " +
                                                     "ON ENDE_CODI_ID_FK = EMPR_ENDE_ID_FK " +
                                                     "INNER JOIN CODIGOS_POSTAIS " +
                                                     "ON CODI_ID_PK = ENDE_CODI_ID_FK " +
                                                     "WHERE EMPR_CNPJ = @cnpj");

            using (var conn = new SqlConnection(_stringConexao))
            {

                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.Add(new SqlParameter("@cnpj", SqlDbType.VarChar) { Value = cnpj });
                var reader = command.ExecuteReader();

                //Salvando as informações para deletar as tabelas certas
                while (reader.Read())
                {
                    var empresa = new Empresa
                    {
                        ID_Endereco = reader.GetInt32(reader.GetOrdinal("ENDE_CODI_ID_FK")),//ID do endereco que será deletado
                        ID_CEP = reader.GetInt32(reader.GetOrdinal("CODI_ID_PK")),//ID do CEP que será deletado
                        CNPJ = reader.GetString(reader.GetOrdinal("EMPR_CNPJ"))//CNPJ da Pessoa que será deletada

                    };
                    empresaDeletada = empresa;
                }
            }
            //Estrutura para deletar em cascata manualmente
            repositorioEmpresa.DeletarEmpresa(empresaDeletada);
            repositorioEmpresa.DeletarEndereco(empresaDeletada);
            repositorioEmpresa.DeletarCodigoPostal(empresaDeletada);
        }

    }
}