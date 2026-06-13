using Mercearia.Application.DTOs;
using Mercearia.Application.Interfaces;
using Mercearia.Domain.Entities;
using Mercearia.Domain.Interfaces;

namespace Mercearia.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        // O Service depende do Repository
        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ProdutoResponse>> ObterTodosAsync()
        {
            var produtos = await _repository.GetAllAsync();
            // Mapeamento: Entidade -> DTO
            return produtos.Select(p => new ProdutoResponse
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco
            });
        }
        public async Task<ProdutoResponse?> ObterPorIdAsync(int id)
        {
            var produto = await _repository.GetByIdAsync(id);
            if (produto == null) return null;
            // Mapeamento: Entidade -> DTO
            return new ProdutoResponse
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco
            };
        }
        public async Task<ProdutoResponse> CriarAsync(CriarProdutoRequest request)
        {
            // Mapeamento: DTO -> Entidade
            var produtoEntidade = new Produto
            {
                Nome = request.Nome,
                Preco = request.Preco,
                Stock = 0 // Regra de negócio: stock inicial é zero
            };
            // Chama o repositório para persistir
            var produtoCriado = await _repository.AddAsync(produtoEntidade);
            // Retorna o DTO de resposta
            return new ProdutoResponse
            {
                Id = produtoCriado.Id,
                Nome = produtoCriado.Nome,
                Preco = produtoCriado.Preco
            };
        }
    }
}
