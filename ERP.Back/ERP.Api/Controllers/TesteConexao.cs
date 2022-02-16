using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

namespace ERP.Api.Controllers
{
    public class TesteConexao : BaseController
    {
        SqlConnection conn = new SqlConnection(_connectionString);

        public object ConectarAoBanco()
        {
            try
            {
                var sql = new StringBuilder().AppendLine("");
                
                //Bloco para conexão com banco de dados com SQL enviado pela string sql
                conn.Open();
                
                var command = new SqlCommand(sql.ToString(), conn);
                var reader = command.ExecuteReader();
                conn.Close();
                return reader;
            }
            catch (Exception ex)
            {
                throw new TimeoutException($"Tempo de tentativa de conexão excedida: {ex.Message}");
                throw new Exception($"Conexão com o Banco de Dados Falhou: {ex.Message}");
            }
        }
    }
}
