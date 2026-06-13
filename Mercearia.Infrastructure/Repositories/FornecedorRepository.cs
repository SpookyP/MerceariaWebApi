using Azure.Core;
using Mercearia.Domain.Entities;
using Mercearia.Domain.Interfaces;
using Mercearia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Mercearia.Infrastructure.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly MerceariaDbContext _context;
        // Injetamos o DbContext aqui. O Repositório conhece o Contexto, mas o Controller não!
        public FornecedorRepository(MerceariaDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Fornecedor>> GetAllAsync()
        {
            return await _context.Fornecedores.ToListAsync();
        }
        public async Task<Fornecedor?> GetByIdAsync(Guid id)
        {
            return await _context.Fornecedores.FindAsync(id);
        }
        public async Task<Fornecedor> AddAsync(Fornecedor fornecedor)
        {
            await _context.Fornecedores.AddAsync(fornecedor);
            await _context.SaveChangesAsync(); // Persiste a mudança na BD
            return fornecedor;
        }
        public async Task<Fornecedor> DeleteAsync(Fornecedor fornecedor)
        {
            fornecedor.Ativo = false;
            _context.Fornecedores.Update(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }
        public async Task<Fornecedor> EditAsync(Fornecedor fornecedor)
        {
            fornecedor.Ativo = true;
            _context.Fornecedores.Update(fornecedor);
            await _context.SaveChangesAsync(); // Persiste a mudança na BD
            return fornecedor;
        }
    }
}
