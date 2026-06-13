using Mercearia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercearia.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        // Usamos Task para operações assíncronas (boa prática em I/O de base de dados)
        Task<IEnumerable<Produto>> GetAllAsync();
        Task<Produto?> GetByIdAsync(int id);
        Task<Produto> AddAsync(Produto produto);
    }
}
