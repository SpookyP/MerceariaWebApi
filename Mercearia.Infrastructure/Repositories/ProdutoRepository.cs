using Mercearia.Domain.Entities;
using Mercearia.Domain.Interfaces;
using Mercearia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercearia.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MerceariaDbContext _context;
        // Injetamos o DbContext aqui. O Repositório conhece o Contexto, mas o Controller não!
        public ProdutoRepository(MerceariaDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }
        public async Task<Produto?> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }
        public async Task<Produto> AddAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync(); // Persiste a mudança na BD
            return produto;
        }
    }
}
