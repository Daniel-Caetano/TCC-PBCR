using ERP.ViewApi.Negocio;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ViewApi.Servicos.Interface
{
	public interface IEmpresaService
	{

		[Get("/Empresa/CNPJ/{cnpj}/json")]
		Task<IList<EmpresaResponse>> GetAsync(string cnpj);
	}
}
