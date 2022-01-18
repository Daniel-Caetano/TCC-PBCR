using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        // protected const string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=ERP;Trusted_Connection=True;User Id = sa; Password=Daniel123@";
        protected const string _connectionString = "Server=localhost,1401;Database=ERP;User Id = sa; Password=Tccpbcr123@";
        
    }
}
