using Mercearia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercearia.Infrastructure.Data
{
    public class MerceariaDbContext : DbContext
    {
        // O construtor recebe as opções (como a connection string) e passa para a base
        public MerceariaDbContext(DbContextOptions<MerceariaDbContext> options)
        : base(options)
        {
        }
        // Representa a tabela "Produtos" na base de dados
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aqui podemos configurar regras específicas (Fluent API)
            // Exemplo: O campo Preço deve ter precisão de moeda
            modelBuilder.Entity<Produto>()
            .Property(p => p.Preco)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Fornecedor>()
            .Property(p => p.Nif)
            .HasMaxLength(9)
            .IsFixedLength();

            modelBuilder.Entity<Fornecedor>()
            .HasIndex(f => f.Nif)
            .IsUnique();

            modelBuilder.Entity<Fornecedor>()
            .HasIndex(f => f.Email)
            .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
