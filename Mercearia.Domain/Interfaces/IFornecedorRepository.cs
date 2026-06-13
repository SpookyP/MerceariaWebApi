using Mercearia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercearia.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        // Usamos Task para operações assíncronas (boa prática em I/O de base de dados)
        Task<IEnumerable<Fornecedor>> GetAllAsync();
        Task<Fornecedor?> GetByIdAsync(Guid id);
        Task<Fornecedor> AddAsync(Fornecedor fornecedor);
        Task<Fornecedor> DeleteAsync(Fornecedor fornecedor);
        Task<Fornecedor> EditAsync(Fornecedor fornecedor);
    }
}
