using ERP.Servico.Negocio;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ERP.Servico.Servicos.Repositorio
{
    public class RepositorioPessoa
    {

        private readonly string _stringConexao;
        //UTILIZAR ORM (ENTITY)
        public RepositorioPessoa(string stringConexao)
        {
            _stringConexao = stringConexao;
        }
        //variavel select que guarda um comando SQL comum entre as funções
        private readonly string select = "SELECT PESS_ID_PK, pe.PESS_NOM, pe.PESS_CPF ,PESS_ENDE_ID_FK, ENDE_ID_PK ,e.ENDE_NUM, e.ENDE_COM , CODI_ID_PK ,cp.CODI_CEP , cp.CODI_LOG " +
                            ", cp.CODI_BAI , cp.CODI_LOC , cp.CODI_UF " +
                            "FROM PESSOAS pe " +
                            "INNER JOIN ENDERECOS e ON ENDE_ID_PK = PESS_ENDE_ID_FK " +
                            "INNER JOIN CODIGOS_POSTAIS cp ON cp.CODI_ID_PK = e.ENDE_CODI_ID_FK ";

        //Função para receber valores da tabela do BD, criada para não precisar repetir o codigo várias vezes
        public List<Pessoa> RecebeTabela(SqlDataReader reader)
        {
            var pessoas = new List<Pessoa>();
            while (reader.Read())
            {
                var pessoa = new Pessoa
                {
                    ID = reader.GetInt32(reader.GetOrdinal("PESS_ID_PK")),
                    Nome = reader.GetString(reader.GetOrdinal("PESS_NOM")),
                    CPF = reader.GetString(reader.GetOrdinal("PESS_CPF")),
                    ID_Endereco = reader.GetInt32(reader.GetOrdinal("PESS_ENDE_ID_FK")),
                    NumeroEndereco = reader.GetString(reader.GetOrdinal("ENDE_NUM")),
                    Complemento = reader.GetString(reader.GetOrdinal("ENDE_COM")),
                    ID_CEP = reader.GetInt32(reader.GetOrdinal("CODI_ID_PK")),
                    CEP = reader.GetString(reader.GetOrdinal("CODI_CEP")),
                    Logradouro = reader.GetString(reader.GetOrdinal("CODI_LOG")),
                    Bairro = reader.GetString(reader.GetOrdinal("CODI_BAI")),
                    Localidade = reader.GetString(reader.GetOrdinal("CODI_LOC")),
                    UF = reader.GetString(reader.GetOrdinal("CODI_UF"))
                };
                pessoas.Add(pessoa);
            }
            return pessoas;
        }
        public List<Pessoa> Lista()
        {
            //variavel do tipo repositorio criada para chamar a funcao de receber tabela
            var repositorioPessoa = new RepositorioPessoa(_stringConexao);

            var pessoas = new List<Pessoa>();//Lista de pessoa que será retornada

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
                pessoas = repositorioPessoa.RecebeTabela(reader);
            }
            return pessoas;
        }

        public List<Pessoa> BuscaCpf(string cpf)
        {
            //variavel do tipo repositorio criada para chamar a funcao de receber tabela
            var repositorioPessoa = new RepositorioPessoa(_stringConexao);

            var pessoas = new List<Pessoa>();

            var sql = new StringBuilder()
                .AppendLine(select + "WHERE PESS_CPF = @cpf");//o comando padrao select será concatenado com a string

            using (var conn = new SqlConnection(_stringConexao))
            {
                //Bloco para conexão com banco de dados com SQL enviado pela string sql
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.Add(new SqlParameter("@cpf", SqlDbType.VarChar) { Value = cpf });
                var reader = command.ExecuteReader();
                //fim bloco de conexao 

                //pessoas recebe uma lista de objeto do tipo Pessoa criado com os valores da tabela do BD
                pessoas = repositorioPessoa.RecebeTabela(reader);

            }
            return pessoas;
        }

        public List<Pessoa> BuscaNome(string nome)
        {
            //variavel do tipo repositorio criada para chamar a funcao de receber tabela
            var repositorioPessoa = new RepositorioPessoa(_stringConexao);

            var pessoas = new List<Pessoa>();//Lista de pessoa que será retornada

            //sql salva o comando SQL que será enviado para o BD
            var sql = new StringBuilder()
                .AppendLine(select + "WHERE PESS_NOM = @nome");

            using (var conn = new SqlConnection(_stringConexao))
            {
                //Bloco para conexão com banco de dados com SQL enviado pela string sql
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar) { Value = nome });
                var reader = command.ExecuteReader();
                //fim bloco de conexao 

                //pessoas recebe uma lista de objeto do tipo Pessoa criado com os valores da tabela do BD
                pessoas = repositorioPessoa.RecebeTabela(reader);

            }
            return pessoas;
        }


        public void Adicionar(string Nome, string CPF,
           string NumeroEndereco, string Complemento, string CEP
           , string Logradouro, string Bairro, string Localidade, string UF)
        {
            //pegando os Os valores maximo dos ids de CODIGOS POSTAIS E ENDERECOS, para saber qual valor das chaves estrangeiras
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
                            "VALUES(@NumeroEndereco, @Complemento, @ID_CEP)");//ID_CEP foi encontrado na estrutura do MAX

            var sqlEmpresa = new StringBuilder()
                .AppendLine("INSERT INTO PESSOAS " +
                            "(PESS_NOM,PESS_CPF,PESS_ENDE_ID_FK) " +
                            "VALUES(@nome,@cpf,@ID_end); ");//ID_END foi encontrado na estrutura do MAX
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
                conn.Open(); // abre conexão com BD

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
                var reader = command.ExecuteNonQuery();//ExecuteNonQuery para enviar dados para o BD
            }

            //ESTRUTURA DO MAX para receber qual valor do ultimo ID de ENDERECOS para colocar como chave estrangeira em PESSOAS
            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open(); // abre conexão

                // maxEND tem o comando SQL para encontrar o valor maximo de ID
                using (var command = new SqlCommand(maxEND, conn))
                {
                    ID_END = (int)command.ExecuteScalar(); //comando ExecuteScalar para ler o comando max
                }
                conn.Close(); // fecha a conexao
            }

            //Crianda a tabela Pessoa com chave estrangeira de ENDERECO
            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sqlEmpresa.ToString(), conn);
                command.Parameters.AddWithValue("@ID_end", ID_END);
                command.Parameters.AddWithValue("@nome", Nome);
                command.Parameters.AddWithValue("@cpf", CPF);
                var reader = command.ExecuteNonQuery();
            }
        }
        public void Atualizar(string CpfAtual, string Nome, string CPF,
        string NumeroEndereco, string Complemento, string CEP
      , string Logradouro, string Bairro, string Localidade, string UF)
        {

            var dadosAntigos = BuscaCpf(CpfAtual);

            var sql = new StringBuilder().AppendLine("UPDATE PESSOAS " +
                                                     "SET PESS_NOM = @nome, " +
                                                     "PESS_CPF = @cpf " +
                                                     "WHERE PESS_CPF = @CpfAtual " +
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
                command.Parameters.AddWithValue("@nome", Nome);
                command.Parameters.AddWithValue("@cpf", CPF);
                command.Parameters.AddWithValue("@CpfAtual", CpfAtual);
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
        public bool DeletarPessoa(Pessoa pessoaDeletada)
        {
            var sql = new StringBuilder().AppendLine("DELETE FROM PESSOAS " +
                                                     "WHERE PESS_CPF = @cpf ");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@cpf", pessoaDeletada.CPF);
                var reader = command.ExecuteNonQuery();
            }
            return true;
        }

        public bool DeletarEndereco(Pessoa pessoaDeletada)
        {
            var sql = new StringBuilder().AppendLine("DELETE FROM ENDERECOS " +
                                                 "WHERE ENDE_CODI_ID_FK = @ID_Endereco ");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@ID_Endereco", pessoaDeletada.ID_Endereco);

                var reader = command.ExecuteNonQuery();
            }
            return true;
        }

        public bool DeletarCodigoPostal(Pessoa pessoaDeletada)
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
        //65990298170/ID 10
        public void Deletar(string cpf)
        {
            var repositorioPessoa = new RepositorioPessoa(_stringConexao);
            var pessoaDeletada = new Pessoa();
            //SQL para pegar o ENDERECO e CODIGO_POSTAL em comum com CPF
            var sql = new StringBuilder().AppendLine("SELECT PESS_CPF ,PESS_ENDE_ID_FK, ENDE_CODI_ID_FK , CODI_ID_PK " +
                                                     "FROM PESSOAS " +
                                                     "INNER JOIN ENDERECOS " +
                                                     "ON ENDE_CODI_ID_FK = PESS_ENDE_ID_FK " +
                                                     "INNER JOIN CODIGOS_POSTAIS " +
                                                     "ON CODI_ID_PK = ENDE_CODI_ID_FK " +
                                                     "WHERE PESS_CPF = @cpf");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.Add(new SqlParameter("@cpf", SqlDbType.VarChar) { Value = cpf });
                var reader = command.ExecuteReader();

                //Salvando as informações para deletar as tabelas certas
                while (reader.Read())
                {
                    var pessoa = new Pessoa
                    {
                        ID_Endereco = reader.GetInt32(reader.GetOrdinal("ENDE_CODI_ID_FK")),//ID do endereco que será deletado
                        ID_CEP = reader.GetInt32(reader.GetOrdinal("CODI_ID_PK")),//ID do CEP que será deletado
                        CPF = reader.GetString(reader.GetOrdinal("PESS_CPF"))//CPF da Pessoa que será deletada
                    };
                    pessoaDeletada = pessoa;
                }
            }

            //Estrutura para deletar em cascata manualmente
            repositorioPessoa.DeletarPessoa(pessoaDeletada); 
            repositorioPessoa.DeletarEndereco(pessoaDeletada);
            repositorioPessoa.DeletarCodigoPostal(pessoaDeletada);
        }
    }
}