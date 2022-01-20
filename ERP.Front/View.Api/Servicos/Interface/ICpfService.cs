using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Api.Servico
{
    public interface ICpfService
    {
        [Get("/Pessoa/CPF/{cpf}/json")]
        Task<CpfResponse> GetAsync(string cpf);
    }
}

// 14120490084