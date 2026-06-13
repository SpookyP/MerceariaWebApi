using Mercearia.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercearia.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoResponse>> ObterTodosAsync();
        Task<ProdutoResponse?> ObterPorIdAsync(int id);
        Task<ProdutoResponse> CriarAsync(CriarProdutoRequest request);
    }
}
