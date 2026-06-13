using Mercearia.Application.DTOs;
using Mercearia.Application.Interfaces;
using Mercearia.Domain.Entities;
using Mercearia.Domain.Interfaces;

namespace Mercearia.Application.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _repository;
        // O Service depende do Repository

        public FornecedorService(IFornecedorRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<FornecedorResponseMultiple>> ObterTodosAsync()
        {
            var fornecedores = await _repository.GetAllAsync();
            // Mapeamento: Entidade -> DTO
            return fornecedores.Select(f => new FornecedorResponseMultiple
            {
                Id = f.Id,
                Nome = f.Nome,
                Nif = f.Nif,
                Email = f.Email
            });
        }
        public async Task<FornecedorResponse?> ObterPorIdAsync(Guid id)
        {
            var fornecedor = await _repository.GetByIdAsync(id);
            if (fornecedor == null) return null;
            // Mapeamento: Entidade -> DTO
            return new FornecedorResponse
            {
                Id = fornecedor.Id,
                Nome = fornecedor.Nome,
                Nif = fornecedor.Nif,
                Email = fornecedor.Email,
                Ativo = fornecedor.Ativo
            };
        }
        public async Task<FornecedorResponseMultiple> CriarAsync(CriarFornecedorRequest request)
        {
            // Mapeamento: DTO -> Entidade
            var fornecedorEntidade = new Fornecedor
            {
                Nome = request.Nome,
                Nif = request.Nif,
                Email = request.Email,
                Ativo = true
            };
            // Chama o repositório para persistir
            var fornecedorCriado = await _repository.AddAsync(fornecedorEntidade);
            // Retorna o DTO de resposta
            return new FornecedorResponseMultiple
            {
                Id = fornecedorCriado.Id,
                Nome = fornecedorCriado.Nome,
                Nif = fornecedorCriado.Nif,
                Email = fornecedorCriado.Email
            };
        }

        public async Task<FornecedorResponse> ApagarAsync(Guid id)
        {
            var fornecedor = await _repository.GetByIdAsync(id);
            if (fornecedor == null) return null;
            // Chama o repositório para persistir
            var fornecedorApagado = await _repository.DeleteAsync(fornecedor);
            // Retorna o DTO de resposta
            return new FornecedorResponse
            {
                Id = fornecedorApagado.Id,
                Nome = fornecedorApagado.Nome,
                Nif = fornecedorApagado.Nif,
                Email = fornecedorApagado.Email,
                Ativo = fornecedorApagado.Ativo
            };
        }
        public async Task<FornecedorResponse> EditarAsync(Guid id, EditarFornecedorRequest request)
        {
            var fornecedor = await _repository.GetByIdAsync(id);
            if (fornecedor == null) return null;

            fornecedor.Nome = request.Nome ?? fornecedor.Nome;
            fornecedor.Nif = request.Nif ?? fornecedor.Nif;
            fornecedor.Email = request.Email ?? fornecedor.Email;
            // Chama o repositório para persistir
            var fornecedorEditado = await _repository.EditAsync(fornecedor);
            // Retorna o DTO de resposta
            return new FornecedorResponse
            {
                Id = fornecedorEditado.Id,
                Nome = fornecedorEditado.Nome,
                Nif = fornecedorEditado.Nif,
                Email = fornecedorEditado.Email,
                Ativo = fornecedorEditado.Ativo
            };
        }
    }
}
