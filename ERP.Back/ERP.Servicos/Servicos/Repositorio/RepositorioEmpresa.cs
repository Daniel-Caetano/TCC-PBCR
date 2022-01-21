using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Servico.Negocio;

namespace ERP.Servico.Servicos.Repositorio
{
    public class RepositorioEmpresa
    {
        private readonly string _stringConexao;
        //UTILIZAR ORM (ENTITY)
        public RepositorioEmpresa(string stringConexao)
        {
            _stringConexao = stringConexao;
        }
        public List<Empresa> BuscaCnpj(string cnpj)
        {
            var empresa = new List<Empresa>();
            var sql = new StringBuilder()
                .AppendLine("SELECT * FROM EMPRESAS E WHERE E.[EMPR_CNPJ] = @cnpj");

            using (var conn = new SqlConnection(_stringConexao))
            {
                conn.Open();
                var command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.Add(new SqlParameter("@cnpj", SqlDbType.VarChar) { Value = cnpj });
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var empresal = new Empresa
                    {
                        Numero = reader.GetInt32(reader.GetOrdinal("EMPR_ID_PK")),
                        Razao = reader.GetString(reader.GetOrdinal("EMPR_RAZ")),
                        CNPJ = reader.GetString(reader.GetOrdinal("EMPR_CNPJ")),
                        Endereco = reader.GetInt32(reader.GetOrdinal("EMPR_ENDE_ID_FK"))
                    };

                    empresa.Add(empresal);
                }
            }
            return empresa;
        }
    }
}