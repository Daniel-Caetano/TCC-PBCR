using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    public class BaseController : ControllerBase // Realiza a Conexão com o Banco de Dados 
    {
        protected const string _connectionString = "Server=localhost,1401;Database=ERP;User Id = sa; Password=Tccpbcr123@";

    }
}
