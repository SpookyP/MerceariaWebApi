using Mercearia.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercearia.Application.Interfaces
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorResponseMultiple>> ObterTodosAsync();
        Task<FornecedorResponse?> ObterPorIdAsync(Guid id);
        Task<FornecedorResponseMultiple> CriarAsync(CriarFornecedorRequest request);
        Task<FornecedorResponse> ApagarAsync(Guid id);
        Task<FornecedorResponse> EditarAsync(Guid id, EditarFornecedorRequest request);
    }
}
